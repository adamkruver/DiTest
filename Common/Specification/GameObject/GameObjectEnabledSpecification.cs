using UnityEngine;

namespace Assets.Common.Specification
{
    public class GameObjectEnabledSpecification: Specification<GameObject>
    {
        private readonly GameObject _gameObject;

        public GameObjectEnabledSpecification(GameObject gameObject) =>
            _gameObject = gameObject;

        public override bool IsSatisfiedBy() =>
            _gameObject.activeSelf;
    }
}