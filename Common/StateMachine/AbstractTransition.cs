using System;

namespace Assets.Common.StateMachine
{
    public abstract class AbstractTransition<T> : ITransition where T: class, IState
    {
        private readonly IStateCollectionService _stateCollectionService;

        protected AbstractTransition(IStateCollectionService stateCollectionService)
        {
            _stateCollectionService = stateCollectionService;
        }

        public event Action<IState> HasNextState;

        public abstract void Enable();

        public abstract void Disable();

        protected void ApplyNextState() =>
            HasNextState?.Invoke(_stateCollectionService.Get<T>());
    }
}