using System;
using System.Collections.Generic;
using ReactiveUI;
using Acosta.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Acosta.ViewModels
{
	public class PersonalAccountViewModel : ReactiveObject
	{
		SuharevaContext myConnection;
		Employee currentUser;
        string oldPass;
        public string FIO;
        public PersonalAccountViewModel(SuharevaContext myConnection)
		{
            this.myConnection = myConnection;
            CurrentUser = new Employee();
            myConnection.Add(CurrentUser);
        }
        public PersonalAccountViewModel(SuharevaContext myConnection, int id)
        {
            this.myConnection = myConnection;
            CurrentUser = myConnection.Employees.FirstOrDefault(x => x.Employeesid == id);
            oldPass = CurrentUser.Password;
            CurrentUser.Surname = CurrentUser.Surname + " " + CurrentUser.Name.ToCharArray()[0] + ". " + CurrentUser.Patronymic.ToCharArray()[0] + ".";
        }

        public Employee CurrentUser { get => currentUser; set => currentUser = value; }
    }
}