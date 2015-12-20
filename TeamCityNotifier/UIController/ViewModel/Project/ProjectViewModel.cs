using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.Helper;
using TeamCityNotifier.UIController.ViewModel.Project.DataModel;

namespace TeamCityNotifier.UIController.ViewModel.Project
{
    public class ProjectViewModel : Notifiable
    {
        private ObservableCollection<ProjectModel> projectModels = new ObservableCollection<ProjectModel>(); 

        public ProjectViewModel()
        {
            LoadProjects();
        }

        public ObservableCollection<ProjectModel> ProjectModelList => projectModels;

        private void LoadProjects()
        {
            var projectList = NetworkHelper.GetList<DataContract.Project>(NetworkHelper.ProjectsUrl);


            //ProjectModelList.Add();
        }
    }
}
