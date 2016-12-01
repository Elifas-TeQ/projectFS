using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public partial class WelcomePage : ContentPage
	{
		public ICommand StartCommand { private set; get; }

		public WelcomePage()
		{
			InitializeComponent();

			this.StartCommand = new Command(() =>
			{
				Navigation.PushAsync(new PersonsListPage());
			});
		}
	}
}
