using Prism.Mvvm;

namespace TreeListViewControlExample.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private string? _title;
        public string? Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ShellWindowViewModel()
        {
            Title = "Please help me make this TreeListControl work :(";
        }
    }
}
