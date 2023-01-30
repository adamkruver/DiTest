namespace Assets.Common.StateMachine
{
    public interface IStateMachine
    {
        void Run(IState state);
    }
}