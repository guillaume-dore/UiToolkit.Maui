using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

public partial class SegmentedButton : ContentView
{
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