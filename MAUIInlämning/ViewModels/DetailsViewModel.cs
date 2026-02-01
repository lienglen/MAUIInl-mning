using CommunityToolkit.Mvvm.ComponentModel;
using MAUIInlämning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIInlämning.ViewModels
{
    [QueryProperty("SelectedBook", "SelectedBook")] //Använder detta för att kunna skicka data mellan sidor
    public partial class DetailsViewModel : BaseViewModel
    {
        //Objektet för den valda boken
        [ObservableProperty]
        Book selectedBook;
    }
}
