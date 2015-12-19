﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.UIController.Base;

namespace TeamCityNotifier.UIController.ViewModel.Login.DataModel
{
    public class LoginModel : Notifiable<DataContract.Login>
    {
        public LoginModel()
        {
            _DataContract = new DataContract.Login();

            DataContract.TeamCityUrl = "TeamCityUrl 1";
            DataContract.Username = "Username 1";
            DataContract.Password = "Password 1";
        }

        public string TeamCityUrl
        {
            get { return DataContract.TeamCityUrl; }
            set
            {
                if (DataContract.TeamCityUrl == value) return;

                DataContract.TeamCityUrl = value;
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
    }
}
