using Maui.BindableProperty.Generator.Core;

namespace UiToolkit.Maui.Controls;

public partial class ConditionalView : ContentView
{
#pragma warning disable IDE0052, CS0169
	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly bool _condition;

	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly View? _true;

	[AutoBindable(OnChanged = nameof(UpdateContent))]
	private readonly View? _false;
#pragma warning restore IDE0052, CS0169

	private void UpdateContent() => Content = Condition ? True : False;
}
