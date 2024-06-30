using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Providers
{
    public interface IHasUIView
    {
        BaseUIView View { get; }
    }
}