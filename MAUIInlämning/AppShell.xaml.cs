using MAUIInlämning.Views;

namespace MAUIInlämning
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Registrerar min detaljvy för navigation
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}
