using Assets.Common.Di.MonoBehaviour;
using Common.Di.Activation;
using Common.Di.MonoBehaviour;

namespace Common.Di
{
    using UnityEngine;
    
    public class SceneObjectFactory
    {
        private readonly ObjectsContainer _objectsContainer;
        private readonly ActivateStrategiesFactory _activateStrategiesFactory;

        public SceneObjectFactory(
            ObjectsContainer objectsContainer,
            ActivateStrategiesFactory activateStrategiesFactory)
        {
            _objectsContainer = objectsContainer;
            _activateStrategiesFactory = activateStrategiesFactory;
        }

        public void Create()
        {
            var monoBehaviours = GameObject.FindObjectsOfType<UnityEngine.MonoBehaviour>();

            foreach (var monoBehaviour in monoBehaviours)
            {
                new GameObjectConstructorInvoker(
                    monoBehaviour,
                    _objectsContainer,
                    _activateStrategiesFactory
                ).Invoke();
            }
        }
    }
}