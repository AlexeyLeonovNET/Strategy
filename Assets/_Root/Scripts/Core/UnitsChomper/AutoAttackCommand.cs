using Abstractions;
using Abstractions.Commands.CommandInterfaces;

namespace Core.UnitsChomper
{
    public class AutoAttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }


        public AutoAttackCommand(IAttackable target) => Target = target;
    }
}