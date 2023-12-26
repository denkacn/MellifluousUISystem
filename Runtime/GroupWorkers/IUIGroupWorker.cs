using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.GroupWorkers
{
    public interface IUIGroupWorker
    {
        void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = false);
        void Hide(ViewId viewId);
        void AddPresenter(IUIPresenter<BaseUIView> presenter);
    }
}