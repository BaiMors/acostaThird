using System;
using System.Collections.Generic;
using Acosta.Models;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class AddEmployeesViewModel : ReactiveObject
	{
        SuharevaContext myConnection;
        Employee currentUser;

        public AddEmployeesViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentUser = new Employee();
            myConnection.Add(CurrentUser);
        }

        public Employee CurrentUser { get => currentUser; set => currentUser = value; }
    }
}