﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
   public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux; //link
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
            aux = new AutoItX3(); //innitialize
            aux.Run(@"C:\Program Files (x86)\GAS Softwares\Free Address Book\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE,"", "WindowsForms10.BUTTON.app.0.1114f8110");
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public AutoItX3 Aux //access to aux
        {
            get
            {
                return aux;
            }
        }
    }
}
