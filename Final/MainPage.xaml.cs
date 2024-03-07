namespace Final
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnInventoryClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///InventoryPage");
        }

        private async void OnDictionaryClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///DirectionsPage");
        }
    }
}
