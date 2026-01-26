using MAUIInlämning.ViewModels;

namespace MAUIInlämning
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly MainViewModel _mainViewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            BindingContext = mainViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _mainViewModel.GetBooksAsync();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
