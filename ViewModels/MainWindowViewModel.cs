using Acosta.Views;
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
        public static SuharevaContext myConnection = new SuharevaContext();

        AuthorizationViewModel authorizationVM = new AuthorizationViewModel();
        public AuthorizationViewModel AuthorizationVM { get => authorizationVM; set => authorizationVM = value; }

        AddTradeNetworksViewViewModel addTradeNetworksVM = new AddTradeNetworksViewViewModel(myConnection);
        public AddTradeNetworksViewViewModel AddTradeNetworksVM { get => addTradeNetworksVM; set => addTradeNetworksVM = value; }

        /*AddEmployeesViewModel addEmployeesViewModel = new AddEmployeesViewModel(myConnection);
        public AddEmployeesViewModel AddEmployeesViewModel { get => addEmployeesViewModel; set => addEmployeesViewModel = value; }*/


        AddOutletsViewModel outletVM = new AddOutletsViewModel(myConnection);
        public AddOutletsViewModel OutletVM { get => outletVM; set => outletVM = value; }


        OutletsListViewModel outletListVM = new OutletsListViewModel(myConnection);
        public OutletsListViewModel OutletListVM { get => outletListVM; set => outletListVM = value; }


        PersonalAccountViewModel personalAccountVM = new PersonalAccountViewModel(myConnection);
        public PersonalAccountViewModel PersonalAccountVM { get => personalAccountVM; set => personalAccountVM = value; }

        public void SaveNetwork()
        {
            myConnection.SaveChanges();
            UC = new TradeNetworksView();
        }

        /*public void SaveUser()
        {
            myConnection.SaveChanges();
            UC = new EmployeesView();
        }*/

        /*public void SaveData()
        {
            myConnection.SaveChanges();
            UC = new PersonalAccountView();
        }*/

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
        public List<Employee> ListEmployees => myConnection.Employees.ToList();
        public List<Outlet> ListOutlets => myConnection.Outlets.ToList();
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
