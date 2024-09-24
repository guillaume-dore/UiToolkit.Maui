using System.Globalization;

namespace UiToolkit.Maui.Converters;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TIn"></typeparam>
public class BoolFuncConverter<TIn, TOut> : IValueConverter
{
	/// <summary>
	/// Func provided to 
	/// </summary>
	public Func<TIn, TOut> Func { get; set; } = null!;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="value"></param>
	/// <param name="targetType"></param>
	/// <param name="parameter"></param>
	/// <param name="culture"></param>
	/// <returns></returns>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="InvalidCastException"></exception>
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (targetType != typeof(TOut)) throw new InvalidOperationException("Converter targetType invalid.");
		if (value is TIn val)
			return Func(val);
		throw new InvalidCastException("Value is not of type TIn.");
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException("Impossible to revert to original value. Consider setting BindingMode to OneWay.");
}
