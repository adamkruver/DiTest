using System;

namespace Assets.Common.Di.MonoBehaviour
{
    using UnityEngine;

    public class PoolBehaviour : MonoBehaviour, IPoolable
    {
        public event Action Releasing;
        public event Action Reusing;

        public bool IsReleased { get; private set; } = true;

        public void Release()
        {
            if (IsReleased)
                return;

            OnReleasing();
            Releasing?.Invoke();
            IsReleased = true;
        }

        public void Reuse()
        {
            if (IsReleased == false)
                return;

            IsReleased = false;
            OnReusing();
            Reusing?.Invoke();
        }
        
        protected virtual void OnReleasing()
        {
        }
        
        protected virtual void OnReusing()
        {
        }
    }
}