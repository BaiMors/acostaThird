using System;
using System.Collections.Generic;
using Acosta.Models;
using ReactiveUI;

namespace Acosta.ViewModels
{
    public class AddOutletsViewModel : ReactiveObject
    {
        SuharevaContext myC;
        Outlet? currentOutlet;

        public AddOutletsViewModel(SuharevaContext myC)
        {
            this.myC = myC;
            CurrentOutlet = new Outlet();
            myC.Add(CurrentOutlet);
        }

        public Outlet? CurrentOutlet { get => currentOutlet; set => currentOutlet = value; }
    }
}