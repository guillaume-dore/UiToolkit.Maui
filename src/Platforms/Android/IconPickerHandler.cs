using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using System.Diagnostics;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler
{
	public static void MapSourceChanged(IconPickerHandler handler, IconPicker view) { Debug.WriteLine(nameof(MapSourceChanged)); }

	public static void MapStrokeThicknessChanged(IconPickerHandler handler, IconPicker view)
	{
		Debug.WriteLine(nameof(MapStrokeThicknessChanged));
		//if (handler.PlatformView.Background is LayerDrawable backgroundDrawable)
		//{
		//	GradientDrawable? borderDrawable = (GradientDrawable?)backgroundDrawable.FindDrawableByLayerId(backgroundDrawable.GetId(0));
		//	if (borderDrawable != null)
		//	{
		//		borderDrawable.Thickness = Convert.ToInt32(view.StrokeThickness);
		//	}
		//}
	}

	public static void MapStrokeChanged(IconPickerHandler handler, IconPicker view)
	{
		//if (handler.PlatformView.Background is LayerDrawable backgroundDrawable)
		//{
		//	GradientDrawable? borderDrawable = (GradientDrawable?)backgroundDrawable.FindDrawableByLayerId(backgroundDrawable.GetId(0));
		//	if (borderDrawable != null)
		//	{
		//		borderDrawable.SetStroke(borderDrawable.Thickness, view.Stroke?.ToPlatform() ?? Android.Graphics.Color.Black);
		//	}
		//}
		Debug.WriteLine(nameof(MapStrokeChanged));
	}

	public static void MapCornerRadiusChanged(IconPickerHandler handler, IconPicker view)
	{
		//if (handler.PlatformView.Background is LayerDrawable backgroundDrawable)
		//{
		//	GradientDrawable? borderDrawable = (GradientDrawable?)backgroundDrawable.FindDrawableByLayerId(backgroundDrawable.GetId(0));
		//	if (borderDrawable != null)
		//	{
		//		borderDrawable.SetCornerRadius(view.CornerRadius);
		//	}
		//}
		Debug.WriteLine(nameof(MapCornerRadiusChanged));
	}

	protected override void ConnectHandler(MauiPicker platformView)
	{
		base.ConnectHandler(platformView);

		IconPicker element = (IconPicker)VirtualView;

		GradientDrawable borderDrawable = new GradientDrawable();
		borderDrawable.SetShape(ShapeType.Rectangle);
		borderDrawable.SetPadding(10, 10, 10, 10);
		borderDrawable.SetCornerRadius(element.CornerRadius);
		borderDrawable.SetColor(ColorStateList.ValueOf(element.BackgroundColor?.ToPlatform() ?? Android.Graphics.Color.Transparent));
		borderDrawable.SetStroke(Convert.ToInt32(element.StrokeThickness), element.Stroke?.ToPlatform() ?? Android.Graphics.Color.Black);

		LayerDrawable layerDrawable = new([borderDrawable, GetImageSourceAsDrawable(element.Source).Result]);
		layerDrawable.SetLayerInset(0, 20, 0, 0, 0);

		platformView.Background = layerDrawable;
	}

	private async Task<Drawable> GetImageSourceAsDrawable(ImageSource source)
	{
		Drawable drawable;
		if (source is FontImageSource fontSource)
			drawable = new FontDrawable(Context, fontSource.Glyph, fontSource.Color.ToPlatform(), Convert.ToInt32(fontSource.Size), "MaterialIconsRound-Regular.otf"); // TODO: add font family and recover filename from font family
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
