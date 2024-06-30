using MellifluousUI.Core.Views;
using UnityEngine;

namespace MellifluousUI.Core.Providers
{
    public class FirstExistUIViewProvider : BaseUIViewProvider, IHasUIView
    {
        public BaseUIView View => _firstShowView;
        
        [SerializeField] private BaseUIView _firstShowView;
    }
}