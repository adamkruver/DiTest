using System;
using System.Collections;
using Assets.Common.Coroutine;
using UnityEngine;

namespace Assets.Common.Cooldown
{
    public class Cooldown
    {
        private readonly CoroutineRunner _coroutineRunner;

        private Action _callback;
        private Action _activeCallback;
        private WaitForSeconds _waitForSeconds;

        public Cooldown(CoroutineRunnerFactory coroutineRunnerFactory) =>
            _coroutineRunner = coroutineRunnerFactory.Create();

        public void Set(Action callback, float seconds)
        {
            _callback = callback;
            _waitForSeconds = new WaitForSeconds(seconds);
        }

        public void Start()
        {
            if (_callback == null)
                return;

            if (_activeCallback != null)
                return;
            
            _activeCallback = _callback;
            _coroutineRunner.Run(WaitCoroutine());
        }

        public void Stop()
        {
            _coroutineRunner.Stop();
            _activeCallback = null;
        }

        private IEnumerator WaitCoroutine()
        {
            while (_activeCallback != null)
            {
                yield return _waitForSeconds;
                _activeCallback?.Invoke();
            }
        }
    }
}