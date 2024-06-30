using MellifluousUI.Core.Views;
using UnityEngine;

namespace MellifluousUI.Core.Providers
{
    public class BaseUIViewProvider : MonoBehaviour, IUIViewProvider
    {
        [SerializeField] private Transform _viewsContainer;

        public BaseUIView[] GetViews()
        {
            return _viewsContainer.GetComponentsInChildren<BaseUIView>(true);
        }
    }
}