using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.DataContract;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.Helper;

namespace TeamCityNotifier.UIController.ViewModel.Project.DataModel
{
    public class ProjectModel : Notifiable<DataContract.Project>
    {
        public ProjectModel(DataContract.Project project)
        {
            _DataContract = project;

            //LoadBuildTypeModels();
        }

        public string Name => DataContract.Name;
        public string Description => DataContract.Description;
        public string WebUrl => DataContract.WebUrl;

        public ObservableCollection<BuildTypeModel> BuildTypeModels { get; } = new ObservableCollection<BuildTypeModel>();

        public void LoadBuildTypeModels(List<BuildType> buildTypes)
        {
            //var buildTypeList = NetworkHelper.GetList<BuildType>(NetworkHelper.BuildTypesUrl);
            buildTypes.ForEach(bt => BuildTypeModels.Add(new BuildTypeModel(bt)));
        }
    }
}
