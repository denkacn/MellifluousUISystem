using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Resolvers
{
    public interface IUIViewResolver
    {
        IUIPresenter<BaseUIView> CompareT(BaseUIView item);
    }
}