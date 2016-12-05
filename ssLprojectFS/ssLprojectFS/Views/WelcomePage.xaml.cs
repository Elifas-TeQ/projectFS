using Xamarin.Forms;

namespace ssLprojectFS
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage(NavigationPage navigationPage)
		{
			InitializeComponent();
			BindingContext = new WelcomeViewModel(navigationPage);
		}
	}
}
