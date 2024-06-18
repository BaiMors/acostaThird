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
            UC = new PersonalAccountView();

        }

    }
}
