using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class PersonsViewModel : BaseViewModel
	{
		public List<MobileLogShortModel> LogsList { get; protected set; }
		public ICommand ShowDetailsCommand { get; protected set; }
		protected NavigationPage navigationPage;

		public PersonsViewModel(NavigationPage navigationaPage, ILogFacade logFacade)
			: base(logFacade)

		{
			this.navigationPage = navigationaPage;
			Task.Factory.StartNew(() => this.GetLogsList());
//			Device.BeginInvokeOnMainThread(() => this.GetLogsList());

			this.ShowDetailsCommand = new Command(async (item) =>
			{
				await this.navigationPage.PushAsync(new PersonDetailsPage(this.navigationPage, (item as MobileLogShortModel).Id));
			});
		}

		private void GetLogsList()
		{
			this.ActivityIndicatorIsRunning = true;
			this.ActivityIndicatorIsVisible = true;

			this.LogsList = this.logFacade.GetLogsList();
			this.OnPropertyChanged("LogsList");

			this.ActivityIndicatorIsVisible = false;
			this.ActivityIndicatorIsRunning = false;
		}
	}
}
