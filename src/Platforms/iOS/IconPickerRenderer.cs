using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using UIKit;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui;

[Obsolete("This renderer is obsolete, it will be replaced in future release by corresponding handler/mapper")]
public class IconPickerRenderer : PickerRenderer
{
	protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
	{
		base.OnElementChanged(e);

		var element = (IconPicker)this.Element;

		if (this.Control != null && this.Element != null && element.Source != null)
		{
			UIImage icon;
			if (element.Source is FontImageSource font)
				icon = ImageHelper.ImageFromFont(font.Glyph, UIColor.Black, new CoreGraphics.CGSize(font.Size, font.Size), "MaterialIconsRound");
			else
			{
				throw new NotImplementedException();
			}
			Control.RightViewMode = UITextFieldViewMode.Always;
			Control.RightView = new UIImageView(icon);
		}
	}
}
