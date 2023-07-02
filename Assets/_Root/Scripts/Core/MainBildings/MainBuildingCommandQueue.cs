using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Zenject;

namespace Core.MainBildings
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;

        public ICommand CurrentCommand => default;


        public void Clear() { }
        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyPointCommandExecutor.TryExecuteCommand(command);
        }
    }
}