using Acosta.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace Acosta.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); }
        private UserControl uc = new AuthorizationView();

        public void LoadPersonalAccount()
        {
            UC = new OutletsView();//PersonalAccountView();
        }
        public void ExitFromProfile()
        {
            UC = new AuthorizationView();
        }
        public void AddTradeNetworksView()
        {
            UC = new AddTradeNetworksView();
        }
        public void BackTradeNetworksView()
        {
            UC = new TradeNetworksView();
        }
        public void AddOutletsView()
        {
            UC = new AddOutletsView();
        }
        public void BackOutletsView()
        {
            UC = new OutletsView();
        }
        public void EditOutletsView()
        {
            UC = new EditOutletsView();
        }
    }
}
