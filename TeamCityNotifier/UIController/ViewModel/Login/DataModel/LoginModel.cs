using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.Helper;

namespace TeamCityNotifier.UIController.ViewModel.Login.DataModel
{
    public class LoginModel : Notifiable<DataContract.Login>
    {
        public LoginModel()
        {
            _DataContract = DataHelper.GetLoginData();
        }

        public string TeamCityUrl
        {
            get { return DataContract.TeamCityUrl; }
            set
            {
                if (DataContract.TeamCityUrl == value) return;

                var url = value.TrimEnd('/');

                DataContract.TeamCityUrl = url;
                SendPropertyChanged(nameof(TeamCityUrl));
            }
        }

        public string Username
        {
            get { return DataContract.Username; }
            set
            {
                if (DataContract.Username == value) return;

                DataContract.Username = value;
                SendPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return DataContract.Password; }
            set
            {
                if (DataContract.Password == value) return;

                DataContract.TeamCityUrl = value;
                SendPropertyChanged(nameof(Password));
            }
        }

        public void Save()
        {
            DataHelper.SaveLoginData(DataContract);
        }
    }
}
