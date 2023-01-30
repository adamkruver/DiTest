using System;

namespace Assets.Common.StateMachine
{
    public interface ITransition
    {
        event Action<IState> HasNextState;

        void Enable();
        void Disable();
    }
}