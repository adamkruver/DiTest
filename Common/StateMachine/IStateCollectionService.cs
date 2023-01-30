namespace Assets.Common.StateMachine
{
    public interface IStateCollectionService
    {
        T Get<T>() where T : class, IState;
    }
}