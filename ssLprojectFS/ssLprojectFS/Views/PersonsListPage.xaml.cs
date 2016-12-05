using Xamarin.Forms;

namespace ssLprojectFS
{
	public partial class PersonsListPage : ContentPage
	{
		public PersonsListPage(NavigationPage navigationPage)
		{
			InitializeComponent();
			BindingContext = new PersonsViewModel(navigationPage);
		}
	}
}
