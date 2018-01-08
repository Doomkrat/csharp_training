using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactData()
        {
        }

        public ContactData(string lastname, string firstname)
        {
            LastName = lastname;
            FirstName = firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.Equals(this.LastName, other.LastName))
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);


        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName & LastName == other.LastName;

        }
        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }
        public override string ToString()
        {
            return "firstname = <" + FirstName + ">; lastname = <" + LastName + ">";
        }
    }
}
