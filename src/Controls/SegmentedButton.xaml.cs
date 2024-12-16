using Maui.BindableProperty.Generator.Core;
using Microsoft.Maui.Layouts;
using UiToolkit.Maui.Models;

namespace UiToolkit.Maui.Controls;

public partial class SegmentedButton : Border
{
#pragma warning disable IDE0052, CS0169, CS0414
	[AutoBindable]
	private readonly string? _fontFamily;

	[AutoBindable(DefaultValue = "true")]
	private readonly bool _isEnabled;

	[AutoBindable]
	private readonly Color? _selectedColor;

	[AutoBindable]
	private readonly Color? _selectedBackground;

	[AutoBindable]
	private readonly Color? _unselectedColor;

	[AutoBindable]
	private readonly Color? _unselectedBackground;

	[AutoBindable(ValidateValue = nameof(IsSourceValid))]
	private readonly IEnumerable<SegmentItem> _itemsSource = null!;

	[AutoBindable(DefaultBindingMode = nameof(BindingMode.TwoWay))]
	private readonly SegmentItem? _selectedItem;
#pragma warning restore IDE0052, CS0169, CS0414

	public SegmentedButton()
	{
		InitializeComponent();
	}

	public FlexBasis GetBasis { get => new(1f / ItemsSource.Count(), isRelative: true); }

	public string GroupName { get; } = Guid.NewGuid().ToString();

	private static bool IsSourceValid(BindableObject _, object value)
		=> value is IEnumerable<SegmentItem> items && items.Any();

	private void SegmentItem_Clicked(object sender, EventArgs e)
	{
		Button obj = (Button)sender;
		RadioButton radio = (RadioButton)obj.Parent.Parent;
		SelectedItem = (SegmentItem)radio.Value;
	}
}