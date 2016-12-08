using ssLprojectFS.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ButtonName))]
namespace ssLprojectFS.Droid
{
	public class ButtonName : IButtonName
	{
		public string GetButtonName()
		{
			return "It's OK by Android";
		}
	}
}
