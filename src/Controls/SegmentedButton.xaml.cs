using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

public enum SegmentedButtonStyle
{
	Outline, Filled
}

public enum SegmentedSelectionMode
{
	Single, Multiple
}

#pragma warning disable IDE0052
public partial class SegmentedButton : ContentView
{
	[AutoBindable(DefaultValue = "SegmentedButtonStyle.Outline")]
	private readonly SegmentedButtonStyle _type;

	[AutoBindable(DefaultValue = "SegmentedSelectionMode.Single")]
	private readonly SegmentedSelectionMode _selectionMode;

	[AutoBindable]
	private readonly string? _fontFamily;

	[AutoBindable(DefaultValue = "true")]
	private readonly bool _isEnabled;

	[AutoBindable]
	private readonly Brush? _stroke;

	[AutoBindable]
	private readonly double _strokeThickness;

	[AutoBindable]
	private readonly Color? _selectedColor;

	[AutoBindable]
	private readonly Color? _selectedBackground;

	[AutoBindable]
	private readonly Color? _unselectedColor;

	[AutoBindable]
	private readonly Color? _unselectedBackground;

	[AutoBindable]
	private readonly string[]? _segmentItems;

	[AutoBindable(DefaultBindingMode = "TwoWay")]
	private readonly string? _selectedItem;

	public SegmentedButton()
	{
		InitializeComponent();
	}

	public string GroupName { get; } = Guid.NewGuid().ToString();

	private void SegmentItem_Clicked(object sender, EventArgs e)
		=> SelectedItem = ((Button)sender).Text;
}