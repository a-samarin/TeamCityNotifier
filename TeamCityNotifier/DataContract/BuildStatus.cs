using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityNotifier.DataContract
{
    public class BuildStatus
    {
        public int Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }
        public string StatusText { get; set; }
        public BuildType BuildType { get; set; }
        public string QueuedDate { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public Triggered Triggered { get; set; }
        public Lastchanges LastChanges { get; set; }
        public Changes Changes { get; set; }
        public Revisions Revisions { get; set; }
        public Agent Agent { get; set; }
        public Artifacts Artifacts { get; set; }
        public Relatedissues RelatedIssues { get; set; }
        public Properties Properties { get; set; }
        public Statistics Statistics { get; set; }
    }

    public class Triggered
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Href { get; set; }
    }

    public class Lastchanges
    {
        public int Count { get; set; }
        public Change[] Change { get; set; }
    }

    public class Change
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string Username { get; set; }
        public string Date { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }
    }

    public class Changes
    {
        public string Href { get; set; }
    }

    public class Revisions
    {
        public int Count { get; set; }
        public Revision[] Revision { get; set; }
    }

    public class Revision
    {
        public string Version { get; set; }
        public VcsRootInstance VcsRootInstance { get; set; }
    }

    public class VcsRootInstance
    {
        public string Id { get; set; }
        public string VcsRootid { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
    }

    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Href { get; set; }
    }

    public class Artifacts
    {
        public string Href { get; set; }
    }

    public class Relatedissues
    {
        public string Href { get; set; }
    }

    public class Properties
    {
        public int Count { get; set; }
        public Property1[] Property { get; set; }
    }

    public class Property1
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Statistics
    {
        public string Href { get; set; }
    }
        //{"id":1218,"buildTypeId":"Yangler_YanglerMobileDevDeploy","number":"102","status":"SUCCESS","state":"finished","href":"/httpAuth/app/rest/builds/id:1218","webUrl":"http://cruise.yoshinc.com/viewLog.html?buildId=1218&buildTypeId=Yangler_YanglerMobileDevDeploy","statusText":"Success","buildType":{"id":"Yangler_YanglerMobileDevDeploy","name":"Yangler Mobile Dev Deploy","description":"Yangler Platform Mobile Dev Deploy","projectName":"Yangler","projectId":"Yangler","href":"/httpAuth/app/rest/buildTypes/id:Yangler_YanglerMobileDevDeploy","webUrl":"http://cruise.yoshinc.com/viewType.html?buildTypeId=Yangler_YanglerMobileDevDeploy"},"queuedDate":"20151224T041830+0000","startDate":"20151224T041832+0000","finishDate":"20151224T041856+0000","triggered":{"type":"user","date":"20151224T041830+0000","user":{"username":"anton","name":"Anton Samarin","id":2,"href":"/httpAuth/app/rest/users/id:2"}},"lastChanges":{"count":1,"change":[{"id":155,"version":"d012e2a28ac7ecf4c2904217ce1513522889ec61","username":"anton","date":"20151011T003438+0000","href":"/httpAuth/app/rest/changes/id:155","webUrl":"http://cruise.yoshinc.com/viewModification.html?modId=155&personal=false"}]},"changes":{"href":"/httpAuth/app/rest/changes?locator=build:(id:1218)"},"revisions":{"count":1,"revision":[{"version":"d012e2a28ac7ecf4c2904217ce1513522889ec61","vcs-root-instance":{"id":"18","vcs-root-id":"Yangler_YanglerDotNet","name":"Yangler-DotNet","href":"/httpAuth/app/rest/vcs-root-instances/id:18"}}]},"agent":{"id":1,"name":"YoshDev","typeId":1,"href":"/httpAuth/app/rest/agents/id:1"},"artifacts":{"href":"/httpAuth/app/rest/builds/id:1218/artifacts/children/"},"relatedIssues":{"href":"/httpAuth/app/rest/builds/id:1218/relatedIssues"},"properties":{"count":4,"property":[{"name":"system.Configuration","value":"Debug"},{"name":"system.DeployAppPath","value":"apidev.yangler"},{"name":"system.DeployServiceUrl","value":"yoshdev.cloudapp.net:8172"},{"name":"system.ProjectName","value":"MobileApi"}]},"statistics":{"href":"/httpAuth/app/rest/builds/id:1218/statistics"}}
}
