using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = GenerateRandomString(20),
                    LastName = GenerateRandomString(20)
                });
            }
            return contacts;
        }


        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData()
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    MobilePhone = parts[2],
                    Address = parts[3]
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) //приведение типа
                new XmlSerializer(typeof(List<ContactData>))//чтение данных типа List<GroupData>
                .Deserialize(new StreamReader(@"contacts.xml"));//из указаного файла
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
               File.ReadAllText(@"contacts.json"));

        }


        [Test,TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitContactCreation();
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoToHomePage();
            Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
