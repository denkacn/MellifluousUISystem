using System;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Services;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Presenters
{
    public abstract class BaseUIPresenter<TView> : IUIPresenter<TView> where TView : BaseUIView
    {
        public event Action ShowEventHandler;
        public event Action<ViewId> HideEventHandler;
        
        public TView View => GetView<TView>();
        public ViewId ViewId => View.ViewId;
        
        protected IUIViewService ViewService;
        
        private BaseUIView _view;
        private IUIPayload _payload;

        public void Init(BaseUIView view, IUIViewService viewService)
        {
            _view = view;
            ViewService = viewService;
        }

        public void Show(IUIPayload payload)
        {
            _payload = payload;
            
            OnShowStarted();
            
            _view.Show(OnShowEnded);
            
            ShowEventHandler?.Invoke();
        }

        public void Hide()
        {
            OnHideStarted();
            
            _view.Hide(OnHideEnded);
            
            HideEventHandler?.Invoke(_view.ViewId);
        }

        public virtual void Discard(){}

        protected TView GetView<TView>() where TView : BaseUIView
        {
            return _view as TView;
        }
        
        protected TData GetPayload<TData>() where TData : UIPayloadBase
        {
            return _payload as TData;
        }

        protected virtual void OnShowStarted(){}
        protected virtual void OnShowEnded(){}
        protected virtual void OnHideStarted(){}
        protected virtual void OnHideEnded(){}
    }
}