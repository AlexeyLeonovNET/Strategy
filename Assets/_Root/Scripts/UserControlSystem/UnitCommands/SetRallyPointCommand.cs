using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace UserControlSystem.UnitCommands
{
    public class SetRallyPointCommand : ISetRallyPointCommand
    {
        public Vector3 RallyPoint { get; }

        public SetRallyPointCommand(Vector3 rallyPoint) =>
            RallyPoint = rallyPoint;
    }
}