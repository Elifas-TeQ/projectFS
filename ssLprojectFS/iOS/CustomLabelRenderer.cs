using UIKit;
using Xamarin.Forms;
using ssLprojectFS.iOS;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace ssLprojectFS.iOS
{
	public class CustomLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.TextColor = UIColor.FromRGB(0, 0, 255);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control != null)
			{
				Control.TextColor = UIColor.FromRGB(0, 0, 255);
			}
		}
	}
}
