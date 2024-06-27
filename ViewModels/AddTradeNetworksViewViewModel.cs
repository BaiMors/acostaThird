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
        SuharevaContext myC;
        TradeNetwork? currentTrade;

        public AddTradeNetworksViewViewModel(SuharevaContext myC)
        {
            this.myC = myC;
            CurrentTrade = new TradeNetwork();
            myC.Add(CurrentTrade);
        }

        public TradeNetwork? CurrentTrade { get => currentTrade; set => currentTrade = value; }
    }
}