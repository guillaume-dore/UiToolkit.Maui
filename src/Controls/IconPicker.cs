
using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

#pragma warning disable IDE0052, IDE0051
public partial class IconPicker : Picker
{
	[AutoBindable]
	private readonly ImageSource _source = null!;
}