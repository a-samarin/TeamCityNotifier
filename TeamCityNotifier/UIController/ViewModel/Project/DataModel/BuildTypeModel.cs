using System;
using System.Collections.Generic;
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
        private string buildNumber;
        private string status;
        private string state;
        private int progressValue;
        private Timer timer;

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

        private int count = 0; 

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
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        public string Name => DataContract.Name;
        public string Description => DataContract.Description;
        public string WebUrl => DataContract.WebUrl;

        public string BuildNumber
        {
            get { return buildNumber; }
            set
            {
                if (buildNumber == value) return;

                buildNumber = value;
                SendPropertyChanged(nameof(BuildNumber));
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (status == value) return;

                status = value;
                SendPropertyChanged(nameof(Status));
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (state == value) return;

                state = value;
                SendPropertyChanged(nameof(State));
            }
        }

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                if (progressValue == value) return;

                progressValue = value;
                QueueForUIThread(() => SendPropertyChanged(nameof(ProgressValue)));
            }
        }

        //changes by whom and how much
        //status text
        // tooltip : build is running + build agent : Yosh

        private void LoadBuildInfo()
        {
            var info = NetworkHelper.Get<BuildTypeStatus>(string.Format(NetworkHelper.BuildStatusUrl, DataContract.Id));
        }

        public void Update(Build build)
        {
            if (build != null)
            {

            }
            else
            {
                
            }
        }
    }
}
