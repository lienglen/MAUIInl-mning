using MAUIInlämning.Models;
using MAUIInlämning.Services;
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
    }
}
