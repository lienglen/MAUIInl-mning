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
    public class MainViewModel : BaseViewModel
    {
        private readonly APIBookService apiBookService;

        //Lista med böcker
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

        public MainViewModel(APIBookService apiBookService)
        {
            this.apiBookService = apiBookService;
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await GetBooksAsync();
        }

        public async Task GetBooksAsync()
        {
            var booksFromApi = await apiBookService.GetBooksAsync();

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
