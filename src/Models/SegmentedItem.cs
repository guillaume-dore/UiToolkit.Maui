namespace UiToolkit.Maui.Models;

public class SegmentedItem
{
	public SegmentedItem(string text)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(text, nameof(text));
		Text = text;
	}

	public string Text { get; set; }

	public override bool Equals(object? obj)
		=> obj is SegmentedItem itemToCompare && itemToCompare.Text.Equals(this.Text, StringComparison.InvariantCultureIgnoreCase);

	public override int GetHashCode()
		=> base.GetHashCode();

	public static IEnumerable<SegmentedItem> GetSegmentedItems(IEnumerable<string> items)
	{
		ArgumentNullException.ThrowIfNull(items, nameof(items));
		return items.Select(x => new SegmentedItem(x));
	}
}
