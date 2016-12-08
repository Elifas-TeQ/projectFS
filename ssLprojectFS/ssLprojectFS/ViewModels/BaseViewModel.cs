using System;
using System.ComponentModel;

namespace ssLprojectFS
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected ILogFacade logFacade;

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

		private bool activityIndicatorIsRunning;
		public bool ActivityIndicatorIsRunning
		{
			protected set
			{
				this.activityIndicatorIsRunning = value;
				OnPropertyChanged("ActivityIndicatorIsRunning");
			}
			get
			{
				return this.activityIndicatorIsRunning;
			}
		}

		private bool activityIndicatorIsVisible;
		public bool ActivityIndicatorIsVisible
		{
			protected set
			{
				this.activityIndicatorIsVisible = value;
				OnPropertyChanged("ActivityIndicatorIsVisible");
			}
			get
			{
				return this.activityIndicatorIsRunning;
			}
		}
	}
}
