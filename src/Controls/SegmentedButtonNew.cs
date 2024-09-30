using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

public partial class SegmentedButtonNew : Border
{
	[AutoBindable(DefaultValue = "SegmentedButtonStyle.Outline")]
	private readonly SegmentedButtonStyle _type;

	[AutoBindable(DefaultValue = "SegmentedSelectionMode.Single")]
	private readonly SegmentedSelectionMode _selectionMode;

	public SegmentedButtonNew()
	{
		BatchBegin();
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
		BatchCommit();
	}
}