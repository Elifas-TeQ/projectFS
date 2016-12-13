using Xamarin.Forms;
using System.Windows.Input;
using System.IO;
using System.Text;

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
			this.stream = new MemoryStream();

			this.StartCommand = new Command(async (nothing) =>
			{
				await this.navigationPage.PushAsync(new PersonsListPage(navigationPage));
			});

			this.ButtonNameProperty = DependencyService.Get<IButtonName>().GetButtonName();
			this.OnPropertyChanged("ButtonNameProperty");

			this.SerializeIntoMemory();
			this.DeserializeFromMemory();
			this.OnPropertyChanged("Smth");
		}

		private readonly MemoryStream stream;

		public string Smth
		{
			get { return smth; }
			protected set { smth = value; }
		}

		private string smth;

		private void SerializeIntoMemory()
		{
			smth = "erbhonergp;erg";

			var smthBytes = Encoding.UTF8.GetBytes(smth);

			stream.Write(smthBytes, 0, smthBytes.Length);

			smth = "...";
		}

		private void DeserializeFromMemory()
		{
			byte[] smthBytes = new byte[stream.Length];

			stream.Position = 0;

			stream.Read(smthBytes, 0, smthBytes.Length);

			smth = new string(Encoding.UTF8.GetChars(smthBytes));
		}

	}
}
