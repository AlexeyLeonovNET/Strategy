﻿using Abstractions;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public class TopPanelPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuBlockPanel;


        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _inputField.text = string.Format("{0:D2}:{1:D2}",
                    t.Minutes,
                    t.Seconds);
            });

            _menuButton.OnClickAsObservable().Subscribe(_ => _menuBlockPanel.SetActive(true));
        }
    }
}