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

		public DetailsViewModel(NavigationPage navigationPage, IPersonFacade personFacade, int personId)
			: base(personFacade)
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
			base.ActivityIndicatorIsRunning = true;
			base.ActivityIndicatorIsVisible = true;

			this.LogDetails = this.personFacade.GetPersonInfoById(id);
			OnPropertyChanged("LogDetails");

			base.ActivityIndicatorIsRunning = false;
			base.ActivityIndicatorIsVisible = false;
		}
	}
}
