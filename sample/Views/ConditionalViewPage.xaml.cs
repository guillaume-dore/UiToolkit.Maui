namespace UiToolkit.Maui.Sample.Views;

public partial class ConditionalViewPage : ContentPage
{
	public ConditionalViewPage() => InitializeComponent();

	public bool Condition { get; set; } = true;

	private void Button_Clicked(object sender, EventArgs e)
	{
		Condition = !Condition;
		OnPropertyChanged(nameof(Condition));
	}
}