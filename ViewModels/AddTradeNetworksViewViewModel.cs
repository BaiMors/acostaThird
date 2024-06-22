using System;
using System.Collections.Generic;
using ReactiveUI;
using Acosta.Models;

namespace Acosta.ViewModels
{
	public class AddTradeNetworksViewViewModel : ReactiveObject
	{
		SuharevaContext myConnection;
		TradeNetwork currentTrade;

		public AddTradeNetworksViewViewModel(SuharevaContext myConnection)
		{
            this.myConnection = myConnection;
            CurrentTrade = new TradeNetwork();
            myConnection.Add(CurrentTrade);
        }

        public TradeNetwork CurrentTrade { get => currentTrade; set => currentTrade = value; }
    }
}