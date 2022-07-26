using MauiAppRxUI.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppRxUI.ViewModels
{
	public class EmployeeViewModel : ReactiveObject
	{
		List<Employee> employeeData = new List<Employee>()
		{
			new Employee{Name = "Arra", Email="whatever@whatwhat.com", PhoneNumber = "+264811256987"},
			new Employee{Name = "Hein", Email="another@email.com", PhoneNumber = "+264811256987"},
			new Employee{Name = "Morne", Email="me@tester.com", PhoneNumber = "+264811256987"},
			new Employee{Name = "Stefan", Email="skruger@dgs.com", PhoneNumber = "+264811256987"},
		};
		public EmployeeViewModel()
		{
			employees = new ObservableCollection<Employee>(employeeData);

			this.WhenAnyValue(vm => vm.SearchQuery)
				.Subscribe(query =>
				{
					var filteredQuery = employeeData.Where(q => q.Name.ToLower().Contains(query) || q.Email.ToLower().Contains(query)).ToList();
					Employees = new ObservableCollection<Employee>(filteredQuery);
				});
		}

		private ObservableCollection<Employee> employees;
		public ObservableCollection<Employee> Employees
		{
			get => employees;
			set
			{
				this.RaiseAndSetIfChanged(ref employees, value);
			}
		}

		private string searchQuery = "";
		public string SearchQuery
		{
			get => searchQuery;
			set
			{
				this.RaiseAndSetIfChanged(ref searchQuery, value);
			}
		}
	}
}
