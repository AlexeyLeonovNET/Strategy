using Abstractions;
using Abstractions.Commands.CommandInterfaces;

namespace UserControlSystem.UnitCommands
{
    public class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }


        public AttackCommand(IAttackable target) => Target = target;
    }
}