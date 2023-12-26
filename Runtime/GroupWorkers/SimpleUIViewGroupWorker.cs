using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;

namespace MellifluousUI.Core.GroupWorkers
{
    public class SimpleUIViewGroupWorker : BaseUIViewGroupWorker
    {
        public SimpleUIViewGroupWorker(UIGroupType groupType) : base(groupType){}

        public override void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = false)
        {
            if (isHideAll) HideAll();
            
            var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null && !presenter.View.IsShowed)
            {
                presenter.Show(payload);
                
                _showedPresenters.Add(presenter);
                
                _current = presenter;
            }
        }

        public override void Hide(ViewId viewId)
        {
            var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null)
            {
                presenter.Hide();

                _showedPresenters.RemoveAll(p => p.View.ViewId.Id == viewId.Id);
            }
        }
        
        private void HideAll()
        {
            foreach (var presenter in _showedPresenters)
            {
                presenter.Hide();
            }
            
            _showedPresenters.Clear();
        }
    }
}