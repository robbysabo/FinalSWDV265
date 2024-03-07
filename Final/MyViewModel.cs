using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final;

public class MyCars
{
    public string name { get; set; } = "CAR NAME HERE";
    public string description { get; set; } = "DESCRIPTION HERE";
    public string price { get; set; } = "$$$$$$$$$$$";
    public string img { get; set; } = "NEED IMG SOURCE";
}

public class MyViewModel : INotifyPropertyChanged
{
    private string contentUri = "http://localhost/cars.json";
    private IList<MyCars> source = new List<MyCars>();
    private ObservableCollection<MyCars> mycars = new ObservableCollection<MyCars>();

    public ObservableCollection<MyCars> MyCarsList
    {
        get => mycars;
        set
        {
            mycars = value;
            OnPropertyChanged("MyCarsList");
        }
    }

    public ICommand OnCarClicked { get; private set; }

    public MyViewModel()
    {
        GetCars();
        OnCarClicked = new Command((theID) => GoToDetailPage((string)theID));
    }

    private async void GoToDetailPage(string theID)
    {
        int currentDetail = Int32.Parse(theID) - 1;
        MyCars theCar = MyCarsList[currentDetail];
        await Shell.Current.GoToAsync($"///DetailPage?name={theCar.name}&img={theCar.img}&price={theCar.price}&desc={theCar.description}");
    }

    private async void GetCars()
    {
        var httpClient = new HttpClient();
        try
        {
            source = new List<MyCars>();
            List <MyCars> jsonResponse = await httpClient.GetFromJsonAsync<List<MyCars>>(new Uri(contentUri));
            jsonResponse.ForEach(s => source.Add(s));
            MyCarsList = new ObservableCollection<MyCars>(source);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
