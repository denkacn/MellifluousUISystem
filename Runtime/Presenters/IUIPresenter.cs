using System;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Services;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Presenters
{
    public interface IUIPresenter <out TView>
    {
        event Action ShowEventHandler;
        event Action<ViewId> HideEventHandler;
        
        TView View { get; }
        void Init(BaseUIView view, IUIViewService viewService);
        void Show(IUIPayload payload);
        void Hide(Action onComplete = null);
        void Discard();
    }
}