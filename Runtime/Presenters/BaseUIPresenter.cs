using System;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Services;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Presenters
{
    public abstract class BaseUIPresenter<TView> : IUIPresenter<TView>, IDisposable where TView : BaseUIView
    {
        public event Action<ViewId> ShowEventHandler;
        public event Action<ViewId> HideEventHandler;
        
        public TView View => GetView<TView>();
        public ViewId ViewId => _viewId;//View.ViewId;
        
        protected IUIViewService ViewService;
        
        private BaseUIView _view;
        private IUIPayload _payload;
        private ViewId _viewId;

        public void Init(BaseUIView view, IUIViewService viewService)
        {
            _view = view;
            _viewId = _view.ViewId;
            
            ViewService = viewService;
        }

        public void Show(IUIPayload payload)
        {
            _payload = payload;
            
            OnShowStarted();
            
            _view.Show(OnShowEnded);
            
            ShowEventHandler?.Invoke(_viewId);
        }

        public void Hide(Action onComplete = null)
        {
            OnHideStarted();

            if (_view != null)
            {
                _view.Hide(() =>
                {
                    OnHideEnded();
                    Dispose();
                
                    onComplete?.Invoke();
                });
            }
            
            HideEventHandler?.Invoke(_viewId);
        }
        
        public virtual void Dispose(){}

        public virtual void Discard(){}

        protected TView GetView<TView>() where TView : BaseUIView
        {
            var v = _view as TView;
            return v;
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