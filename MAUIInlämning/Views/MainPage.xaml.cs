using MAUIInlämning.ViewModels;

namespace MAUIInlämning
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _mainViewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            BindingContext = mainViewModel;
            mainViewModel.Title = "Book Library";
        }

      
      
    }
}
