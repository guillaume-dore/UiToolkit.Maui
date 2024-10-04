using Microsoft.Maui.Platform;
using UIKit;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler
{
	protected override void ConnectHandler(MauiPicker platformView)
	{
		base.ConnectHandler(platformView);
		VirtualView.Loaded += OnLoaded;
	}

	protected override void DisconnectHandler(MauiPicker platformView)
	{
		VirtualView.Loaded -= OnLoaded;
		base.DisconnectHandler(platformView);
	}

	private void OnLoaded(object? sender, EventArgs e)
	{
		//PlatformView.BorderStyle = UITextBorderStyle.RoundedRect;
		//PlatformView.Layer.CornerRadius = 50;
		//PlatformView.BackgroundColor = UIKit.UIColor.Clear;
		//PlatformView.Layer.BorderWidth = 0;
		//PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
		//PlatformView.BackgroundColor = element.BackgroundColor?.ToPlatform() ?? UIColor.Clear;
		//PlatformView.Layer.BorderWidth = new(element.StrokeThickness);
		//PlatformView.Layer.BorderColor = element.Stroke?.ToPlatform()?.CGColor ?? UIColor.Black.CGColor;
		//PlatformView.Layer.MasksToBounds = false;
		//PlatformView.Layer.CornerRadius = element.CornerRadius;
		//PlatformView.BorderStyle = UITextBorderStyle.None;
		//PlatformView.BorderStyle = UITextBorderStyle.Line;
		//PlatformView.BackgroundColor = element.Stroke?.ToPlatform();
		//PlatformView.Layer.BorderWidth = 2;
		//PlatformView.Layer.BorderColor = element.Stroke?.ToPlatform().CGColor;
		//PlatformView.Layer.CornerRadius = element.CornerRadius;
		//PlatformView.Layer.MasksToBounds = true;
		//PlatformView.LayoutMargins = new UIEdgeInsets(10, 10, 10, 10);



		//PlatformView.BackgroundColor = UIKit.UIColor.Clear;
		//PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

		SetBorderLayer();
		PlatformView.RightViewMode = UITextFieldViewMode.Always;
		PlatformView.RightView = GetImageView();
	}

	private void SetBorderLayer()
	{
		//PlatformView.BackgroundColor = VirtualView.Stroke?.ToPlatform();
		PlatformView.Layer.BorderColor = UIKit.UIColor.Green.CGColor;
		PlatformView.Layer.MasksToBounds = true;
	}

	private UIImageView GetImageView()
	{
		UIImage icon;
		if (VirtualView.Source is IFontImageSource fontSource)
		{
			FontImageSource fontImageSource = (FontImageSource)fontSource as FontImageSource;
			icon = ImageHelper.ImageFromFont(fontSource.Glyph, fontSource.Color.ToPlatform(), new CoreGraphics.CGSize(fontImageSource.Size, fontImageSource.Size), FontManager.GetFont(fontSource.Font));
		}
		else
		{
			throw new NotImplementedException(); // Not yet implemented
		}
		return new UIImageView(icon);
	}
}
