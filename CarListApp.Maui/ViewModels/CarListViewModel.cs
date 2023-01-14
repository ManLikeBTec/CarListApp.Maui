using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CarListApp.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Maui.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        const string editButtonText = "Update Car";
        const string createButtonText = "Add Car";
        private readonly CarApiService carApiService;
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        string message = string.Empty;

        public ObservableCollection<Car> Cars { get; private set; } = new ();  
        public CarListViewModel(CarApiService carApiService)
        {
            Title = "Car List";
            AddEditButtonText = createButtonText;
            this.carApiService = carApiService;
            //GetCarList().Wait();
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string make;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        string vin;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        int carId;

        [RelayCommand]
        async Task GetCarList()
        {
            if (IsLoading) return;

            try
            {
                IsLoading = true;
                if (Cars.Any()) Cars.Clear();
                var cars = new List<Car>();
                if (accessType == NetworkAccess.Internet)
                {
                    cars = await carApiService.GetCars();
                }
                else
                {
                    cars = App.CarDatabaseService.GetCars();
                }
                foreach (var car in cars)
                {
                    Cars.Add(car);
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"Unable to get cars: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrieve list of cars", "Ok");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        //parameter car marked by "." in binding statement because "." means "this"
        [RelayCommand]
        async Task GetCarDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task SaveCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }
            var car = new Car
            {
                Id = CarId,
                Make = Make,
                Model = Model,
                Vin = Vin,
            };

            if (CarId != 0)
            {
                if (accessType == NetworkAccess.Internet)
                {
                    await carApiService.UpdateCar(carId, car);
                    message = carApiService.StatusMessage;
                }
                else 
                { 
                    App.CarDatabaseService.UpdateCar(car);
                    message = App.CarDatabaseService.StatusMessage;
                }
            }
            else
            {
                if (accessType == NetworkAccess.Internet)
                {
                    await carApiService.AddCar(car);
                    message = carApiService.StatusMessage;
                }
                else
                {
                    App.CarDatabaseService.AddCar(car);
                    message = App.CarDatabaseService.StatusMessage;
                    await Shell.Current.DisplayAlert("Info", App.CarDatabaseService.StatusMessage, "Ok");
                }
            }
            await Shell.Current.DisplayAlert("Info", message, "Ok");
            await GetCarList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }

            if (accessType == NetworkAccess.Internet)
            {
                await carApiService.DeleteCar(id);
                message = carApiService.StatusMessage;
            }
            else
            { 
                App.CarDatabaseService.DeleteCar(id);
                message = App.CarDatabaseService.StatusMessage;
            }
            await Shell.Current.DisplayAlert("Deletion Successful", message, "Ok");
            await GetCarList();
            await ClearForm();
        }

        [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText = editButtonText;
            CarId = id;
            Car car;
            if (accessType == NetworkAccess.Internet)
            {
                car = await carApiService.GetCar(id);
            }
            else
            {
                car = App.CarDatabaseService.GetCar(id);
            }
            Make = car.Make;
            Model = car.Model;
            Vin = car.Vin;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            CarId = 0;
            Make = string.Empty; 
            Model = string.Empty;
            Vin = string.Empty;
        }
    }
}
