using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]

    public class ProgectRemovalTests:AuthTestBase
    {
        [SetUp]
         public void SetupAppProgectRemovalTest()
         {
             app.Progects.CreateIfNoProgectsPresent();
         }
 
         [Test]
         public void ProgectRemovalTest()
         {
             List<ProgectData> oldProgects = app.Progects.GetProgectList();
 
             ProgectData toBeRemoved = oldProgects[0];
 
             app.Progects.Remove(toBeRemoved);
 
             Assert.AreEqual(oldProgects.Count - 1, app.Progects.GetProgectCount());
 
             List<ProgectData> newProgects = app.Progects.GetProgectList();
 
             oldProgects.RemoveAt(0);
 
             Assert.AreEqual(oldProgects, newProgects);
         }
    }
}
