using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.ViewModel.Login.DataModel;

namespace TeamCityNotifier.UIController.ViewModel.Login
{
    public class LoginViewModel : Notifiable
    {
        public LoginViewModel()
        {
            LoginModel = new LoginModel();
        }

        public LoginModel LoginModel { get; }
    }
}
