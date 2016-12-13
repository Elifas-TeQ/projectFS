using System.ComponentModel;

namespace ssLprojectFS
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected ILogFacade logFacade;

		private bool isActivityIndicatorRunning;
		private bool isActivityIndicatorVisible;

		public bool IsActivityIndicatorRunning
		{
			protected set
			{
				this.isActivityIndicatorRunning = value;
				OnPropertyChanged("IsActivityIndicatorRunning");
			}
			get
			{
				return this.isActivityIndicatorRunning;
			}
		}

		public bool IsActivityIndicatorVisible
		{
			protected set
			{
				this.isActivityIndicatorVisible = value;
				OnPropertyChanged("IsActivityIndicatorVisible");
			}
			get
			{
				return this.isActivityIndicatorVisible;
			}
		}

		public BaseViewModel() { }

		public BaseViewModel(ILogFacade logFacade)
		{
			this.logFacade = logFacade;
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
