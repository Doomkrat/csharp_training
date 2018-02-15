using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    
    [TestFixture]
    public class AccountCreationTest:TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            var currentdir = TestContext.CurrentContext.WorkDirectory;
            app.Ftp.BackupFile($"{currentdir}/config_inc.php");
            using (Stream localFile = File.Open($"{currentdir}/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload(("/config_inc.php"), localFile);
            }
        }


        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
