using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;

namespace UiToolkit.Maui;

internal class FontDrawable : Drawable
{
	private int alpha = 255;
	private int size;
	private string text;
	private readonly TextPaint paint = new TextPaint();

	public override int IntrinsicWidth => this.size;

	public override int IntrinsicHeight => this.size;

	public override bool IsStateful => true;

	public override int Opacity => this.alpha;

	public FontDrawable(Context context, string text, Android.Graphics.Color iconColor, int iconSizeDP, string font = "ionicons.ttf")
	{
		this.text = text;

		this.paint.SetTypeface(Typeface.CreateFromAsset(context.Assets, font));
		this.paint.SetStyle(Android.Graphics.Paint.Style.Fill);
		this.paint.TextAlign = Android.Graphics.Paint.Align.Center;
		this.paint.Color = iconColor;
		this.paint.AntiAlias = true;
		this.size = GetPX(context, iconSizeDP);
		this.SetBounds(0, 0, this.size, this.size);
	}

	public override void Draw(Canvas canvas)
	{
		this.paint.TextSize = this.Bounds.Height();
		var textBounds = new Android.Graphics.Rect();
		this.paint.GetTextBounds(this.text, 0, 1, textBounds);
		var textHeight = textBounds.Height();
		var textBottom = this.Bounds.Top + (this.paint.TextSize - textHeight) / 2f + textHeight - textBounds.Bottom;
		canvas.DrawText(this.text, this.Bounds.Right - this.Bounds.Right / 15, textBottom, this.paint);
	}

	public override bool SetState(int[] stateSet)
	{
		var oldValue = paint.Alpha;
		var newValue = stateSet.Any(s => s == global::Android.Resource.Attribute.StateEnabled) ? this.alpha : this.alpha / 2;
		paint.Alpha = newValue;
		return oldValue != newValue;
	}

	private static int GetPX(Context context, int sizeDP)
	{
		return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, sizeDP, context.Resources.DisplayMetrics);
	}

	private static bool IsEnabled(int[] stateSet)
	{
		return stateSet.Any(s => s == global::Android.Resource.Attribute.StateEnabled);
	}

	public override void SetAlpha(int alpha)
	{
		this.alpha = alpha;
		this.paint.Alpha = alpha;
	}

	public override void SetColorFilter(ColorFilter colorFilter)
	{
		this.paint.SetColorFilter(colorFilter);
	}

	public override void ClearColorFilter()
	{
		this.paint.SetColorFilter(null);
	}
}
