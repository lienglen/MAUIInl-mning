using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIInlämning.Models;
using MAUIInlämning.Services;
using MAUIInlämning.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIInlämning.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly APIBookService apiBookService;

        //Lista med böcker som kan observeras för ändringar
        [ObservableProperty]
        ObservableCollection<Book> books = new ObservableCollection<Book>();

        [ObservableProperty]
        private string searchText;

        [RelayCommand]
        public async Task Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                return;
            }

            await GetBooksAsync(SearchText);
        }


        public MainViewModel(APIBookService apiBookService)
        {
            this.apiBookService = apiBookService;
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await GetBooksAsync(SearchText);
        }

        
        public async Task GetBooksAsync(string query)
        {
            var booksFromApi = await apiBookService.GetBooksAsync(query);

            Books.Clear();
            foreach (var book in booksFromApi)
            {
                Books.Add(book);
            }
        }

        [RelayCommand]
        public async Task HandleNavigation(Book selectedBook) 
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedBook", selectedBook }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);

            selectedBook = null; // Återställ vald bok efter navigering
        }
    }
}
