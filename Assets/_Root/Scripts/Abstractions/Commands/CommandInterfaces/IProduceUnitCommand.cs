using UnityEngine;

namespace Abstractions.Commands.CommandInterfaces
{
    public interface IProduceUnitCommand : ICommand, IIconHolder
    {
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        string UnitName { get; }
    }
}