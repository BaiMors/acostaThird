﻿using Acosta.Views;
using Avalonia.Controls;
using ReactiveUI;
using Acosta.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Acosta.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        static SuharevaContext myConnection = new SuharevaContext();
        static SuharevaContext myConnection1 = new SuharevaContext();
        static SuharevaContext myConnection2 = new SuharevaContext();
        static SuharevaContext myConnection3 = new SuharevaContext();
        static SuharevaContext myConnection4 = new SuharevaContext();
        static SuharevaContext myConnection5 = new SuharevaContext();

        AuthorizationViewModel authorizationVM = new AuthorizationViewModel();
        public AuthorizationViewModel AuthorizationVM { get => authorizationVM; set => authorizationVM = value; }

        AddTradeNetworksViewViewModel addTradeNetworksVM = new AddTradeNetworksViewViewModel(myConnection2);
        public AddTradeNetworksViewViewModel AddTradeNetworksVM { get => addTradeNetworksVM; set => addTradeNetworksVM = value; }

        AddEmployeesViewModel addEmployeesVM = new AddEmployeesViewModel(myConnection1);
        public AddEmployeesViewModel AddEmployeesVM { get => addEmployeesVM; set => addEmployeesVM = value; }


        AddOutletsViewModel outletVM = new AddOutletsViewModel(myConnection3);
        public AddOutletsViewModel OutletVM { get => outletVM; set => outletVM = value; }


        OutletsListViewModel outletListVM = new OutletsListViewModel(myConnection4);
        public OutletsListViewModel OutletListVM { get => outletListVM; set => outletListVM = value; }


        PersonalAccountViewModel personalAccountVM = new PersonalAccountViewModel(myConnection);
        public PersonalAccountViewModel PersonalAccountVM { get => personalAccountVM; set => personalAccountVM = value; }


        VisitsViewModel visitsVM = new VisitsViewModel(myConnection5);
        public VisitsViewModel VisitsVM { get => visitsVM; set => visitsVM = value; }

        public void SaveNetwork()
        {
            myConnection2.SaveChanges();
            UC = new TradeNetworksView();
        }

        public void SaveUser()
        {
            myConnection1.SaveChanges();
            UC = new EmployeesView();
        }

        public void SaveOutlet()
        {
            myConnection3.SaveChanges();
            UC = new OutletsView();
        }

        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); } 
        private UserControl uc = new AuthorizationView();
        public int curUsId;

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
                curUsId = currentUser.Employeesid;
                PersonalAccountVM = new PersonalAccountViewModel(myConnection, curUsId);
                UC = new PersonalAccountView();
            }
        }

        public List<Project> ListProjects => myConnection.Projects.ToList();
        public List<Employee> ListEmployees => myConnection.Employees.ToList().Where(x => x.Employeesid != curUsId).ToList();
        public List<Outlet> ListOutlets => myConnection.Outlets.ToList();
        public List<Visit> ListVisits => myConnection.Visits.ToList();
        public List<Acceptance> Acceptances => myConnection.Acceptances.ToList();
        //List<a> newList = new List<a>(new a((from p in myConnection.Outlets.ToList() select p.Outletid).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.Outlets.ToList() select p.Address).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.Outlets.ToList() select p.Location).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.TradeNetworks.ToList() select p.Title).ToImmutableList().ToList().FirstOrDefault()));
        //public List<string> fkTrade => myConnection.TradeNetworks.ToList().Select(x => x.Title).Where()
        //List<a> newList = new List<a>(new a((from p in myConnection.Outlets.ToList() select p.Outletid).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.Outlets.ToList() select p.Address).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.Outlets.ToList() select p.Location).ToImmutableList().ToList().FirstOrDefault(), (from p in myConnection.TradeNetworks.ToList() select p.Title).ToImmutableList().ToList().FirstOrDefault()));

        //public struct a
        //{
        //    int Outlerid;
        //    string Address;
        //    string Location;
        //    string TradeNetworks;


        //    public a(int oid, string ad, string loc, string tn)
        //    {
        //        Outlerid = oid;
        //        Address = ad;
        //        Location = loc;
        //        TradeNetworks = tn;
        //    }
        //}
        //public IEnumerable<dynamic> ListOutlets => myConnection.Outlets.Select(p => new
        //{
        //    p.Outletid,
        //    p.Address,
        //    p.Location,
        //    TradeTitles = ListTrades.Where(x => x.Tradeid == p.TradeNetworks).Select(x => x.Title),
        //    p.TradeNetworks,
        //    p.Visits
        //}).ToList();
        //    public List<Outlet> ListOutlets => myConnection.Outlets
        //.Join(myConnection.TradeNetworks,
        //      outlet => outlet.TradeNetworks,
        //      tradeNetwork => tradeNetwork.Tradeid,
        //      (outlet, tradeNetwork) => new Outlet
        //      {
        //          Outletid = outlet.Outletid,
        //          Address = outlet.Address,
        //          Location = outlet.Location,
        //          TradeNetworks = tradeNetwork.Title, // replace this with the actual property name for the retail chain name
        //          Visits = outlet.Visits
        //      })
        //.ToList();
        public List<TradeNetwork> ListTrades => myConnection.TradeNetworks.ToList();

        





        /*public List<Role> rolesList => (from p in myConnection.Roles.ToList() where p.Title != "Оператор" select p).ToImmutableList().ToList();
        public List<Employee> userList => (from p in myConnection.Employees.ToList() where p.Role != 1 select p).ToImmutableList().ToList();*/



        public void AddVisitView()
        {
            UC = new AddVisitView();
        }
        public void BackVisitView()
        {
            UC = new VisitsView();
        }
        public void EditVisitView()
        {
            UC = new EditVisitView();
        }


        public void AddProjectsView()
        {
            UC = new AddProjectsView();
        }
        public void BackProjectsView()
        {
            UC = new ProjectsView();
        }
        public void EditProjectsView()
        {
            UC = new EditProjectsView();
        }


        public void BackPersonalAccountView()
        {
            UC = new PersonalAccountView();
        }
        public void ChangePasswordView()
        {
            UC = new ChangePasswordView();
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
        public void EditEmployeesView(int userID)
        {
            
            UC = new EditEmployeesView();
        }
    }
}
