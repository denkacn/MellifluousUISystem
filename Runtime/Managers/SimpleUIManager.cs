using MellifluousUI.Core.Comparators;
using MellifluousUI.Core.GroupWorkers;
using MellifluousUI.Core.Services;
using MellifluousUI.Core.Controllers;
using MellifluousUI.Core.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MellifluousUI.Core.Managers
{
    public class SimpleUIManager : MonoBehaviour
    {
        public static SimpleUIManager Inst;

        public IUIViewService ViewService => _viewService;
        
        private IUIViewService _viewService;
        private IUIViewsController _viewsController;
        
        private void Awake()
        {
            if (Inst == null)
            {
                Inst = this;
                DontDestroyOnLoad(this.gameObject);

                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.sceneUnloaded += OnSceneUnloaded;
                
                IUIViewComparator viewComparator = new UIViewComparator();

                _viewService = new UIViewService();
                _viewsController = new SimpleUIViewsController(_viewService);

                _viewService.Initialize();
                _viewService.SetComparator(viewComparator);
                _viewService.AddGroupWorker(UIGroupType.Screen, new SimpleUIViewGroupWorker(UIGroupType.Screen));

                _viewService.ViewHided += viewId => { Debug.Log("ViewHided: " + viewId.Name); };
                _viewService.ViewShowed += viewId => { Debug.Log("ViewShowed: " + viewId.Name); };
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            _viewsController.RemoveViews(scene.name);
        }

        public void StartUnloadingScenes()
        {
            //_viewsController.RemoveViews(SceneManager.GetActiveScene().name);
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            
            var viewProviders = FindObjectsByType<BaseUIViewProvider>(FindObjectsSortMode.None);
            foreach (var provider in viewProviders)
            {
                _viewsController.AddViews(scene.name, provider.GetViews());

                if (provider is IHasUIView hasDisplayingView)
                {
                    _viewService.Show(hasDisplayingView.View.ViewId, isHideAll: false);
                }
            }
            
            //Debug.Log("OpenedView: " + _viewService.OpenedView[0].Name);
        }
    }
}
