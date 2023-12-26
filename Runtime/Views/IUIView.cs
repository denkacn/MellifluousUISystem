using System;
using MellifluousUI.Core.Models;

namespace MellifluousUI.Core.Views
{
    public interface IUIView
    {
        ViewId ViewId { get; }
        bool IsShowed { get; } 
        void Show(Action onComplete);
        void Hide(Action onComplete);
    }
}