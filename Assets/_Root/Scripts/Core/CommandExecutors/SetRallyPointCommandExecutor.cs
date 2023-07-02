using Abstractions.Commands.CommandInterfaces;
using Core.MainBildings;
using System.Threading.Tasks;

namespace Core.CommandExecutors
{
    public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command) =>
            GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
    }
}