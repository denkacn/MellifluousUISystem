using System;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Views;
using UnityEngine;

namespace MellifluousUI.Core.Views
{
    public abstract class BaseUIView : MonoBehaviour, IUIView
    {
        public event Action CloseViewEventHandler;
        
        public bool IsShowed { get; private set; }
        public virtual ViewId ViewId { get; protected set; }
        
        public virtual void Show(Action onComplete)
        {
            gameObject.SetActive(true);
            IsShowed = true;
            
            onComplete?.Invoke();
        }

        public virtual void Hide(Action onComplete)
        {
            gameObject.SetActive(false);
            IsShowed = false;
            
            onComplete.Invoke();
        }

        public void OnClose() => CloseViewEventHandler?.Invoke();
    }
}
