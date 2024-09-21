using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

public partial class ConditionalView : ContentView
{
	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly bool _condition;

	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly View? _true;

	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly View? _false;

	private void UpdateContent() => Content = Condition ? True : False;
}
