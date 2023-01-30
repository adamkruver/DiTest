using System;
using Common.Di.Activation;

namespace Common.Di
{
    public class ObjectBuilder: IDisposable
    {
        private readonly ObjectsContainer _objectsContainer = new ObjectsContainer();
        private readonly ActivateStrategiesFactory _activateStrategiesFactory;

        public ObjectBuilder()
        {
            _activateStrategiesFactory = new ActivateStrategiesFactory(_objectsContainer);
            _objectsContainer.Register(typeof(ObjectsContainer), _objectsContainer);
            _objectsContainer.Register(typeof(ActivateStrategiesFactory), _activateStrategiesFactory);
        }

        public ObjectBuilder Build<T>() where T : class
        {
            new ObjectFactory(
                typeof(T),
                _activateStrategiesFactory
            ).Create();

            return this;
        }

        public ObjectBuilder BuildScene()
        {
            new SceneObjectFactory(
                _objectsContainer,
                _activateStrategiesFactory
            ).Create();
            
            return this;
        }

        public void Dispose() =>
            _objectsContainer.Dispose();
    }
}