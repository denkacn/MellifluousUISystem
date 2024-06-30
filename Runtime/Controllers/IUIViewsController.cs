using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Controllers
{
    public interface IUIViewsController
    {
        void AddViews(string id, BaseUIView[] views);
        void RemoveViews(string id);
    }
}