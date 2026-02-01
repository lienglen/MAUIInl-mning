
using MAUIInlämning.Models;
using MAUIInlämning.ViewModels;

namespace MAUIInlämning.Views;
public partial class DetailsPage : ContentPage
{
	
	public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();
		BindingContext = detailsViewModel;
    }
}