using Assets.Common.Di.MonoBehaviour;

namespace Assets.Common.Specification
{
    public class PoolObjectReleasedSpecefication : Specification<IPoolable>
    {
        private readonly IPoolable _poolObject;

        public PoolObjectReleasedSpecefication(IPoolable poolObject) =>
            _poolObject = poolObject;

        public override bool IsSatisfiedBy() =>
            _poolObject.IsReleased;
    }
}