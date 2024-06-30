using System.Collections.Generic;
using System.Linq;
using MellifluousUI.Core.Services;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Controllers
{
    public class SimpleUIViewsController : IUIViewsController
    {
        private readonly IUIViewService _viewService;
        private readonly Dictionary<string, List<BaseUIView>> _viewsTable = new Dictionary<string, List<BaseUIView>>();
        
        public SimpleUIViewsController(IUIViewService viewService)
        {
            _viewService = viewService;
        }

        public void AddViews(string id, BaseUIView[] views)
        {
            if (!_viewsTable.TryGetValue(id, out var value))
            {
                _viewsTable.Add(id, views.ToList());
            }
            else
            {
                value.AddRange(views);
            }
            
            _viewService.AddViews(views);
        }
        
        public void RemoveViews(string id)
        {
            _viewService.RemoveViews(_viewsTable[id]);
            _viewsTable.Remove(id);
        }
    }
}