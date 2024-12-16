using Android.Graphics.Fonts;
using UiToolkit.Maui.Models;

namespace UiToolkit.Maui.Sample.Views;

public partial class SegmentedButtonPage : ContentPage
{
	private bool _iconEnabled = false;

	public SegmentedButtonPage()
	{

		Items = [new SegmentItem("Option 1"), new SegmentItem("Option 2")];
		ItemsWithIcons = [
			new SegmentItem("Option 1", new FontImageSource { FontFamily = "MaterialIconsRound", Glyph = "&#xe5ca;" }, new FontImageSource { FontFamily = "MaterialIconsRound", Glyph = "&#xe5cd;" }),
			new SegmentItem("Option 2", new FontImageSource { FontFamily = "MaterialIconsRound", Glyph = "&#xe5ca;" }, new FontImageSource { FontFamily = "MaterialIconsRound", Glyph = "&#xe5cd;" })
		];
		ItemsWithIcons[0].SelectedIcon.SetAppThemeColor(FontImageSource.ColorProperty, )



		ItemsWithIcons = SegmentItem.GetSegmentItems(["Option 1", "Option 2"], new FontImageSource { FontFamily = "MaterialIconsRound", Glyph = "&#xe5ca;", Color = Color, Size = Size }, new FontImageSource { FontFamily = FontFamily, Glyph = Glyph, Color = Color, Size = Size }.App);
		MultipleItems = SegmentItem.GetSegmentItems(["Option 1", "Option 2", "Option 3", "Option 4"]);

		SelectedItem = Items.First();
		SelectedItemWithIcon = ItemsWithIcons.First();
		SelectedMultipleItem = Items.First();
		InitializeComponent();
	}

	public IEnumerable<SegmentItem> Items { get; }

	public IList<SegmentItem> ItemsWithIcons { get; }

	public IEnumerable<SegmentItem> MultipleItems { get; }

	public SegmentItem SelectedItem { get; set; }

	public SegmentItem SelectedItemWithIcon { get; set; }

	public SegmentItem SelectedMultipleItem { get; set; }
}