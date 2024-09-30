using Microsoft.Maui.Handlers;

namespace UiToolkit.Maui.Handlers;

public partial class IconPickerHandler : PickerHandler
{
	//public static readonly new PropertyMapper<IconPicker, IconPickerHandler> Mapper = new(PickerHandler.Mapper)
	//{
	//	[nameof(IconPicker.Source)] = MapSourceChanged,
	//	[nameof(IconPicker.StrokeThickness)] = MapStrokeThicknessChanged,
	//	[nameof(IconPicker.Stroke)] = MapStrokeChanged,
	//	[nameof(IconPicker.CornerRadius)] = MapCornerRadiusChanged,
	//};

	public IconPickerHandler() : base(Mapper) { }
}
