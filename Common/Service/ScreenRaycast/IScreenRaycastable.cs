using UnityEngine;

namespace Assets.Common.Service.ScreenRaycast
{
    public interface IScreenRaycastable
    {
        void Focus();
        void Blur();
        void Hit();
    }
}