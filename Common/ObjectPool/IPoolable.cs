using System;
using Common.Interfaces;

namespace Assets.Common.Di.MonoBehaviour
{
    public interface IPoolable: IMonoBehaviour
    {
        event Action Releasing;
        event Action Reusing;
        
        bool IsReleased { get; }

        void Release();
        void Reuse();
    }
}