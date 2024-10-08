using System.Threading.Tasks;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Runtime.Loaders
{
    public interface IUIViewRuntimeLoader
    {
        Task<BaseUIView> Load(ViewId viewId);
    }
}