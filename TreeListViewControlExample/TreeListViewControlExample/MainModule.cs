using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TreeListViewControlExample.ViewModels;
using TreeListViewControlExample.Views;

namespace TreeListViewControlExample
{
    public class MainModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("MainViewRegion", nameof(MainView).ToString());
            _regionManager.RequestNavigate("ObjectListRegion", nameof(ObjectListView).ToString());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<ObjectListView, ObjectListViewModel>();
        }
    }
}
