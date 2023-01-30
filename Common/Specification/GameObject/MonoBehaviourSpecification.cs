using Common.Interfaces;
using UnityEngine;

namespace Assets.Common.Specification
{
    public static class MonoBehaviourSpecification
    {
        public static bool IsInactive(MonoBehaviour monoBehaviour) =>
            new GameObjectEnabledSpecification(monoBehaviour.gameObject).IsSatisfiedBy() == false;
        
        public static bool IsInactive(IMonoBehaviour monoBehaviour) =>
            new GameObjectEnabledSpecification(monoBehaviour.gameObject).IsSatisfiedBy() == false;
    }
}