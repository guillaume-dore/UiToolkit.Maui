namespace UiToolkit.Maui.Sample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Person1 = new Person("John", "Doe");
		Person2 = new Person("Mickael", "Check");
	}

	public Person Person1 { get; set; }

	public Person Person2 { get; set; }

	public Func<Person, bool> ConditionAsFunction = (s) => s.FirstName == "John" && s.LastName == "Doe";

	public bool Condition { get; set; } = true;

	public Status Status { get; set; } = Status.Status1;

	public string[] Items => ["item 1", "item 2"];

	private void Button_Clicked(object sender, EventArgs e)
	{
		Condition = !Condition;
		OnPropertyChanged(nameof(Condition));
	}
}

public enum Status
{
	Status1,
	Status2
}

public class Person(string firstName, string lastName)
{
	public string FirstName { get; set; } = firstName;

	public string LastName { get; set; } = lastName;
}

