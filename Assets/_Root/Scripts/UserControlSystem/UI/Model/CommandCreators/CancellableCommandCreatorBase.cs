using Abstractions.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utils.AssetsInjector;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public abstract class CancellableCommandCreatorBasee<TCommand, TArgument> : CommandCreatorBase<TCommand> where TCommand : ICommand
    {
        [Inject] private AssetsContext _context;
        [Inject] private IAwaitable<TArgument> _awaitableArgument;

        private CancellationTokenSource _ctSource;


        protected override sealed async void ClassSpecificCommandCreation(Action<TCommand> creationCallback)
        {
            _ctSource = new CancellationTokenSource();

            try
            {
                var argument = await _awaitableArgument.WithCancellation(_ctSource.Token);
                creationCallback?.Invoke(_context.Inject(CreateCommand(argument)));
            }
            catch { }
        }

        protected abstract TCommand CreateCommand(TArgument argument);

        public override void ProcessCancel()
        {
            base.ProcessCancel();

            if (_ctSource != null)
            {
                _ctSource.Cancel();
                _ctSource.Dispose();
                _ctSource = null;
            }
        }
    }
}