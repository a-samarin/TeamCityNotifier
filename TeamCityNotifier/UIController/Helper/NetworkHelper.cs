using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Security.Credentials;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamCityNotifier.DataContract;

namespace TeamCityNotifier.UIController.Helper
{
    public static class NetworkHelper
    {
        #region Private Const

        private const string ProjectResourceUrl = "/httpAuth/app/rest/projects";
        private const string BuildTypesResourceUrl = "/httpAuth/app/rest/buildTypes";
        private const string BuildStatusResourceUrl = "/httpAuth/app/rest/buildTypes/id:{0}/builds/branch:(default:any)";
        private const string RunningBuildsResourceUrl = "/httpAuth/app/rest/builds?locator=running:true,branch:(default:any)";
        private const string BuildQueueResourceUrl = "/httpAuth/app/rest/buildQueue";

        // build types for Yangler project "/httpAuth/app/rest/buildTypes?locator=project:Yangler"
        // full Yangler project "/httpAuth/app/rest/projects/id:Yangler"
        // running builds for Yangler project "/httpAuth/app/rest/builds?locator=running:true,branch:(default:any),project:Yangler"
        #endregion //Private Const

        #region Public Properties

        public static Login Login { get; set; }

        public static string TeamCityUrl => Login.TeamCityUrl;

        public static string Username => Login.Username;

        public static string Password => Login.Password;

        public static bool IsLoggedIn => !string.IsNullOrEmpty(TeamCityUrl)
                                         && !string.IsNullOrEmpty(Username)
                                         && !string.IsNullOrEmpty(Password);

        public static string ProjectsUrl => TeamCityUrl + ProjectResourceUrl;

        public static string BuildTypesUrl => TeamCityUrl + BuildTypesResourceUrl;

        public static string RunningBuildsUrl => TeamCityUrl + BuildStatusResourceUrl;

        public static string BuildStatusUrl => TeamCityUrl + RunningBuildsResourceUrl;

        public static string BuildQueueUrl => TeamCityUrl + BuildQueueResourceUrl;

        #endregion //Public Properties

        #region Constructors

        static NetworkHelper()
        {
            Login = DataHelper.GetData<Login>();
        }

        #endregion //Constructors

        #region Public Methods

//        public static List<BuildType> GetBuildTypes(string url)
//        {
//            try
//            {
//                var json = GetJson(url);
//
//                var models = JsonConvert.DeserializeObject<RootBuildType>(json);
//
//                return models.BuildType;
//
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

        public static T Get<T>(string url) where T : ObjectBase
        {
            try
            {
                var json = GetJson(url);

                var model = JsonConvert.DeserializeObject<T>(json);

                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<T> GetList<T>(string url) where T: ObjectBase
        {
            try
            {
                
                var json = GetJson(url);

                JObject jo = JObject.Parse(json);
                var models = jo.SelectToken(FirstCharacterToLower(typeof(T).Name), false).ToObject<List<T>>();

                return models;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<T> GetJson<T>(string url) where T : ObjectBase
        {
            try
            {
                var json = GetJson(url);

                var models = JsonConvert.DeserializeObject<List<T>>(json);

                return models;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetJson(string url)
        {
            try
            {
                using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(Username, Password) })
                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var getJson = client.GetAsync(url);

                    var json = getJson.Result.Content.ReadAsStringAsync();

                    return json.Result;
                }

//                var f = new HttpBaseProtocolFilter();
//                f.ServerCredential = new PasswordCredential(url, Username, Password);
//
//                var client = new HttpClient(f);
//
//                var getJson = client.GetAsync(new Uri(url));
//
//                var json = getJson.GetResults().Content.ReadAsStringAsync();

                //var model = JsonConvert.DeserializeObject<List<T>>(json.GetResults());

                //return json.GetResults();

                //                    List < Job > model = null;
                //                var client = new HttpClient();
                //                var task = client.GetAsync("http://api.usa.gov/jobs/search.json?query=nursing+jobs")
                //                  .ContinueWith((taskwithresponse) =>
                //                  {
                //                      var response = taskwithresponse.Result;
                //                      var jsonString = response.Content.ReadAsStringAsync();
                //                      jsonString.Wait();
                //                      model = JsonConvert.DeserializeObject<List<Job>>(jsonString.Result);
                //
                //                  });
                //                task.Wait();

                //
                //                var request = (HttpWebRequest)WebRequest.Create(url);
                //                request.Accept = "application/json";
                //                request.Headers.Add("ts", DateTime.Now.ToFileTime().ToString());
                //                request.Credentials = new NetworkCredential(Username, Password);
                //
                //                var response = request.GetResponse().GetResponseStream();
                //                if (response == null)
                //                {
                //                    return null;
                //                }
                //
                //                var reader = new StreamReader(response);
                //                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FirstCharacterToLower(string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
                return str;

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        #endregion //Public Methods
    }
}
