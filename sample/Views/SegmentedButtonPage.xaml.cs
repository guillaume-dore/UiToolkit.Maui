using UiToolkit.Maui.Models;

namespace UiToolkit.Maui.Sample.Views;

public partial class SegmentedButtonPage : ContentPage
{
	private bool _iconEnabled = false;

	public SegmentedButtonPage()
	{
		Items = SegmentedItem.GetSegmentedItems(["Option 1", "Option 2"]);
		ItemsWithIcons = SegmentedItem.GetSegmentedItems(["Option 1", "Option 2"]);
		MultipleItems = SegmentedItem.GetSegmentedItems(["Option 1", "Option 2", "Option 3", "Option 4"]);

		SelectedItem = Items.First();
		SelectedItemWithIcon = ItemsWithIcons.First();
		SelectedMultipleItem = Items.First();
		InitializeComponent();
	}

	public IEnumerable<SegmentedItem> Items { get; }

	public IEnumerable<SegmentedItem> ItemsWithIcons { get; }

	public IEnumerable<SegmentedItem> MultipleItems { get; }

	public SegmentedItem SelectedItem { get; set; }

	public SegmentedItem SelectedItemWithIcon { get; set; }

	public SegmentedItem SelectedMultipleItem { get; set; }
}