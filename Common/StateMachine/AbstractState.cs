using System;
using Extension.Enumerable;

namespace Assets.Common.StateMachine
{
    public abstract class AbstractState : IState
    {
        private readonly ITransition[] _transitions;

        protected AbstractState(ITransition[] transitions) =>
            _transitions = transitions;

        public event Action<IState> HasNextState;

        public bool IsEnabled { get; private set; }

        public void Enter()
        {
            if (IsEnabled)
                return;

            OnEnter();
            RegisterTransitions();
            IsEnabled = true;
        }

        public void Exit()
        {
            if (IsEnabled == false)
                return;

            UnregisterTransitions();
            OnExit();
            IsEnabled = false;
        }

        protected virtual void OnEnter()
        {
        }
        
        protected virtual void OnExit()
        {
        }

        private void RegisterTransitions() =>
            _transitions.Map(transition =>
            {
                transition.HasNextState += OnHasNextState;
                transition.Enable();
            });

        private void UnregisterTransitions() =>
            _transitions.Map(transition =>
            {
                transition.Disable();
                transition.HasNextState -= OnHasNextState;
            });

        private void OnHasNextState(IState state) =>
            HasNextState?.Invoke(state);
    }
}