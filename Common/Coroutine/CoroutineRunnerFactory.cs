using UnityEngine;

namespace Assets.Common.Coroutine
{
    public class CoroutineRunnerFactory
    {
        private static GameObject _gameObject = new GameObject("CoroutineRunner");
        private static CoroutineObject _coroutineObject;

        private CoroutineObject CoroutineObject => _coroutineObject ??= _gameObject.AddComponent<CoroutineObject>();

        public CoroutineRunner Create() =>
            new CoroutineRunner(CoroutineObject);
    }
}