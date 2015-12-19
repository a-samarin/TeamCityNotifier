using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.UIController.Base;

namespace TeamCityNotifier.UIController.ViewModel.Project.DataModel
{
    public class ProjectModel : Notifiable<DataContract.Project>
    {
        private ObservableCollection<BuildTypeModel> buildTypeModels = new ObservableCollection<BuildTypeModel>();

        public ProjectModel(DataContract.Project project)
        {
            _DataContract = project;

            LoadBuildTypeModels();
        }

        public string Name => DataContract.Name;
        public string Description => DataContract.Description;
        public string WebUrl => DataContract.WebUrl;

        public ObservableCollection<BuildTypeModel> BuildTypeModels => buildTypeModels;

        private void LoadBuildTypeModels()
        {
            
        }
    }
}
