using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.UnitCommands;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class SetRallyPointCommandCreator : CancellableCommandCreatorBasee<ISetRallyPointCommand, Vector3>
    {
        protected override ISetRallyPointCommand CreateCommand(Vector3 argument) =>
            new SetRallyPointCommand(argument);
    }
}