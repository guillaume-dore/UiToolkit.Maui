using UiToolkit.Maui.Controls;
using UiToolkit.Maui.Handlers;

[assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Controls")]
[assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Converters")]
namespace UiToolkit.Maui;

public static class MauiAppBuilderExtensions
{
	public static MauiAppBuilder UseUiToolkit(this MauiAppBuilder builder)
	{
		return builder.ConfigureMauiHandlers(cfg =>
		{
			cfg.AddHandler<IconPicker, IconPickerHandler>();
		});
	}
}
