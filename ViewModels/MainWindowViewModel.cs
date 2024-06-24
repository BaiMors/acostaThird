using Acosta.Views;
using Avalonia.Controls;
using ReactiveUI;
using Acosta.Models;
using System.Linq;
using Acosta.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Acosta.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static SuharevaContext myConnection = new SuharevaContext();

        AuthorizationViewModel authorizationVM = new AuthorizationViewModel();
        public AuthorizationViewModel AuthorizationVM { get => authorizationVM; set => authorizationVM = value; }

        AddTradeNetworksViewViewModel addTradeNetworksVM = new AddTradeNetworksViewViewModel(myConnection);
        public AddTradeNetworksViewViewModel AddTradeNetworksVM { get => addTradeNetworksVM; set => addTradeNetworksVM = value; }

        AddEmployeesViewModel addEmployeesViewModel = new AddEmployeesViewModel(myConnection);
        public AddEmployeesViewModel AddEmployeesViewModel { get => addEmployeesViewModel; set => addEmployeesViewModel = value; }

        public void SaveNetwork()
        {
            myConnection.SaveChanges();
            UC = new TradeNetworksView();
        }

        public void SaveUser()
        {
            myConnection.SaveChanges();
            UC = new EmployeesView();
        }

        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); } 
        private UserControl uc = new AddEmployeesView();

        public void LoadPersonalAccount()
        {
            UC = new PersonalAccountView();
            Employee? currentUser = myConnection.Employees.FirstOrDefault(x => x.Email == AuthorizationVM.Login && x.Password == AuthorizationVM.Password);
            if (currentUser == null)
            {
                AuthorizationVM.Message = "Пользователя с такими данными не существует.";
            }
            else if (currentUser.Role != 1)
            {
                AuthorizationVM.Message = "Ваша роль не соответсвует требованиям.";
            }
            else
            {
                AuthorizationVM.Message = "Успех!";
            }
        }

        public List<Project> ListProjects => myConnection.Projects.ToList();
        public List<Role> rolesList => (from p in myConnection.Roles.ToList() where p.Title != "Оператор" select p).ToImmutableList().ToList();
        public List<Employee> userList => (from p in myConnection.Employees.ToList() where p.Role != 1 select p).ToImmutableList().ToList();

        public void ExitFromProfile()
        {
            UC = new AuthorizationView();
        }
        public void AddTradeNetworksView()
        {
            UC = new AddTradeNetworksView();
        }
        public void BackTradeNetworksView()
        {
            UC = new TradeNetworksView();
        }
        public void AddOutletsView()
        {
            UC = new AddOutletsView();
        }
        public void BackOutletsView()
        {
            UC = new OutletsView();
        }
        public void EditOutletsView()
        {
            UC = new EditOutletsView();
        }
        public void AddEmployeesView()
        {
            UC = new AddEmployeesView();
        }
        public void BackEmployeesView()
        {
            UC = new EmployeesView();
        }
        public void EditEmployeesView(int userID)
        {
            UC = new EditEmployeesView();
        }
    }
}
