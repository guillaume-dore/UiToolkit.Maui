using System.Globalization;

namespace UiToolkit.Maui.Converters;

public class EnumToStringConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value != null ? System.Convert.ChangeType(value, value!.GetType()).ToString() : null;

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		Type type = targetType;
		if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
			type = Nullable.GetUnderlyingType(targetType)!;
		if (Enum.TryParse(type, (string)value!, out var result))
			return result;
		else
			return null;
	}
}
