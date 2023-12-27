using System.Collections.Generic;
using MellifluousUI.Core.Comparators;
using MellifluousUI.Core.GroupWorkers;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Services
{
    public interface IUIViewService
    {
        void Initialize();
        void SetComparator(IUIViewComparator comparator);
        void AddGroupWorker(UIGroupType groupType, IUIGroupWorker groupWorker);
        void AddViews(IEnumerable<BaseUIView> views);
        void AddView(BaseUIView view);
        void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = true);
        void Hide(ViewId viewId);
        /*void MoveForward(ViewId viewId, UIPayloadBase payload = null);
        void MoveBackward();*/
        void Discard(ViewId viewId);
    }
}