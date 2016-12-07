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

		public PersonsViewModel(NavigationPage navigationaPage, IPersonFacade personFacade)
			: base(personFacade)

		{
			this.navigationPage = navigationaPage;
			Task.Factory.StartNew(() => this.GetLogsList());

			this.ShowDetailsCommand = new Command(async (item) =>
			{
				await this.navigationPage.PushAsync(new PersonDetailsPage(this.navigationPage, (item as MobileLogShortModel).Id));
			});
		}

		private void GetLogsList()
		{
			base.ActivityIndicatorIsRunning = true;
			base.ActivityIndicatorIsVisible = true;

			this.LogsList = this.personFacade.GetPersonsList();
			OnPropertyChanged("LogsList");

			base.ActivityIndicatorIsVisible = false;
			base.ActivityIndicatorIsRunning = false;
		}
	}
}
