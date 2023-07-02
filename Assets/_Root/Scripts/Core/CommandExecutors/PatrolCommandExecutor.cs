using Abstractions.Commands.CommandInterfaces;
using Core.UnitsChomper;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;


        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var pointFrom = command.From;
            var pointTo = command.To;

            while(true)
            {
                GetComponent<NavMeshAgent>().destination = pointTo;
                _animator.SetTrigger(Animator.StringToHash("Walk"));
                _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();

                try
                {
                    await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
                catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                    break;
                }

                var temp = pointFrom;
                pointFrom = pointTo;
                pointTo = temp;
            }

            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash("Idle"));
        }
    }
}