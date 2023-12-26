using System.Collections.Generic;
using MellifluousUI.Core.Comparators;
using MellifluousUI.Core.GroupWorkers;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;
using UnityEngine;

namespace MellifluousUI.Core.Services
{
    public class UIViewService : IUIViewService 
    {
        private List<IUIPresenter<BaseUIView>> _presenters;
        //private Stack<IUIPresenter<BaseUIView>> _opened;
        //private IUIPresenter<BaseUIView> _current;

        private Dictionary<UIGroupType, IUIGroupWorker> _groupWorkers;
        
        public void Initialize()
        {
            _presenters = new List<IUIPresenter<BaseUIView>>();
            //_opened = new Stack<IUIPresenter<BaseUIView>>();
            _groupWorkers = new Dictionary<UIGroupType, IUIGroupWorker>();
        }
        
        public void AddGroupWorker(UIGroupType groupType, IUIGroupWorker groupWorker)
        {
            if (!_groupWorkers.TryAdd(groupType, groupWorker)) return;
        }

        public void AddViews(IEnumerable<BaseUIView> views)
        {
            foreach (var view in views)
            {
                AddView(view);
            }
        }
        
        public void AddView(BaseUIView view)
        {
            var presenter = UIViewComparator.CompareT(view);
            presenter.HideEventHandler += OnHideView;
            presenter.Init(view, this);
                
            Debug.Log(presenter.GetType());
            Debug.Log(presenter.View.GetType());
                
            _presenters.Add(presenter);
            
            _groupWorkers[view.ViewId.GroupType].AddPresenter(presenter);
        }

        public void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = true)
        {
            _groupWorkers[viewId.GroupType].Show(viewId, payload, isHideAll);
            
            /*var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null && !presenter.View.IsShowed)
            {
                presenter.Show(payload);
                _current = presenter;
            }
            
            _opened.Clear();*/
        }
        
        /*public void MoveForward(ViewId viewId, UIPayloadBase payload = null)
        {
            var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null && !presenter.View.IsShowed)
            {
                presenter.Show(payload);
                _opened.Push(presenter);
                //_current = presenter;
            }
        }
        
        public void MoveBackward()
        {
            if (_opened.Count > 1)
            {
                var presenterToHide = _opened.Pop();
                presenterToHide.Hide();
                
                var presenterToShow = _opened.Peek();
                presenterToShow.Show(null);
                //_current = presenterToShow;
            }
        }*/

        public void Hide(ViewId viewId)
        {
            _groupWorkers[viewId.GroupType].Hide(viewId);
            
            /*var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null)
            {
                presenter.Hide();
            }*/
        }

        public void Discard(ViewId viewId)
        {
            var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null)
            {
                presenter.HideEventHandler -= OnHideView;
                presenter.Hide();
                presenter.Discard();
            }
        }
        
        private void OnHideView(ViewId viewId)
        {
            
        }
    }
}