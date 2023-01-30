using UnityEngine;

namespace Assets.Common.Di.MonoBehaviour
{
    public class PoolObjectDecorator
    {
        private readonly IPoolable _item;
        private readonly Transform _parent;

        public PoolObjectDecorator(IPoolable item, Transform parent)
        {
            _parent = parent;
            _item = item;
            
            _item.Releasing += OnReleasing;
        }

        ~PoolObjectDecorator() =>
            _item.Releasing -= OnReleasing;

        private void OnReleasing() =>
            _item.gameObject.transform.SetParent(_parent);
    }
}