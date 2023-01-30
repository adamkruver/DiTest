using System;
using System.Collections.Generic;

namespace Modules.LiveData
{
    public class LiveData<T> : IDisposable
    {
        private readonly MutableLiveData<T> _mutableLiveData;
        private List<Action<T>> _callbacks = new List<Action<T>>();

        public LiveData(MutableLiveData<T> mutableLiveData)
        {
            _mutableLiveData = mutableLiveData;
            _mutableLiveData.Changed += OnChanged;
        }

        ~LiveData() =>
            Dispose();

        public T Value => _mutableLiveData.Value;

        private void OnChanged(T value)
        {
            foreach (var callback in _callbacks)
                callback(value);
        }

        public void Dispose()
        {
            _callbacks = null;
            _mutableLiveData.Changed -= OnChanged;
            GC.SuppressFinalize(this);
        }

        public void Observe(Action<T> callback)
        {
            if (_callbacks.Contains(callback))
                return;

            _callbacks.Add(callback);

            callback(_mutableLiveData.Value);
        }
    }
}