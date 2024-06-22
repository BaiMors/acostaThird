﻿using Acosta.Views;
using Avalonia.Controls;
using ReactiveUI;
using Acosta.Models;
using System.Linq;
using Acosta.ViewModels;

namespace Acosta.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static SuharevaContext myConnection = new SuharevaContext();

        AuthorizationViewModel authorizationVM = new AuthorizationViewModel();
        public AuthorizationViewModel AuthorizationVM { get => authorizationVM; set => authorizationVM = value; }

        AddTradeNetworksViewViewModel addTradeNetworksVM = new AddTradeNetworksViewViewModel(myConnection);
        public AddTradeNetworksViewViewModel AddTradeNetworksVM { get => addTradeNetworksVM; set => addTradeNetworksVM = value; }

        public void SaveData()
        {
            myConnection.SaveChanges();
            UC = new TradeNetworksView();
        }

        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); }  

        private UserControl uc = new AddEmployeesView();

        public void LoadPersonalAccount()
        {
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
        public void EditEmployeesView()
        {
            UC = new EditEmployeesView();
        }
    }
}
