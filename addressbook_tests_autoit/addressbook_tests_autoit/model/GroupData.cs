﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupData : IComparable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        { 

            return this.Name.CompareTo(other.Name);
        }
    }
}
