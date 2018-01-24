using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);//amount of the test data which we want to generate
            StreamWriter writer = new StreamWriter(args[1]);/*creating new instance "writer" with an argument 
            as name of the file which will be defined when we will launchd our generator*/
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                   TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                     TestBase.GenerateRandomString(10)
                ));
            }

        }
    }
}
