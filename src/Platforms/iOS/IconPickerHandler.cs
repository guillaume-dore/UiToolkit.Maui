using Microsoft.Maui.Platform;
using UIKit;
using UiToolkit.Maui.Controls;

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
		IconPicker element = VirtualView;
		PlatformView.BackgroundColor = element.BackgroundColor?.ToPlatform() ?? UIColor.Clear;
		PlatformView.Layer.BorderWidth = new(element.StrokeThickness);
		PlatformView.Layer.BorderColor = element.Stroke?.ToPlatform()?.CGColor ?? UIColor.Black.CGColor;
		PlatformView.Layer.MasksToBounds = false;
		PlatformView.Layer.CornerRadius = element.CornerRadius;
		PlatformView.BorderStyle = UITextBorderStyle.None;

		UIImage icon;
		if (element.Source is IFontImageSource fontSource)
		{
			FontImageSource fontImageSource = (FontImageSource)fontSource as FontImageSource;
			IFontManager fontManager = MauiContext?.Services.GetService<IFontManager>() ?? throw new InvalidOperationException($"IFontManager service cannot be null here");
			icon = ImageHelper.ImageFromFont(fontSource.Glyph, fontSource.Color.ToPlatform(), new CoreGraphics.CGSize(fontImageSource.Size, fontImageSource.Size), fontManager.GetFont(fontSource.Font));
		}
		else
		{
			throw new NotImplementedException(); // Not yet implemented
		}
		PlatformView.RightViewMode = UITextFieldViewMode.Always;
		PlatformView.RightView = new UIImageView(icon);
	}
}
