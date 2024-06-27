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
        SuharevaContext myC;
        Employee? currentUser;

        public AddEmployeesViewModel(SuharevaContext myC)
        {
            this.myC = myC;
            CurrentUser = new Employee();
            myC.Add(CurrentUser);
        }

        public Employee? CurrentUser { get => currentUser; set => currentUser = value; }
    }
}