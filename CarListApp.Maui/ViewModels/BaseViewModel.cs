using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.Maui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;

        public bool IsNotLoading => !isLoading;
    }
}
