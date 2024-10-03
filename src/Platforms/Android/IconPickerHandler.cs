using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler
{
	private new IconPicker VirtualView => (IconPicker?)base.VirtualView ?? throw new InvalidOperationException($"VirtualView cannot be null here");

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
		LayerDrawable layerDrawable = new([GetBorderDrawable(), GetImageSourceAsDrawable(VirtualView.Source).Result]);
		layerDrawable.SetLayerInset(0, 20, 0, 0, 0);
		PlatformView.Background = layerDrawable;
	}

	private GradientDrawable GetBorderDrawable()
	{
		IconPicker element = VirtualView;
		GradientDrawable borderDrawable = new GradientDrawable();
		borderDrawable.SetShape(ShapeType.Rectangle);
		borderDrawable.SetPadding(10, 10, 10, 10);
		borderDrawable.SetCornerRadius(element.CornerRadius);
		borderDrawable.SetColor(ColorStateList.ValueOf(element.BackgroundColor?.ToPlatform() ?? Android.Graphics.Color.Transparent));
		borderDrawable.SetStroke(Convert.ToInt32(element.StrokeThickness), element.Stroke?.ToPlatform() ?? Android.Graphics.Color.Black);
		return borderDrawable;
	}

	private async Task<Drawable> GetImageSourceAsDrawable(ImageSource source)
	{
		Drawable drawable;
		if (source is IFontImageSource fontSource)
		{
			IFontManager? fontManager = (IFontManager?)this.MauiContext?.Services.GetService<IFontManager>(); // get font manager service to handle font by name
			fontManager.GetTypeface(fontSource.Font);
			drawable = new FontDrawable(Context, fontSource.Glyph, fontSource.Color.ToPlatform(), Convert.ToInt32(((FontImageSource)fontSource).Size), "MaterialIconsRound-Regular.otf"); // TODO: add font family and recover filename from font family
		}
		else
		{
			var renderer = new StreamImagesourceHandler();
			Bitmap bitmapImg = await renderer.LoadImageAsync(source, Context);
			drawable = new BitmapDrawable(Context.Resources, Bitmap.CreateScaledBitmap(bitmapImg, 70, 70, true))
			{
				Gravity = GravityFlags.Right
			};
		}
		return drawable;
	}
}
