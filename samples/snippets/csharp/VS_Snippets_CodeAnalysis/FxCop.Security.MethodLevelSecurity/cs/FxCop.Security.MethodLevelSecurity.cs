//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace SecurityRulesLibrary
{
   [EnvironmentPermissionAttribute(SecurityAction.Demand, Write="PersonalInfo")]
   public class MyClassWithTypeSecurity
   {
      [DllImport("kernel32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
      [return:MarshalAs(UnmanagedType.Bool)]
      public static extern bool SetEnvironmentVariable(
         string lpName,
         string lpValue);

      // Constructor.
      public MyClassWithTypeSecurity(int year, int month, int day)
      {
         DateTime birthday = new DateTime(year, month, day);

         // Write out PersonalInfo environment variable.
         SetEnvironmentVariable("PersonalInfo",birthday.ToString());
      }

      [EnvironmentPermissionAttribute(SecurityAction.Demand, Read="PersonalInfo")]
      public string PersonalInformation ()
      { 
         // Read the variable.
         return Environment.GetEnvironmentVariable("PersonalInfo"); 
      }
   }
}
//</Snippet1>
