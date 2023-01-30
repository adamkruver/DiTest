using System;

namespace Assets.Common.StateMachine
{
    public interface IState
    {
        event Action<IState> HasNextState;
        
        void Enter();
        void Exit();
    }
}