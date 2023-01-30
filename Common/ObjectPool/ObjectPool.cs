using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Common.Di.MonoBehaviour
{
    public class ObjectPool<T> where T : IPoolable
    {
        private const string GameObjectPoolName = "GameObjectsPool";
        
        private readonly Func<T> _createMethod;
        private readonly Func<T, bool> _releasedPredicate;
        private readonly List<T> _objects = new List<T>();
        private readonly Transform _container;

        public ObjectPool(Func<T> createMethod, Func<T, bool> releasedPredicate)
        {
            _createMethod = createMethod;
            _releasedPredicate = releasedPredicate;
            Transform rootContainer = GetPoolRoot().transform;
            _container = CreateContainer();
            _container.SetParent(rootContainer);
        }

        public T Get()
        {
            T poolObject = _objects.FirstOrDefault(_releasedPredicate) ?? Create();
            poolObject.Reuse();
            return poolObject;
        }

        private T Create()
        {
            T poolObject = _createMethod();
            new PoolObjectDecorator(poolObject, _container);
            _objects.Add(poolObject);

            return poolObject;
        }

        private GameObject GetPoolRoot() =>
            GameObject.Find(GameObjectPoolName) ?? new GameObject(GameObjectPoolName);

        private Transform CreateContainer() =>
            new GameObject(typeof(T).ToString()).transform;
    }
}