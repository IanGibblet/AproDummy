using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprocoDummy.SupportClasses
{
    class AproSupport
    {

        //Fixes odd problem of JSON coming from restea with extra slashes addedd to json
        public static string FixJSonString(string StringToFix)      
        {

            StringToFix = StringToFix.Replace("\\", "");
            string trimmed = StringToFix.Substring(1, StringToFix.Length - 1);
            string trimmed2 = trimmed.Substring(0, trimmed.Length - 1);
            return trimmed2;

        }


    }
}
