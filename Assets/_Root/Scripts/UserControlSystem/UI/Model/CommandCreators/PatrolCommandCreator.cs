using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.UnitCommands;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CancellableCommandCreatorBasee<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;


        protected override IPatrolCommand CreateCommand(Vector3 argument) =>
            new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}