using System;
using System.Collections.Generic;
using Acosta.Models;
using Acosta.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class AddEmployeesViewModel : ReactiveObject
	{
        SuharevaContext myConnection;
        Employee currentUser;

        private UserControl uce = new AddTradeNetworksView();
        public UserControl UCE { get => uce; set => this.RaiseAndSetIfChanged(ref uce, value); }
        /*      string f;
              string i;
              string o;
              string phone;
              string email;
              int role;
              string password;*/

        public AddEmployeesViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentUser = new Employee();
/*            CurrentUser.Surname = F;
            CurrentUser.Name = I;
            CurrentUser.Patronymic = O;
            CurrentUser.Phonenumber = Phone;
            CurrentUser.Email = Email;
            CurrentUser.Password = Password;
            CurrentUser.Role = Role;*/
            myConnection.Add(currentUser);
        }
        public AddEmployeesViewModel(SuharevaContext myConnection, int userID)
        {
            this.myConnection = myConnection;
            CurrentUser = new Employee();
            myConnection.Add(currentUser);
        }

        public Employee CurrentUser { get => currentUser; set => currentUser = value; }

        /*public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int Role { get => role; set => role = value; }
        public string Password { get => password; set => password = value; }
        public string F { get => f; set => f = value; }
        public string I { get => i; set => i = value; }
        public string O { get => o; set => o = value; }*/

        public void SaveUser()
        {
            
            myConnection.SaveChanges();
            UCE = new EmployeesView();
        }
    }
}