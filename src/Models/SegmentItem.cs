namespace UiToolkit.Maui.Models;

public class SegmentItem
{
	public SegmentItem(string text)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(text, nameof(text));
		Text = text;
	}

	public SegmentItem(string text, ImageSource icon) : this(text)
	{
		ArgumentNullException.ThrowIfNull(icon, nameof(icon));
		Icon = icon;
	}

	public string Text { get; set; }

	public ImageSource? Icon { get; set; }

	public override bool Equals(object? obj)
		=> obj is SegmentItem itemToCompare && itemToCompare.Text.Equals(Text, StringComparison.InvariantCultureIgnoreCase);

	public override int GetHashCode()
		=> base.GetHashCode();
}
