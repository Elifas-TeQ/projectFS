using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace ssLprojectFS
{
	public partial class PersonDetailsPage : ContentPage
	{
		public PersonDetailsPage(NavigationPage navigationPage, int personId)
		{
			InitializeComponent();
			var logFacade = ServiceLocator.Current.GetInstance<ILogFacade>();
			BindingContext = new DetailsViewModel(navigationPage, logFacade, personId);
		}
	}
}
