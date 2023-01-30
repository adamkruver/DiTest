using System;
using Common.Interfaces;
using Modules.LiveData;
using UnityEngine;
using UnityEngine.UIElements;

namespace Common.UIDocument
{
    [RequireComponent(typeof(UnityEngine.UIElements.UIDocument))]
    public abstract class AbstractUIDocument : MonoBehaviour, ISwitchable
    {
        private readonly MutableLiveData<bool> _isEnabled = new MutableLiveData<bool>(true);

        protected VisualElement Root { get; private set; }

        public LiveData<bool> IsEnabled => _isEnabled;

        private void Awake()
        {
            Root = GetComponent<UnityEngine.UIElements.UIDocument>().rootVisualElement;
            OnAwake();
            Disable();
        }

        public void Enable()
        {
            if (_isEnabled.Value)
                return;

            Root.style.display = DisplayStyle.Flex;
            _isEnabled.Value = true;
        }

        public void Disable()
        {
            if (_isEnabled.Value == false)
                return;

            Root.style.display = DisplayStyle.None;
            _isEnabled.Value = false;
        }

        protected virtual void OnAwake()
        {
        }

        protected void RegisterButtonClickHandler(string selector, EventCallback<ClickEvent> clickHandler)
        {
            var button = Root.Q<Button>(selector) ??
                         throw new NullReferenceException($"{GetType()}: button with selector '{selector}' not found");

            button.RegisterCallback(clickHandler);
        }

        protected Label GetLabel(string selector) =>
            Root.Q<Label>(selector) ??
            throw new NullReferenceException($"{GetType()}: label with selector '{selector}' not found");
    }
}