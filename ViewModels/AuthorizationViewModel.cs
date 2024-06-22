using System;
using System.Collections.Generic;
using ReactiveUI;

namespace Acosta.ViewModels
{
	public class AuthorizationViewModel : ReactiveObject
	{
        string login = "";
        string password = "";
        string message = "";

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }
    }
}