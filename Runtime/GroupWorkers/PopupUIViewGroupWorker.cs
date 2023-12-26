using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;

namespace MellifluousUI.Core.GroupWorkers
{
    public class PopupUIViewGroupWorker : SimpleUIViewGroupWorker
    {
        public PopupUIViewGroupWorker(UIGroupType groupType) : base(groupType){}

        public override void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = false)
        {
            _current?.Hide();

            base.Show(viewId, payload, isHideAll);
        }
    }
}