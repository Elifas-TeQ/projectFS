using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace ssLprojectFS
{
	public partial class PersonDetailsPage : ContentPage
	{
		public PersonDetailsPage(NavigationPage navigationPage, int personId)
		{
			InitializeComponent();
			var personFacade = ServiceLocator.Current.GetInstance<IPersonFacade>();
			BindingContext = new DetailsViewModel(navigationPage, personFacade, personId);
		}
	}
}
