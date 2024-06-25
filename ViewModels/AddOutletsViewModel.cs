using System;
using System.Collections.Generic;
using Acosta.Models;
using ReactiveUI;

namespace Acosta.ViewModels
{
    public class AddOutletsViewModel : ReactiveObject
    {
        SuharevaContext myConnection;
        Outlet currentOutlet;

        public AddOutletsViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentOutlet = new Outlet();
            myConnection.Add(CurrentOutlet);

        }

        public Outlet CurrentOutlet { get => currentOutlet; set => currentOutlet = value; }
    }
}