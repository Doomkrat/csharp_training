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
             app.Projects.CreateIfNoProjectsPresent();
         }
 
         [Test]
         public void ProjectRemovalTest()
         {
             List<ProgectData> oldProjects = app.Projects.GetProjectList();
 
             ProgectData toBeRemoved = oldProjects[0];
 
             app.Projects.Remove(toBeRemoved);
 
             Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());
 
             List<ProgectData> newProjects = app.Projects.GetProjectList();
 
             oldProjects.RemoveAt(0);
 
             Assert.AreEqual(oldProjects, newProjects);
         }
    }
}
