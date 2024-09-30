namespace UiToolkit.Maui.Controls;

public class SegmentedItem
{
	public SegmentedItem(string text, bool isSelected)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(text, nameof(text));
		Text = text;
		IsSelected = isSelected;
	}

	public SegmentedItem(string text, ImageSource selectedIcon, ImageSource unselectedIcon, bool isSelected) : this(text, isSelected)
	{
		SelectedIcon = selectedIcon;
		UnselectedIcon = unselectedIcon;
	}

	public string Text { get; set; }

	public bool IsSelected { get; set; }

	public ImageSource? SelectedIcon { get; set; }

	public ImageSource? UnselectedIcon { get; set; }

	internal bool UnselectedIconVisible => UnselectedIcon != null;

	internal bool SelectedIconVisible => SelectedIcon != null;

	public override bool Equals(object? obj)
		=> obj is SegmentedItem itemToCompare && itemToCompare.Text.Equals(this.Text, StringComparison.InvariantCultureIgnoreCase);

	public override int GetHashCode()
		=> base.GetHashCode();

	public override string ToString()
		=> Text;
}
