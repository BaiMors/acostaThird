using System;
using System.Collections.Generic;
using System.Linq;
using Acosta.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class OutletsListViewModel : ReactiveObject
	{
        SuharevaContext myConnection;
        Outlet? currentOutlet;

        public OutletsListViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentOutlet = myConnection.Outlets.Include(x => x.TradeNetworksNavigation).FirstOrDefault();
            MainWindowViewModel a = new();
        }

        public List<TradeNetwork> ListTrades => myConnection.TradeNetworks.ToList();

        public Outlet? CurrentOutlet { get => currentOutlet; set => currentOutlet = value; }
    }
}