using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Providers
{
    public interface IUIViewProvider
    {
        BaseUIView[] GetViews();
    }
}