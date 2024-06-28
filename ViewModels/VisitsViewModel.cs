using System;
using System.Collections.Generic;
using System.Linq;
using Acosta.Models;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class VisitsViewModel : ReactiveObject
	{
        SuharevaContext myConnection;
        Visit? currentVisit;

        public VisitsViewModel(SuharevaContext myConnection)
        {
            this.myConnection = myConnection;
            CurrentVisit = myConnection.Visits.FirstOrDefault();
        }

        
        public Visit? CurrentVisit { get => currentVisit; set => currentVisit = value; }
    }
}