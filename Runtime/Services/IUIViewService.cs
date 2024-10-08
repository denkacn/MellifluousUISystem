using System;
using System.Collections.Generic;
using MellifluousUI.Core.Comparators;
using MellifluousUI.Core.GroupWorkers;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Views;
using MellifluousUI.Runtime.Loaders;

namespace MellifluousUI.Core.Services
{
    public interface IUIViewService
    {
        event Action<ViewId> ViewShowed;
        event Action<ViewId> ViewHided;
        
        List<ViewId> OpenedViews { get; }
        
        void Initialize();
        void SetComparator(IUIViewComparator comparator);
        void SetRuntimeLoader(IUIViewRuntimeLoader loader);
        
        void AddGroupWorker(UIGroupType groupType, IUIGroupWorker groupWorker);
        
        void AddViews(IEnumerable<BaseUIView> views);
        void RemoveViews(IEnumerable<BaseUIView> views);
        void AddView(BaseUIView view);
        void RemoveView(BaseUIView view);
        void RemoveRuntimeLoaded();
        void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = true);
        void Hide(ViewId viewId);
        void Discard(ViewId viewId);
    }
}