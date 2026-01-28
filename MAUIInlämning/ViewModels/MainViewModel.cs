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

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                // Undvik onödig navigering om samma bok väljs igen
                if (value == selectedBook) return;

                selectedBook = value;
                OnPropertyChanged();

                if (selectedBook != null)
                {
                    // Navigera till detaljsidan med den valda boken
                    HandleNavigation(selectedBook);
                }
            }
        }

        public async void HandleNavigation(Book book) 
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedBook", book }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);

            SelectedBook = null; // Återställ vald bok efter navigering
        }
    }
}
