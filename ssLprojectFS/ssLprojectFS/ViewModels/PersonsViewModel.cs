using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class PersonsViewModel : BaseViewModel
	{
		public ICommand ShowDetailsCommand { get; protected set; }
		public ICommand LoadMoreCommand { get; protected set; }
		protected NavigationPage navigationPage;
		private ObservableCollection<MobileLogShortModel> logsList;
		private bool isButtonLoadMoreEnabled;

		public ObservableCollection<MobileLogShortModel> LogsList
		{
			get { return this.logsList; }
			set
			{
				this.logsList = value;
				this.OnPropertyChanged("LogsList");
			}
		}

		public bool IsButtonLoadMoreEnabled
		{
			get { return this.isButtonLoadMoreEnabled; }
			set {
				this.isButtonLoadMoreEnabled = value;
				this.OnPropertyChanged("IsButtonLoadMoreEnabled");
			}
		}

		public PersonsViewModel(NavigationPage navigationaPage, ILogFacade logFacade)
			: base(logFacade)

		{
			this.navigationPage = navigationaPage;
			Task.Factory.StartNew(() => this.GetLogsList());

			this.ShowDetailsCommand = new Command(async (item) =>
			{
				await this.navigationPage.PushAsync(new PersonDetailsPage(this.navigationPage, (item as MobileLogShortModel).Id));
			});

			this.LoadMoreCommand = new Command((nothing) =>
			{
				int countOfElementsInNextPart = 20;

				IEnumerable<MobileLogShortModel> nextPartOfLogsList = this.logFacade.GetNextPartOfLogsList(this.LogsList.Count, countOfElementsInNextPart);
				if (nextPartOfLogsList.ToList().Count < countOfElementsInNextPart)
				{
					this.IsButtonLoadMoreEnabled = false;
				}

				List<MobileLogShortModel> newLogsList = this.LogsList.ToList();
				newLogsList.AddRange(nextPartOfLogsList);
				this.LogsList = new ObservableCollection<MobileLogShortModel>(newLogsList);
			});
		}

		private void GetLogsList()
		{
			this.IsButtonLoadMoreEnabled = false;
			this.IsActivityIndicatorRunning = true;
			this.IsActivityIndicatorVisible = true;

			this.LogsList = new ObservableCollection<MobileLogShortModel>(this.logFacade.GetNextPartOfLogsList(0, 20));

			this.IsActivityIndicatorVisible = false;
			this.IsActivityIndicatorRunning = false;
			this.IsButtonLoadMoreEnabled = true;
		}
	}
}
