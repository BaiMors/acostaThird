using System;
using System.Collections.Generic;
using ReactiveUI;
using Acosta.Models;
using Acosta.Views;
using Avalonia.Controls;

namespace Acosta.ViewModels
{
	public class AddTradeNetworksViewViewModel : ReactiveObject
	{
		SuharevaContext myConnection;
		TradeNetwork currentTrade;

        private UserControl uct = new AddTradeNetworksView();
        public UserControl UCT { get => uct; set => this.RaiseAndSetIfChanged(ref uct, value); }

        public AddTradeNetworksViewViewModel(SuharevaContext myConnection)
		{
            this.myConnection = myConnection;
            CurrentTrade = new TradeNetwork();
            myConnection.Add(CurrentTrade);
        }

        public TradeNetwork CurrentTrade { get => currentTrade; set => currentTrade = value; }

        public void SaveNetwork()
        {
            myConnection.SaveChanges();
            UCT = new TradeNetworksView();
        }
    }
}