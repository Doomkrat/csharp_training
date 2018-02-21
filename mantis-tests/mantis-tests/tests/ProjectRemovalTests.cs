using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]

    public class ProjectRemovalTests:AuthTestBase
    {
        [SetUp]
         public void SetupAppProgectRemovalTest()
         {
            ProjectData project = new ProjectData()
            {
                Name = "Progect1",
            };

            app.Projects.CreateIfNoProjectsPresent(account, project);
        }

        [Test]
         public void ProjectRemovalTest()
         {
             List<ProjectData> oldProjects = app.Projects.GetProjectList(account);
 
             ProjectData toBeRemoved = oldProjects[0];
 
             app.Projects.Remove(toBeRemoved);
 
             Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());
 
             List<ProjectData> newProjects = app.Projects.GetProjectList(account);
 
             oldProjects.RemoveAt(0);
 
             Assert.AreEqual(oldProjects, newProjects);
         }
    }
}
