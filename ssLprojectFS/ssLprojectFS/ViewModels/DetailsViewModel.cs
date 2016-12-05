using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class DetailsViewModel : BaseViewModel
	{
		public Person PersonDetails { get; protected set; }
		public ICommand BackCommand { get; protected set; }
		protected NavigationPage navigationPage;

		public DetailsViewModel(NavigationPage navigationPage, int personId)
		{
			this.navigationPage = navigationPage;
			this.GetPersonsDetails(personId);

			this.BackCommand = new Command(async (nothing) =>
			{
				await this.navigationPage.PopAsync();
			});
		}

		private void GetPersonsDetails(int id)
		{
			this.PersonDetails = DependencyService.Get<IPersonFacade>().GetPersonInfoById(id);
			OnPropertyChanged("PersonDetails");
		}
	}
}
