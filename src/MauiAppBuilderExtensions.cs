﻿using Microsoft.Maui.Controls.Compatibility.Hosting;
using UiToolkit.Maui.Controls;

[assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Controls")]
[assembly: XmlnsDefinition("https://schemas.gd.com/dotnet/2024/maui", "UiToolkit.Maui.Converters")]
namespace UiToolkit.Maui;

public static class MauiAppBuilderExtensions
{
	public static MauiAppBuilder UseUiToolkit(this MauiAppBuilder builder)
	{
		builder.UseMauiCompatibility();
		return builder.ConfigureMauiHandlers(cfg =>
		{
			//cfg.AddHandler<IconPicker, IconPickerHandler>();
			cfg.AddCompatibilityRenderer<IconPicker, IconPickerRenderer>();
		});
	}
}
