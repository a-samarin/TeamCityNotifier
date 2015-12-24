using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamCityNotifier.DataContract;
using TeamCityNotifier.UIController.Base;
using TeamCityNotifier.UIController.Helper;
using TeamCityNotifier.UIController.ViewModel.Project.DataModel;

namespace TeamCityNotifier.UIController.ViewModel.Project
{
    public class ProjectViewModel : Notifiable
    {
        private Timer timer;

        public ProjectViewModel()
        {
            LoadProjects();

            timer = new Timer(UpdateBuilds, null, 0, 20000);
        }

        public ObservableCollection<ProjectModel> ProjectModels { get; } = new ObservableCollection<ProjectModel>();

        private void LoadProjects()
        {
            var projectList = NetworkHelper.GetList<DataContract.Project>(NetworkHelper.ProjectsUrl);

            projectList.Where(p => !p.Id.Equals("_Root")).ToList().ForEach(p => ProjectModels.Add(new ProjectModel(p)));

            var buildTypeList = NetworkHelper.GetList<BuildType>(NetworkHelper.BuildTypesUrl);

            foreach (var pm in ProjectModels)
            {
                var btList = buildTypeList.Where(bt => bt.ProjectId == pm.DataContract.Id).ToList();
                pm.LoadBuildTypeModels(btList);
            }
        }

        private void UpdateBuilds(object state)
        {
            var runningBuilds = NetworkHelper.GetList<Build>(NetworkHelper.RunningBuildsUrl);

            foreach (var pm in ProjectModels)
            {
                var runningList = runningBuilds?.Where(r => pm.BuildTypeModels.Any(bt => bt.DataContract.Id == r.BuildTypeId)).ToList();
                pm.UpdateBuildTypeModels(runningList);
            }
        }
    }
}
