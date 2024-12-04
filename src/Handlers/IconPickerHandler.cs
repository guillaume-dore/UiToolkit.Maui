using Microsoft.Maui.Handlers;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler : PickerHandler
{
	private new IconPicker VirtualView => (IconPicker?)base.VirtualView ?? throw new InvalidOperationException($"VirtualView cannot be null here");

	private IFontManager FontManager => MauiContext?.Services.GetService<IFontManager>() ?? throw new InvalidOperationException($"FontManager cannot be null here");

	public static readonly new PropertyMapper<IconPicker, IconPickerHandler> Mapper = new(PickerHandler.Mapper)
	{
		[nameof(IconPicker.Source)] = MapSource,
		[nameof(IconPicker.StrokeThickness)] = MapStroke,
		[nameof(IconPicker.Stroke)] = MapStroke,
		[nameof(IconPicker.CornerRadius)] = MapCornerRadius
	};

	public IconPickerHandler() : base(Mapper) { }
}
