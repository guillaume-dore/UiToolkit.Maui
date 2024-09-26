using System.Windows.Input;
using UiToolkit.Maui.Sample.Views;

namespace UiToolkit.Maui.Sample;

public partial class MainPage : ContentPage
{
	public MainPage() => InitializeComponent();

	public List<UiToolkitItem> Items => [
		new UiToolkitItem
		{
			Name = "ConditionalView",
			Details = "Conditionnaly display view based on boolean binding result.",
			Command = new Command(() => Shell.Current.Navigation.PushAsync(new ConditionalViewPage()))
		},
		new UiToolkitItem
		{
			Name = "IconPicker",
			Details = "Modern picker control with icon and customizable border.",
			Command = new Command(() => Shell.Current.Navigation.PushAsync(new IconPickerPage()))
		},
		new UiToolkitItem
		{
			Name = "SegmentedButton",
			Details = "Segmented button control providing concise way to select an option, switch between views...",
			Command = new Command(() => Shell.Current.Navigation.PushAsync(new SegmentedButtonPage()))
		}
	];

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var item = (UiToolkitItem)collection.SelectedItem;
		if (item == null) return;
		item.Command.Execute(null);
	}
}

public class UiToolkitItem
{
	public string Name { get; set; } = null!;

	public string Details { get; set; } = null!;

	public ICommand Command { get; set; } = null!;
}

