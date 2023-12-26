using System;
using MellifluousUI.Core.GroupWorkers;

namespace MellifluousUI.Core.Models
{
    public class ViewId
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly UIGroupType GroupType;

        public ViewId(string name, UIGroupType groupType)
        {
            Id = Guid.NewGuid();
            Name = name;
            GroupType = groupType;
        }
    }
}