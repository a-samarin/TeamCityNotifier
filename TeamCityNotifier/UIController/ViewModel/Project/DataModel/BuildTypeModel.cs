using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using TeamCityNotifier.DataContract;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.Helper;

namespace TeamCityNotifier.UIController.ViewModel.Project.DataModel
{
    public class BuildTypeModel : Notifiable<BuildType>
    {
        private string _buildNumber;
        private string _status;
        private string _state;
        private bool _isRunning;
        private int _progressValue;
        private BuildTypeStatus _buildTypeStatus;
        private readonly Timer _timer;

        public BuildTypeModel(BuildType buildType)
        {
            _DataContract = buildType;

            //timer = new  Timer(Callback, null, 5000, 50 /*Timeout.Infinite*/);

            //            for (int i = 0; i < 10; i++)
            //            {
            //                Task.Delay(TimeSpan.FromSeconds(1)).Wait(1000);
            //                Name1 = Name1 + i.ToString();
            //            }

            LoadBuildInfo();
        }

        private void Callback(object state)
        {
            if (ProgressValue < 100)
            {
                QueueForUIThread(() =>
                {
                    ProgressValue++;
                });
            }
            else
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        public string Name => DataContract.Name;
        public string Description => DataContract.Description;
        public string WebUrl => DataContract.WebUrl;

        public string BuildNumber => $"#{_buildTypeStatus?.Number}";

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status == value) return;

                _status = value;
                SendPropertyChanged(nameof(Status));
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;

                _state = value;
                SendPropertyChanged(nameof(State));
            }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (value == _isRunning) return;

                _isRunning = value;
                SendPropertyChanged(nameof(IsRunning));
            }
        }

        public int ProgressValue
        {
            get { return _progressValue; }
            set
            {
                if (_progressValue == value) return;

                _progressValue = value;
                SendPropertyChanged(nameof(ProgressValue));
            }
        }

        public bool IsChanged => false/*_buildTypeStatus?.LastChanges.Count > 0*/;

        public string ChangesText =>  "Unknown"/*$"{_buildTypeStatus?.Triggered.User.Name} ({_buildTypeStatus?.LastChanges.Count})"*/;


        //changes by whom and how much
        //status text
        // tooltip : build is running + build agent : Yosh

        private void LoadBuildInfo()
        {
            _buildTypeStatus = NetworkHelper.Get<BuildTypeStatus>(string.Format(NetworkHelper.BuildStatusUrl, DataContract.Id));
            UpdateUiProperties();
        }

        private void UpdateUiProperties()
        {
            SendPropertyChanged(nameof(BuildNumber));
            SendPropertyChanged(nameof(Status));
            SendPropertyChanged(nameof(IsRunning));
            SendPropertyChanged(nameof(IsChanged));
            SendPropertyChanged(nameof(ChangesText));
        }

        protected string GetLastRunText()
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            try
            {
                var dateTime = DateTimeOffset.ParseExact(_buildTypeStatus.StartDate, "yyyyMMdd'T'HHmmsszzz", CultureInfo.InvariantCulture);

                var timeSpan = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
                double delta = Math.Abs(timeSpan.TotalSeconds);

                if (delta < 1 * minute)
                {
                    return timeSpan.Seconds == 1 ? "one second ago" : timeSpan.Seconds + " seconds ago";
                }
                if (delta < 2 * minute)
                {
                    return "a minute ago";
                }
                if (delta < 45 * minute)
                {
                    return timeSpan.Minutes + " minutes ago";
                }
                if (delta < 90 * minute)
                {
                    return "an hour ago";
                }
                if (delta < 24 * hour)
                {
                    return timeSpan.Hours + " hours ago";
                }
                if (delta < 48 * hour)
                {
                    return "yesterday";
                }
                if (delta < 30 * day)
                {
                    return timeSpan.Days + " days ago";
                }

                if (delta < 12 * month)
                {
                    int months = Convert.ToInt32(Math.Floor((double)timeSpan.Days / 30));
                    return months <= 1 ? "one month ago" : months + " months ago";
                }
                else
                {
                    int years = Convert.ToInt32(Math.Floor((double)timeSpan.Days / 365));
                    return years <= 1 ? "one year ago" : years + " years ago";
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public void Update(Build build)
        {
            if (build != null)
            {

            }
            else if(IsRunning)
            {
                
            }
        }
    }
}
