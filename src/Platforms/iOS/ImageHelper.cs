using CoreGraphics;
using Foundation;
using UIKit;

namespace UiToolkit.Maui;

internal static class ImageHelper
{
	internal static UIImage ImageFromFont(string text, UIColor iconColor, CGSize iconSize, UIFont font)
	{
		var renderer = new UIGraphicsImageRenderer(iconSize, new UIGraphicsImageRendererFormat
		{
			Opaque = false,
			Scale = 0
		});

		UIImage image = renderer.CreateImage((context) =>
		{
			var textRect = new CGRect(CGPoint.Empty, iconSize);
			var path = UIBezierPath.FromRect(textRect);
			UIColor.Clear.SetFill();
			path.Fill();

			using var label = new UILabel() { Text = text, Font = font };
			GetFontSize(label, iconSize, 500, 5);
			font = label.Font;
			iconColor.SetFill();

			using var nativeString = new NSString(text);
			nativeString.DrawString(textRect, new UIStringAttributes
			{
				Font = font,
				ForegroundColor = iconColor,
				BackgroundColor = UIColor.Clear,
				ParagraphStyle = new NSMutableParagraphStyle { Alignment = UITextAlignment.Center }
			});
		});
		return image;
	}

	private static void GetFontSize(UILabel label, CGSize size, int maxFontSize, int minFontSize)
	{
		label.Frame = new CGRect(CGPoint.Empty, size);
		var fontSize = maxFontSize;
		var constraintSize = new CGSize(label.Frame.Width, nfloat.MaxValue);
		while (fontSize > minFontSize)
		{
			label.Font = UIFont.FromName(label.Font.Name, fontSize);
			using (var nativeString = new NSString(label.Text))
			{
				var textRect = nativeString.GetBoundingRect(
						  constraintSize,
						  NSStringDrawingOptions.UsesFontLeading,
						  new UIStringAttributes { Font = label.Font },
						  null
						);

				if (textRect.Size.Height <= label.Frame.Height)
					break;
			}

			fontSize -= 2;
		}
	}
}
