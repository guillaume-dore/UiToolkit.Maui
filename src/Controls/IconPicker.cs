
using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

#pragma warning disable IDE0052, IDE0051
public partial class IconPicker : Picker
{
	[AutoBindable]
	private readonly ImageSource _source = null!;

	[AutoBindable(DefaultValue = "1.0")]
	private readonly double _strokeThickness;

	[AutoBindable]
	private readonly Color? _stroke;

	[AutoBindable]
	private readonly float _cornerRadius;
}