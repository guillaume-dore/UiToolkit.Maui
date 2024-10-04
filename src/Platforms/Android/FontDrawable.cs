using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;

namespace UiToolkit.Maui;

internal class FontDrawable : Drawable
{
	private int _alpha = 255;

	private readonly int _size;

	private readonly string _text;

	private readonly TextPaint _paint = new();

	internal FontDrawable(Context context, string text, Android.Graphics.Color iconColor, int iconSizeDP, Typeface? font)
	{
		this._text = text;

		this._paint.SetTypeface(font ?? Typeface.CreateFromAsset(context.Assets, "ionicons.ttf"));
		this._paint.SetStyle(Android.Graphics.Paint.Style.Fill);
		this._paint.TextAlign = Android.Graphics.Paint.Align.Center;
		this._paint.Color = iconColor;
		this._paint.AntiAlias = true;
		this._size = GetPX(context, iconSizeDP);
		this.SetBounds(0, 0, this._size, this._size);
	}

	public override int IntrinsicWidth => this._size;

	public override int IntrinsicHeight => this._size;

	public override bool IsStateful => true;

	public override int Opacity => this._alpha;

	public override void Draw(Canvas canvas)
	{
		this._paint.TextSize = this.Bounds.Height();
		var textBounds = new Android.Graphics.Rect();
		this._paint.GetTextBounds(this._text, 0, 1, textBounds);
		var textHeight = textBounds.Height();
		var textBottom = this.Bounds.Top + (this._paint.TextSize - textHeight) / 2f + textHeight - textBounds.Bottom;
		canvas.DrawText(this._text, this.Bounds.Right - this.Bounds.Right / 10, textBottom, this._paint);
	}

	public override bool SetState(int[] stateSet)
	{
		var oldValue = _paint.Alpha;
		var newValue = stateSet.Any(s => s == global::Android.Resource.Attribute.StateEnabled) ? this._alpha : this._alpha / 2;
		_paint.Alpha = newValue;
		return oldValue != newValue;
	}

	private static int GetPX(Context context, int sizeDP)
		=> (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, sizeDP, context.Resources?.DisplayMetrics);

	private static bool IsEnabled(int[] stateSet)
		=> stateSet.Any(s => s == global::Android.Resource.Attribute.StateEnabled);

	public override void SetAlpha(int alpha)
	{
		this._alpha = alpha;
		this._paint.Alpha = alpha;
	}

	public override void SetColorFilter(ColorFilter? colorFilter)
		=> this._paint.SetColorFilter(colorFilter);

	public override void ClearColorFilter()
		=> this._paint.SetColorFilter(null);
}
