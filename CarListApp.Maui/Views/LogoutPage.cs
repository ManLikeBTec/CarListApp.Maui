using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui.Views;

public class LogoutPage : ContentPage
{
	public LogoutPage(LogoutPageViewModel logoutPageViewModel)
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Logging Out" }
			}
		};

		BindingContext = logoutPageViewModel;
	}
}