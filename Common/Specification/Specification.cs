using System;
using System.Linq.Expressions;

namespace Assets.Common.Specification
{
    public abstract class Specification<T>
    {
//        public abstract Expression<Func<T, bool>> IsSatisfiedBy();
        public abstract bool IsSatisfiedBy();
    }
}