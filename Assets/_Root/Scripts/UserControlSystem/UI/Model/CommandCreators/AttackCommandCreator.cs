using Abstractions.Commands.CommandInterfaces;
using UserControlSystem.UnitCommands;
using Abstractions;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CancellableCommandCreatorBasee<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) =>
            new AttackCommand(argument);
    }
}