namespace Final;

[QueryProperty(nameof(Name), "name")]
[QueryProperty(nameof(Price), "price")]
[QueryProperty(nameof(Desc), "desc")]
[QueryProperty(nameof(Img), "img")]
public partial class DetailPage : ContentPage
{
	public string Name
	{
		set
		{
			title.Text = value;
		}
	}

	public string Price
	{
		set
		{
			price.Text = value;
		}
	}

	public string Desc
	{
		set
		{
			desc.Text = value;
		}
	}

	public string Img
	{
		set
		{
			img.Source = "car" + value + ".jpg";
		}
	}

	public DetailPage()
	{
		InitializeComponent(); 
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///InventoryPage");
	}
}