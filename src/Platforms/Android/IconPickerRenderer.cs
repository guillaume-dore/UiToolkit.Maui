using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Controls.Platform;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui;

[Obsolete("This renderer is obsolete, it will be replaced in future release by corresponding handler/mapper")]
public class IconPickerRenderer(Context context) : PickerRenderer(context)
{
	IconPicker? element;

	protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
	{
		base.OnElementChanged(e);
		element = (IconPicker)this.Element;

		if (Control != null && this.Element != null && element.Source != null)
			Control.Background = SetPickerUi(element);
	}

	private LayerDrawable SetPickerUi(IconPicker element)
	{
		GradientDrawable border = new GradientDrawable();
		border.SetShape(ShapeType.Rectangle);
		border.SetPadding(10, 10, 10, 10);
		border.SetCornerRadius(element.CornerRadius);
		border.SetColor(ColorStateList.ValueOf(element.BackgroundColor?.ToAndroid() ?? Android.Graphics.Color.Transparent));
		border.SetStroke(Convert.ToInt32(element.StrokeThickness), element.Stroke?.ToAndroid() ?? Android.Graphics.Color.Black);

		LayerDrawable layerDrawable = new([border, GetDrawable(element.Source).Result]);
		layerDrawable.SetLayerInset(0, 20, 0, 0, 0);
		return layerDrawable;
	}

	private async Task<Drawable> GetDrawable(ImageSource source)
	{
		Drawable drawable;
		if (source is FontImageSource font)
			drawable = new FontDrawable(Context!, font.Glyph, font.Color.ToAndroid(), Convert.ToInt32(font.Size), "MaterialIconsRound-Regular.otf"); // TODO: add font family and recover filename from font family
		else
		{
			var renderer = new StreamImagesourceHandler();
			Bitmap bitmapImg = await renderer.LoadImageAsync(source, Context);
			drawable = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmapImg, 70, 70, true))
			{
				Gravity = GravityFlags.Right
			};
		}
		return drawable;
	}
}
