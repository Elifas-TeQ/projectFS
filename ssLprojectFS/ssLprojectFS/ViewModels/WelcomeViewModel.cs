using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace ssLprojectFS
{
	public class WelcomeViewModel : BaseViewModel
	{
		public ICommand StartCommand { get; protected set; }
		protected NavigationPage navigationPage;
		public string ButtonNameProperty { get; protected set; }

		public WelcomeViewModel(NavigationPage navigationPage)
		{
			this.navigationPage = navigationPage;

			this.StartCommand = new Command(async (nothing) =>
			{
				await this.navigationPage.PushAsync(new PersonsListPage(navigationPage));
			});

			Device.BeginInvokeOnMainThread(() =>
			{
				this.ButtonNameProperty = DependencyService.Get<IButtonName>().GetButtonName();
				this.OnPropertyChanged("ButtonNameProperty");
			});

		}
	}
}
