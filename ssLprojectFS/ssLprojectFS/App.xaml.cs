using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;

namespace ssLprojectFS
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var container = new UnityContainer();
			this.RegisterTypes(container);
			var locator = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => locator);

			var navigationPage = new NavigationPage();
			var welcomePage = new WelcomePage(navigationPage);
			navigationPage.PushAsync(welcomePage);

			MainPage = navigationPage;
		}

		private void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IService, Service>(new ContainerControlledLifetimeManager());
			container.RegisterType<ILogFacade, LogFacade>(new InjectionConstructor(typeof(IService)));
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
