using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.UnitCommands;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class MoveCommandCreator : CancellableCommandCreatorBasee<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) =>
            new MoveCommand(argument);
    }
}