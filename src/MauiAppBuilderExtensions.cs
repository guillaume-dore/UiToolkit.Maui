[assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Controls")]
([assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Converters")]
namespace UiToolkit.Maui;

public static class MauiAppBuilderExtensions
{
	public static MauiAppBuilder UseUiToolkit(this MauiAppBuilder builder) => builder;
}
