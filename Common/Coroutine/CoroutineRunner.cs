using System.Collections;

namespace Assets.Common.Coroutine
{
    using UnityEngine;
    
    public class CoroutineRunner
    {
        private readonly CoroutineObject _coroutineObject;
        private Coroutine _coroutine;
        
        public CoroutineRunner(CoroutineObject coroutineObject) =>
            _coroutineObject = coroutineObject;

        public void Run(IEnumerator coroutine)
        {
            Stop();
            
            _coroutine = _coroutineObject.StartCoroutine(coroutine);
        }

        public void Stop()
        {
            if(_coroutine != null && _coroutineObject != null)
                _coroutineObject.StopCoroutine(_coroutine);
        }
    }
}