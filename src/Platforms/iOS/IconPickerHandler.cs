using CoreGraphics;
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
		SetBorderLayer();
		PlatformView.RightViewMode = PlatformView.LeftViewMode = UITextFieldViewMode.Always;
		PlatformView.RightView = GetImageView();
		PlatformView.LeftView = new(new CGRect(0, 0, PlatformView.RightView.Bounds.Size.Width + 5, PlatformView.RightView.Bounds.Size.Height));
	}

	private void SetBorderLayer()
	{
		PlatformView.Layer.CornerCurve = CoreAnimation.CACornerCurve.Circular;
		PlatformView.Layer.CornerRadius = VirtualView.CornerRadius / UIScreen.MainScreen.NativeScale;
		PlatformView.Layer.BorderWidth = new nfloat(VirtualView.StrokeThickness) / UIScreen.MainScreen.NativeScale;
		PlatformView.Layer.BorderColor = VirtualView.Stroke?.ToPlatform().CGColor;
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
		return new UIImageView(icon.CreateResizableImage(new UIEdgeInsets(0, 0, 0, -5)))
		{
			ContentMode = UIViewContentMode.ScaleAspectFit
		};
	}
}
