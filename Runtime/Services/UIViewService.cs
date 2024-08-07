﻿using System;
using System.Collections.Generic;
using MellifluousUI.Core.Comparators;
using MellifluousUI.Core.GroupWorkers;
using MellifluousUI.Core.Models;
using MellifluousUI.Core.Payloads;
using MellifluousUI.Core.Presenters;
using MellifluousUI.Core.Views;

namespace MellifluousUI.Core.Services
{
    public class UIViewService : IUIViewService
    {
        public event Action<ViewId> ViewShowed;
        public event Action<ViewId> ViewHided;

        public List<ViewId> OpenedViews => new List<ViewId>(_openedViews);
        
        private List<IUIPresenter<BaseUIView>> _presenters;
        private IUIViewComparator _comparator = new UIViewComparator();

        private Dictionary<UIGroupType, IUIGroupWorker> _groupWorkers;

        private readonly List<ViewId> _openedViews = new List<ViewId>();
        
        public void Initialize()
        {
            _presenters = new List<IUIPresenter<BaseUIView>>();
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
        
        public void RemoveViews(IEnumerable<BaseUIView> views)
        {
            foreach (var view in views)
            {
                RemoveView(view);
            }
        }

        public void SetComparator(IUIViewComparator comparator)
        {
            _comparator = comparator;
        }
        
        public void AddView(BaseUIView view)
        {
            //Debug.Log(view.ViewId);
            
            var presenter = _comparator.CompareT(view);
            presenter.ShowEventHandler += OnShowView;
            presenter.HideEventHandler += OnHideView;
            presenter.Init(view, this);
                
            //Debug.Log(presenter.GetType());
            //Debug.Log(presenter.View.GetType());
                
            _presenters.Add(presenter);
            
            _groupWorkers[view.ViewId.GroupType].AddPresenter(presenter);
        }

        public void RemoveView(BaseUIView view)
        {
            var presenter = _presenters.Find(p => p.View.ViewId == view.ViewId);
            
            if (presenter != null)
            {
                presenter.Hide();
                presenter.Discard();
                presenter.ShowEventHandler -= OnShowView;
                presenter.HideEventHandler -= OnHideView;
                
                _presenters.Remove(presenter);
                _groupWorkers[view.ViewId.GroupType].RemovePresenter(presenter);
            }
        }

        public void Show(ViewId viewId, UIPayloadBase payload = null, bool isHideAll = true)
        {
            _groupWorkers[viewId.GroupType].Show(viewId, payload, isHideAll);
        }

        public void Hide(ViewId viewId)
        {
            _groupWorkers[viewId.GroupType].Hide(viewId);
        }

        public void Discard(ViewId viewId)
        {
            var presenter = _presenters.Find(v => v.View.ViewId.Id == viewId.Id);
            if (presenter != null)
            {
                presenter.ShowEventHandler -= OnShowView;
                presenter.HideEventHandler -= OnHideView;
                presenter.Hide();
                presenter.Discard();
            }
        }

        private void OnHideView(ViewId viewId)
        {
            _openedViews.RemoveAll(v=>v.Id == viewId.Id);
            
            ViewHided?.Invoke(viewId);
        }

        private void OnShowView(ViewId viewId)
        {
            _openedViews.Add(viewId);
            
            ViewShowed?.Invoke(viewId);
        }
    }
}