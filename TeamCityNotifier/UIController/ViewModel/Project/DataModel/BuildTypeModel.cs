using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.DataContract;
using TeamCityNotifier.UIController.Base;

namespace TeamCityNotifier.UIController.ViewModel.Project.DataModel
{
    public class BuildTypeModel : Notifiable<BuildType>
    {
        private string status;
        private string state;

        public BuildTypeModel(BuildType buildType)
        {
            _DataContract = buildType;
        }

        public string Name => DataContract.Name;
        public string Description => DataContract.Description;
        public string WebUrl => DataContract.WebUrl;

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
    }
}
