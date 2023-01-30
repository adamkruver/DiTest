using System;
using Common.Di.Activation;
using Common.Di.Extensions;
using UnityEngine;

namespace Common.Di
{
    public class ObjectFactory
    {
        private readonly Type _type;
        private readonly ActivateStrategiesFactory _activateStrategiesFactory;

        public ObjectFactory(
            Type type,
            ActivateStrategiesFactory activateStrategiesFactory
        )
        {
            _type = type;
            _activateStrategiesFactory = activateStrategiesFactory;
        }

        public object Create()
        {
            ObjectType objectType = _type.ToObjectType();
            
            var activationStrategy = _activateStrategiesFactory.Get(objectType);

            if (activationStrategy == null)
                throw new Exception($"{GetType()} not found activate strategy for {_type}");

            return activationStrategy.Activate(_type);
        }
    }
}