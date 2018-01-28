using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string contactInfo;

        public string allPhones;

        public string allEmails;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get {
                if (allPhones!= null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EndStringInsert(Email) + EndStringInsert(Email2)  + EndStringInsert(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        
       

        private string CleanUp(string phone)
        {
           if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
        }


        private string GetNameFull(string firstname, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = bufer + FirstName + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + LastName + " ";
            }
            return bufer.Trim();
        }

        private string GetPhoneList(string homePhone, string mobilePhone, string workPhone)
        {
            string bufer = "";
            if (homePhone != null && homePhone != "")
            {
                bufer = bufer + "H: " + EndStringInsert(HomePhone);
            }
            if (mobilePhone != null && mobilePhone != "")
            {
                bufer = bufer + "M: " + EndStringInsert(MobilePhone);
            }
            if (workPhone != null && workPhone != "")
            {
                bufer = bufer + "W: " + EndStringInsert(WorkPhone);
            }
            return bufer.Trim();
        }

        private string GetEmailList(string email, string email2, string email3)
        {
            string bufer = "";
            if (email != null && email != "")
            {
                bufer = bufer + EndStringInsert(email);
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + EndStringInsert(email2);
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + EndStringInsert(email3);
            }
            return bufer.Trim();
        }


        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;

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
        private string EndStringInsert(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return entry + "\r\n";
        }


     
        private string ContactInfoList(string firstname, string lastname, string address)
        {
            return EndStringInsert(GetNameFull(firstname, lastname))
                + EndStringInsert(address).Trim();
        }

        public string ContactInfo
        {
            get
            {
                if (contactInfo != null)
                {
                    return contactInfo;
                }
                else
                {
                    return (
                        EndStringInsert(EndStringInsert(ContactInfoList(FirstName, LastName, Address)))
                        + EndStringInsert(EndStringInsert(GetPhoneList(HomePhone, MobilePhone, WorkPhone)))
                        + EndStringInsert(EndStringInsert(GetEmailList(Email, Email2, Email3)))).Trim();
                }
            }
            set
            {
                contactInfo = value;
            }
        }

    }
}
