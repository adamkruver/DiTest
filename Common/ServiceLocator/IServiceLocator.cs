namespace Assets.Common.ServiceLocator
{
    public interface IServiceLocator<in T1, out T2>
    {
        void Register<TObject>(TObject instance) where TObject : T1;
        T2 Get<TObject>() where TObject: T1;
    }
}