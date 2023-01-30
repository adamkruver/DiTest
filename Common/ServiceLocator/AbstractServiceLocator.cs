using System;
using System.Collections.Generic;

namespace Assets.Common.ServiceLocator
{
    public abstract class AbstractServiceLocator<T> : IServiceLocator<T, T> where T: class
    {
        private readonly Dictionary<Type, T> _instances = new Dictionary<Type, T>();

        public void Register<TObject>(TObject instance) where TObject : T
        {
            if (_instances.ContainsKey(typeof(TObject)))
                throw new NullReferenceException($"{GetType()}: {typeof(TObject)} already added");

            _instances.Add(typeof(TObject), instance);
        }

        public T Get<TObject>() where TObject : T =>
            _instances.ContainsKey(typeof(TObject))
                ? _instances[typeof(TObject)]
                : throw new NullReferenceException($"{GetType()}: {typeof(TObject)} not found");
    }
}