using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests.tests
{
    [TestFixture]
    class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProgectCreateonTest()
        {

            ProgectData progect = new ProgectData()
            {
                Name = $"Progect{DateTime.Now.Ticks}",
                Description = "somedescription"
            };

            app.Projects.DeleteIfSuchProgectExist(progect);
            List<ProgectData> oldProgects = app.Projects.GetProjectList();

            app.Projects.Create(progect);

            Assert.AreEqual(oldProgects.Count + 1, app.Projects.GetProjectCount());

            List<ProgectData> newProgects = app.Projects.GetProjectList();

            oldProgects.Add(progect);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);
        }
    }
}
