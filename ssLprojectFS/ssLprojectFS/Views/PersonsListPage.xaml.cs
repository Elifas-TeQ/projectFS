using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace ssLprojectFS
{
	public partial class PersonsListPage : ContentPage
	{
		public PersonsListPage(NavigationPage navigationPage)
		{
			InitializeComponent();
			var personFacade = ServiceLocator.Current.GetInstance<IPersonFacade>();
			BindingContext = new PersonsViewModel(navigationPage, personFacade);
		}
	}
}
