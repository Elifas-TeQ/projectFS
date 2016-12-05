using Xamarin.Forms;

namespace ssLprojectFS
{
	public partial class PersonDetailsPage : ContentPage
	{
		public PersonDetailsPage(NavigationPage navigationPage, int personId)
		{
			InitializeComponent();
			BindingContext = new DetailsViewModel(navigationPage, personId);
		}
	}
}
