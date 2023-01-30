using Assets.Common.Di.MonoBehaviour;

namespace Assets.Common.Specification
{
    public static class PoolableSpecification
    {
        public static bool IsReleased(IPoolable poolObject) =>
            new PoolObjectReleasedSpecefication(poolObject).IsSatisfiedBy();

    }
}