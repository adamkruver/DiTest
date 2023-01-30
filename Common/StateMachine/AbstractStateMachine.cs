using UnityEngine;

namespace Assets.Common.StateMachine
{
    public abstract class AbstractStateMachine : IStateMachine
    {
        private IState _currentState;

        public void Run(IState state)
        {
            ChangeState(state);
        }

        private void ChangeState(IState state)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
                _currentState.HasNextState -= ChangeState;
            }

            _currentState = state;
            _currentState.HasNextState += ChangeState;
            _currentState.Enter();
        }
    }
}