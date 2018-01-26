using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);//amount of the test data which we want to generate
            StreamWriter writer = new StreamWriter(args[1]);/*creating new instance "writer" with an argument 
            as name of the file which will be defined when we will launchd our generator*/
            string format = args[2];
            string typeOfData = args[3];

            if (typeOfData == "gr")
            {

                List<GroupData> groups = GenerateGroupList(count);

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Format doesnt exist");
                }

                writer.Close();
            }
            else if (typeOfData == "cont")
            {
                List<ContactData> contacts = GenerateConactList(count);
                
                if (format == "csv")
                {
                    writeContatcsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Format doesnt exist");
                }

                writer.Close();
            }
        }

        private static List<GroupData> GenerateGroupList(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            return groups;
        }

        private static List<ContactData> GenerateConactList(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = TestBase.GenerateRandomString(10),
                    LastName = TestBase.GenerateRandomString(10),
                   MobilePhone = TestBase.GenerateRandomString(10),
                   Address = TestBase.GenerateRandomString(10),
                });
            }
            return contacts;
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContatcsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3}",
                    contact.FirstName, contact.LastName, contact.MobilePhone, contact.Address));
            }
        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
