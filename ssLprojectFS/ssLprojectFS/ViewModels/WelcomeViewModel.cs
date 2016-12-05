using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class WelcomeViewModel : BaseViewModel
	{
		public ICommand StartCommand { get; protected set; }
		protected NavigationPage navigationPage;

		public WelcomeViewModel(NavigationPage navigationPage)
		{
			this.navigationPage = navigationPage;

			this.StartCommand = new Command(async (nothing) =>
			{
				await this.navigationPage.PushAsync(new PersonsListPage(navigationPage));
			});
		}
	}
}
