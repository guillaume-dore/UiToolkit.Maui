using Microsoft.Maui.Handlers;
using UiToolkit.Maui.Controls;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler : PickerHandler
{
	private new IconPicker VirtualView => (IconPicker?)base.VirtualView ?? throw new InvalidOperationException($"VirtualView cannot be null here");

	//public static readonly new PropertyMapper<IconPicker, IconPickerHandler> Mapper = new(PickerHandler.Mapper)
	//{
	//	[nameof(IconPicker.Source)] = MapSourceChanged,
	//	[nameof(IconPicker.StrokeThickness)] = MapStrokeThicknessChanged,
	//	[nameof(IconPicker.Stroke)] = MapStrokeChanged,
	//	[nameof(IconPicker.CornerRadius)] = MapCornerRadiusChanged,
	//};

	public IconPickerHandler() : base(Mapper) { }
}
