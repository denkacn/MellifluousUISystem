using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;

namespace MellifluousUI.Core.GroupWorkers
{
    public class PopupUIViewGroupWorker : SimpleUIViewGroupWorker
    {
        public PopupUIViewGroupWorker(UIGroupType groupType) : base(groupType){}

        public override void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = false)
        {
            if (_current != null && _current.View.IsShowed) _current?.Hide();

            base.Show(viewId, payload, isHideAll);
        }
    }
}