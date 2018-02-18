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
            List<ProgectData> oldProgects = app.Progects.GetProgectList();

            ProgectData progect = new ProgectData()
            {
                Name = $"Progect{DateTime.Now.Ticks}",
                Description = "somedescription"
            };

            app.Progects.Create(progect);

            Assert.AreEqual(oldProgects.Count + 1, app.Progects.GetProgectCount());

            List<ProgectData> newProgects = app.Progects.GetProgectList();

            oldProgects.Add(progect);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);
        }
    }
}
