using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using TeamCityNotifier.DataContract;

namespace TeamCityNotifier.UIController.Helper
{
    public static class DataHelper
    {
        private static readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;

        public static void SaveData<T>(T data)
        {
            var composite = new ApplicationDataCompositeValue();

            foreach (var pi in data.GetType().GetProperties())
            {
                composite[pi.Name] = pi.GetValue(data, null);
            }

            LocalSettings.Values[typeof(T).Name] = composite;
        }

        public static T GetData<T>() where T : ObjectBase, new()
        {
            var composite = (ApplicationDataCompositeValue)LocalSettings.Values[typeof(T).Name];

            if (composite == null) return null;

            var data = new T();

            foreach (var pi in typeof(T).GetProperties())
            {
                pi.SetValue(data, composite[pi.Name], null);
            }

            return data;
        }

        public static bool Remove<T>(T data)
        {
            return LocalSettings.Values.Remove(typeof (T).Name);
        }

        public static void RemoveAll()
        {
            LocalSettings.Values.Clear();
        }


        //        public static void SaveLoginData(Login login)
        //        {
        //            localSettings.Values["teamCityUrl"] = login.TeamCityUrl;
        //            localSettings.Values["username"] = login.Username;
        //            localSettings.Values["password"] = login.Password;
        //        }
        //
        //        public static Login GetLoginData()
        //        {
        //            var login = new Login
        //            {
        //                TeamCityUrl = localSettings.Values["teamCityUrl"] as string,
        //                Username = localSettings.Values["username"] as string,
        //                Password = localSettings.Values["password"] as string
        //            };
        //
        //            return login;
        //        }

    }
}
