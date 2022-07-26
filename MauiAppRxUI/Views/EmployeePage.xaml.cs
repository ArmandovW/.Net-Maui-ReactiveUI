using MauiAppRxUI.ViewModels;

namespace MauiAppRxUI.Views;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewModel();
	}
}