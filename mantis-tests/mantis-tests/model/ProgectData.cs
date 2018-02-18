using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProgectData : IEquatable<ProgectData>, IComparable<ProgectData>
    {
        public string Name { get; set; }
         public string Description { get; set; }
 
         public ProgectData()
         {
         }
 
         public bool Equals(ProgectData other)
         {
             if (Object.ReferenceEquals(other, null))
             {
                 return false;
             }
             if (Object.ReferenceEquals(this, other))
             {
                            return true;
                        }
             return Name == other.Name;
         }
 
         public override string ToString()
         {
             return "project name = <" + Name + ">";
         }
 
         public int CompareTo(ProgectData other)
         {
             if (Object.ReferenceEquals(other, null))
             {
                 return 1;
             }
             return Name.CompareTo(other.Name);
         }
    }
}
