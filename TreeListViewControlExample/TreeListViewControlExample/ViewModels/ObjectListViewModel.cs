using System.Collections.ObjectModel;
using EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using System.Threading.Tasks;
using Prism.Regions;
using System.Windows;

namespace TreeListViewControlExample.ViewModels
{
    public class ObjectListViewModel : BindableBase, INavigationAware
    {
        private readonly DbContext _dbContext;

        private ObservableCollection<ObjectCollectionDTO>? _itemList;

        public ObservableCollection<ObjectCollectionDTO>? ItemList
        {
            get { return _itemList; }
            set { SetProperty(ref _itemList, value); }
        }

        public ObjectListViewModel(DbContext dbContext)
        {
            _dbContext = dbContext;

            ItemList = new ObservableCollection<ObjectCollectionDTO>();
        }

        private async Task LoadDataAsync()
        {
            var objectCollections = await _dbContext.Set<ObjectCollectionDTO>()
                .Include(oc => oc.ProjectList)
                .ToListAsync();

            var projectCollection = await _dbContext.Set<ProjectDTO>()
                .Include(p => p.ProjectList)
                .Include(s => s.SessionList)
                .Include(t => t.TaskList)
                .ToListAsync();

            var sessionCollection = await _dbContext.Set<SessionDTO>()
                .Include(p => p.ProjectList)
                .Include(s => s.SessionList)
                .Include(t => t.TaskList)
                .ToListAsync();

            var taskCollection = await _dbContext.Set<TaskDTO>()
                .Include(p => p.ProjectList)
                .Include(s => s.SessionList)
                .Include(t => t.TaskList)
                .ToListAsync();

            ItemList = new ObservableCollection<ObjectCollectionDTO>(objectCollections);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            LoadDataAsync()
                .ContinueWith(
                    t =>
                    {
                        if(t.Exception != null)
                        {
                            MessageBox.Show(t.Exception.Message);
                        }
                    },
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) { return true; }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
