using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ssLprojectFS
{
	public class PersonsViewModel : BaseViewModel
	{
		public List<PersonName> PersonsList { get; protected set; }
		public ICommand ShowDetailsCommand { get; protected set; }
		protected NavigationPage navigationPage;

		public PersonsViewModel(NavigationPage navigationaPage)
		{
			this.navigationPage = navigationaPage;
			this.GetPersonsList();

			this.ShowDetailsCommand = new Command(async (item) =>
			{
				await this.navigationPage.PushAsync(new PersonDetailsPage(this.navigationPage, (item as PersonName).Id));
			});
		}

		private void GetPersonsList()
		{
			this.PersonsList = DependencyService.Get<IPersonFacade>().GetPersonsList();
			OnPropertyChanged("PersonsList");
		}
	}
}
