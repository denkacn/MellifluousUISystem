using System.Collections.Generic;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.GroupWorkers
{
    public abstract class BaseUIViewGroupWorker : IUIGroupWorker
    {
        public UIGroupType GroupType { get; }
        
        protected IUIPresenter<BaseUIView> _current;
        protected readonly List<IUIPresenter<BaseUIView>> _presenters;
        protected readonly List<IUIPresenter<BaseUIView>> _showedPresenters;
        
        protected BaseUIViewGroupWorker(UIGroupType groupType)
        {
            GroupType = groupType;
            
            _presenters = new List<IUIPresenter<BaseUIView>>();
            _showedPresenters = new List<IUIPresenter<BaseUIView>>();
        }
        
        public void AddPresenter(IUIPresenter<BaseUIView> presenter)
        {
            _presenters.Add(presenter);
        }
        
        public void RemovePresenter(IUIPresenter<BaseUIView> presenter)
        {
            _presenters.Remove(presenter);
        }

        public bool IsCanShow(ViewId viewId)
        {
            return _presenters.Find(v => v.View.ViewId.Id == viewId.Id) != null;
        }

        public abstract void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = false);
        public abstract void Hide(ViewId viewId);
    }
}