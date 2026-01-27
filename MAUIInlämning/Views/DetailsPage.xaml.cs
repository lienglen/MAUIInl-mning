
using MAUIInlämning.Models;

namespace MAUIInlämning.Views;

[QueryProperty(nameof(CurrentBook), "SelectedBook")]
public partial class DetailsPage : ContentPage
{
	private Book currentBook;

	public Book CurrentBook
	{
		get => currentBook;
		
		
		set 
		{ 
			currentBook = value;
			OnPropertyChanged();
			BindingContext = currentBook;
        }
	}


	public DetailsPage()
	{
		InitializeComponent();
	}
}