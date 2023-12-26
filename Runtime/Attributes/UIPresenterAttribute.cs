using System;

namespace MellifluousUI.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UIPresenterAttribute : Attribute
    {
        public readonly Type PresenterType;

        public UIPresenterAttribute(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}