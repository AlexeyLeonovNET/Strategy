using Abstractions.Commands.CommandInterfaces;
using System;
using UserControlSystem.UnitCommands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;


        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback) =>
            creationCallback?.Invoke(_context.Inject(new StopCommand()));
    }
}
