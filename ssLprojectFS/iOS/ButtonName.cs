using ssLprojectFS.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ButtonName))]
namespace ssLprojectFS.iOS
{
	public class ButtonName : IButtonName
	{
		public string GetButtonName()
		{
			return "It's OK by IOS";
		}
	}
}
