using System;
using System.Collections.Generic;
using Acosta.Models;
using Acosta.Views;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class AddEmployeesViewModel : ReactiveObject
	{
        SuharevaContext myConnection;
        Employee currentUser;
        string f;
        string i;
        string o;
        string phone;
        string email;
        int role;
        string password;

        public AddEmployeesViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentUser = new Employee();
            //CurrentUser.Surname = F;
            //CurrentUser.Name = I;
            //CurrentUser.Patronymic = O;
            //CurrentUser.Phonenumber = Phone;
            //CurrentUser.Email = Email;
            //CurrentUser.Password = Password;
            //CurrentUser.Role = Role;
            myConnection.Add(CurrentUser);
        }

        public Employee CurrentUser { get => currentUser; set => currentUser = value; }

        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int Role { get => role; set => role = value; }
        public string Password { get => password; set => password = value; }
        public string F { get => f; set => f = value; }
        public string I { get => i; set => i = value; }
        public string O { get => o; set => o = value; }
    }
}