using System;
using System.Security;
using System.Security.Permissions;
using SecurityRulesLibrary;

namespace TestSecRulesLibrary
{
   public class TestMethodLevelSecurity
   {
      MyClassWithTypeSecurity dataHolder;

      void RetrievePersonalInformation(string description) 
      {
         try 
         { 
            Console.WriteLine(
               "{0} Personal information: {1}", 
               description, dataHolder.PersonalInformation());
         }
         catch (SecurityException e) 
         {
            Console.WriteLine(
               "{0} Could not access personal information: {1}", 
               description, e.Message);
         }
      }

      [STAThread]
      public static void Main() 
      {
         TestMethodLevelSecurity me = new TestMethodLevelSecurity();

         me.dataHolder = new MyClassWithTypeSecurity(1964,06,16);

         // Local computer zone starts with all environment permissions.
         me.RetrievePersonalInformation("[All permissions]");

         // Deny the write permission required by the type.
         EnvironmentPermission epw = new EnvironmentPermission(
            EnvironmentPermissionAccess.Write,"PersonalInfo");
         epw.Deny();
         
         // Even though the type requires write permission, 
         // and you do not have it; you can get the data.
         me.RetrievePersonalInformation(
            "[No write permission (demanded by type)]");

         // Reset the permissions and try to get 
         // data without read permission.
         CodeAccessPermission.RevertAll();  

         // Deny the read permission required by the method.
         EnvironmentPermission epr = new EnvironmentPermission(
            EnvironmentPermissionAccess.Read,"PersonalInfo");
         epr.Deny();

         // The method requires read permission, and you
         // do not have it; you cannot get the data.
         me.RetrievePersonalInformation(
            "[No read permission (demanded by method)]");
      }
   }
}