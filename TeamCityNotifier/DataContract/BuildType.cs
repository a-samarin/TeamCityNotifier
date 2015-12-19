using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace TeamCityNotifier.DataContract
{
    public class RootBuildType
    {
        public int Count { get; set; }
        public string Href { get; set; }
        public List<BuildType> BuildType { get; set; }
    }

    public class BuildType : ObjectBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }

    }

    public class Build : ObjectBase
    {
        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Running { get; set; }
        public string PercentageComplete { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }

    }

    //status:<SUCCESS/FAILURE/ERROR> - list builds with the specified status only
    //canceled:<true/false/any> - limit builds by a canceled flag.
    //running:<true/false/any> - limit builds by a running flag.

    //running
    //<build id="1172" buildTypeId="Yangler_YanglerMobileDevDeploy" number="92" status="SUCCESS" state="running" running="true" percentageComplete="12" href="/httpAuth/app/rest/builds/id:1172" webUrl="http://cruise.yoshinc.com/viewLog.html?buildId=1172&buildTypeId=Yangler_YanglerMobileDevDeploy"/>

    //queue
    //<build id = "1174" buildTypeId="YoshManagementPlatform_YoshDevBuild" state="queued" href="/httpAuth/app/rest/buildQueue/id:1174" webUrl="http://cruise.yoshinc.com/viewQueued.html?itemId=1174"/>
}

//{"count":8,"href":"/httpAuth/app/rest/buildTypes","buildType":[{"id":"Yangler_YanglerMobileDevDeploy","name":"Yangler Mobile Dev Deploy","description":"Yangler Platform Mobile Dev Deploy","projectName":"Yangler","projectId":"Yangler","href":"/httpAuth/app/rest/buildTypes/id:Yangler_YanglerMobileDevDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=Yangler_YanglerMobileDevDeploy"},{"id":"Yangler_YanglerTrackerDevDeploy","name":"Yangler Tracker Dev Deploy","description":"Yangler Platform Tracker Dev Deploy","projectName":"Yangler","projectId":"Yangler","href":"/httpAuth/app/rest/buildTypes/id:Yangler_YanglerTrackerDevDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=Yangler_YanglerTrackerDevDeploy"},{"id":"YoshManagementPlatform_YoshDevBuild","name":"Yosh Dev Build","description":"Yosh Management Platform Dev Build","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshDevBuild","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshDevBuild"},{"id":"YoshManagementPlatform_YoshDevDeploy","name":"Yosh Dev Deploy","description":"Yosh Management Platform Dev Deploy","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshDevDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshDevDeploy"},{"id":"YoshManagementPlatform_YoshApiDevDeploy","name":"Yosh Dev Mobile API Deploy","description":"Yosh Mobile API Dev Deploy","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshApiDevDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshApiDevDeploy"},{"id":"YoshManagementPlatform_YoshProdBuild","name":"Yosh Prod Build","description":"Yosh Management Platform Prod Build","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshProdBuild","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshProdBuild"},{"id":"YoshManagementPlatform_YoshProdDeploy","name":"Yosh Prod Deploy","description":"Yosh Management Platform Prod Deploy","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshProdDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshProdDeploy"},{"id":"YoshManagementPlatform_YoshMobileApiProdDeploy","name":"Yosh Prod Mobile API Deploy","description":"Yosh Mobile API Prod Deploy","projectName":"Yosh Management Platform","projectId":"YoshManagementPlatform","href":"/httpAuth/app/rest/buildTypes/id:YoshManagementPlatform_YoshMobileApiProdDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=YoshManagementPlatform_YoshMobileApiProdDeploy"}]}
//public class Rootobject
//{
//    public int count { get; set; }
//    public string href { get; set; }
//    public Buildtype[] buildType { get; set; }
//}
//
//public class Buildtype
//{
//    public string id { get; set; }
//    public string name { get; set; }
//    public string description { get; set; }
//    public string projectName { get; set; }
//    public string projectId { get; set; }
//    public string href { get; set; }
//    public string webUrl { get; set; }
//}

