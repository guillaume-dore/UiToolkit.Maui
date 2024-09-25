using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Controls.Platform;
using UiToolkit.Maui.Controls;
using ShapeDrawable = Android.Graphics.Drawables.ShapeDrawable;
using Android.Graphics.Drawables.Shapes;

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
			Control.Background = AddPickerImage(element.Source);
	}

	private LayerDrawable AddPickerImage(ImageSource source)
	{
		ShapeDrawable border = new ShapeDrawable();
		border.Paint!.Color = Android.Graphics.Color.Black;
		border.SetPadding(10, 10, 10, 10);
		border.Shape = new RoundRectShape(Enumerable.Repeat(40f, 8).ToArray(), null, null);
		border.Paint.SetStyle(Android.Graphics.Paint.Style.Stroke);

		LayerDrawable layerDrawable = new([border, GetDrawable(source).Result]);
		layerDrawable.SetLayerInset(0, 0, 0, 0, 0);
		return layerDrawable;
	}

	private async Task<Drawable> GetDrawable(ImageSource source)
	{
		Drawable drawable;
		if (source is FontImageSource font)
			drawable = new FontDrawable(Context!, font.Glyph, Android.Graphics.Color.Black, Convert.ToInt32(font.Size), "MaterialIconsRound-Regular.otf"); // TODO: add font family and recover filename from font family
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
