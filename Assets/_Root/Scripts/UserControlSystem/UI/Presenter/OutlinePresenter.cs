using Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class OutlinePresenter : MonoBehaviour
    {
        [Inject] private IObservable<ISelecatable> _selectableValue;

        private ISelecatable _currentSelectable;


        void Start()
        {
            _selectableValue.Subscribe(OnSelected);
        }

        private void OnSelected(ISelecatable selecatable)
        {
            if (_currentSelectable == selecatable)
                return;

            _currentSelectable = selecatable;

            if(selecatable != null)
                selecatable.Outline.enabled = true;
            else
                selecatable.Outline.enabled = false;

            if(this == null)
                return;
        }
    }
}