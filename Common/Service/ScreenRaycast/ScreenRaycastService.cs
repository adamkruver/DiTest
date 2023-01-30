using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Common.Coroutine;
using UnityEngine;

namespace Assets.Common.Service.ScreenRaycast
{
    public class ScreenRaycastService : IScreenRaycastService, IDisposable
    {
        private readonly ScreenRaycastHandler _screenRaycastHandler = new ScreenRaycastHandler();
        private readonly CoroutineRunner _coroutineRunner;

        private bool _isEnabled = false;

        public ScreenRaycastService(CoroutineRunnerFactory coroutineRunnerFactory)
        {
            _coroutineRunner = coroutineRunnerFactory.Create();
        }

        ~ScreenRaycastService() =>
            Dispose();

        public void Start()
        {
            if (_isEnabled)
                return;

            _isEnabled = true;
            
            _coroutineRunner.Run(ListenCoroutine());
        }

        public void Stop()
        {
            if (_isEnabled == false)
                return;
            
            _coroutineRunner.Stop();
            _isEnabled = false;
        }

        private IEnumerator ListenCoroutine()
        {
            while (true)
            {
                _screenRaycastHandler.Cast(GetRay());
                yield return null;
            }
        }

        private Ray GetRay() =>
            Camera.main.ScreenPointToRay(Input.mousePosition);

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }
    }
}