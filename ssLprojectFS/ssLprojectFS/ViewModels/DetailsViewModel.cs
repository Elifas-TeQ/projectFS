using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class DetailsViewModel : BaseViewModel
	{
		public MobileLogModel LogDetails { get; protected set; }
		public ICommand BackCommand { get; protected set; }
		protected NavigationPage navigationPage;

		public DetailsViewModel(NavigationPage navigationPage, ILogFacade logFacade, int personId)
			: base(logFacade)
		{
			this.navigationPage = navigationPage;
			Task.Factory.StartNew(() => this.GetPersonsDetails(personId));

			this.BackCommand = new Command(async (nothing) =>
			{
				await this.navigationPage.PopAsync();
			});
		}

		private void GetPersonsDetails(int id)
		{
			this.ActivityIndicatorIsRunning = true;
			this.ActivityIndicatorIsVisible = true;

			this.LogDetails = this.logFacade.GetLogDetailsById(id);
			this.OnPropertyChanged("LogDetails");

			this.ActivityIndicatorIsRunning = false;
			this.ActivityIndicatorIsVisible = false;
		}
	}
}
