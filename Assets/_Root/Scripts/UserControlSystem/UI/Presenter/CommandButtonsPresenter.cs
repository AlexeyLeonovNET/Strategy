using Abstractions;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem.UI.View;
using Abstractions.Commands;
using Zenject;
using UserControlSystem.UI.Model.CommandCreators;
using System;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;

        [Inject] private CommandButtonsModel _model;
        [Inject] private IObservable<ISelecatable> _selectable;

        private ISelecatable _currentSelectable;


        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;

            _selectable.Subscribe(OnSelected);
        }


        private void OnSelected(ISelecatable selectable)
        {
            if (_currentSelectable == selectable)
                return;

            if (_currentSelectable != null)
                _model.OnSelectionChanged();

            _currentSelectable = selectable;
            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component)
                    .GetComponentsInParent<ICommandExecutor>());

                var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
                _view.MakeLayout(commandExecutors, queue);
            }
        }
    }
}