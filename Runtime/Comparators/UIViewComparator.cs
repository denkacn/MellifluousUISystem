using System;
using MellifluousUI.Core.Attributes;
using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Comparators
{
    public static class UIViewComparator
    {
        public static IUIPresenter<BaseUIView> CompareT(BaseUIView item)
        {
            var attributeData = (UIPresenterAttribute)Attribute.GetCustomAttribute(item.GetType(), typeof(UIPresenterAttribute));
            var presenter = Activator.CreateInstance(attributeData.PresenterType);
            return (IUIPresenter<BaseUIView>) presenter;
        }
    }
}