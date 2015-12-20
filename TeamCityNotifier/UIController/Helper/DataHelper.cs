using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using TeamCityNotifier.DataContract;

namespace TeamCityNotifier.UIController.Helper
{
    public static class DataHelper
    {
        private static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public static void SaveLoginData(Login login)
        {
            localSettings.Values["teamCityUrl"] = login.TeamCityUrl;
            localSettings.Values["username"] = login.Username;
            localSettings.Values["password"] = login.Password;
        }

        public static Login GetLoginData()
        {
            var login = new Login
            {
                TeamCityUrl = localSettings.Values["teamCityUrl"] as string,
                Username = localSettings.Values["username"] as string,
                Password = localSettings.Values["password"] as string
            };

            return login;
        }
        
        public static void SaveData<T>(T data)
        {
            ApplicationDataCompositeValue composite = new ApplicationDataCompositeValue();
            //            localSettings.Values["teamCityUrl"] = login.TeamCityUrl;
            //            localSettings.Values["username"] = login.Username;
            //            localSettings.Values["password"] = login.Password;
        }

        public static T GetData<T>() where T : ObjectBase, new()
        {
            ApplicationDataCompositeValue composite =
               (ApplicationDataCompositeValue)localSettings.Values["exampleCompositeSetting"];

            if (composite == null) return default(T);

            return new T();
            //            var login = new Login
            //            {
            //                TeamCityUrl = localSettings.Values["teamCityUrl"] as string,
            //                Username = localSettings.Values["username"] as string,
            //                Password = localSettings.Values["password"] as string
            //            };
            //
            //            return login;
        }

        
    }
}
