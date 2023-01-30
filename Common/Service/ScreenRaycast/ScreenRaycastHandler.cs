using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Common.Service.ScreenRaycast
{
    class ScreenRaycastHandler
    {
        private readonly int _maxRaycastHits = 100;
        private readonly RaycastHit[] _raycastHits;

        private IScreenRaycastable _currentTarget;

        public ScreenRaycastHandler() =>
            _raycastHits = new RaycastHit[_maxRaycastHits];

        public void Cast(Ray ray)
        {
            int hits = Physics.RaycastNonAlloc(ray, _raycastHits, Mathf.Infinity);

            if (HasNoHits(hits))
                return;

            IScreenRaycastable screenRaycastable = GetScreenRaycastable(hits, _raycastHits);

            if (HasNoRaycastable(screenRaycastable))
                return;

            if (Input.GetMouseButtonDown(0))
                ApplyHit(screenRaycastable);

            Focus(screenRaycastable);
        }

        private bool HasNoHits(int hits)
        {
            if (hits != 0)
                return false;

            Blur();
            return true;
        }

        private bool HasNoRaycastable(IScreenRaycastable screenRaycastable)
        {
            if (screenRaycastable != null)
                return false;

            Blur();
            return true;
        }

        private void Blur()
        {
            _currentTarget?.Blur();
            _currentTarget = null;
        }

        private void ApplyHit(IScreenRaycastable screenRaycastable) =>
            screenRaycastable.Hit();

        private IScreenRaycastable GetScreenRaycastable(int hits, RaycastHit[] raycastHits)
        {
            for (int i = 0; i < hits; i++)
            {
                var raycastHit = raycastHits[i];

                if (raycastHit.collider.TryGetComponent<IScreenRaycastable>(out IScreenRaycastable screenRaycastable))
                    return screenRaycastable;
            }

            return null;
        }

        private void Focus(IScreenRaycastable screenRaycastable)
        {
            if (_currentTarget == screenRaycastable)
                return;

            Blur();
            _currentTarget = screenRaycastable;
            _currentTarget.Focus();
        }
    }
}