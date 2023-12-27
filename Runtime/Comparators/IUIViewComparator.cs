using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Comparators
{
    public interface IUIViewComparator
    {
        IUIPresenter<BaseUIView> CompareT(BaseUIView item);
    }
}