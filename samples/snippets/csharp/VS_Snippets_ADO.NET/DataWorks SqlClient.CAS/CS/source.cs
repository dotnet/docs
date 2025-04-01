// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Security.Permissions;

namespace PartialTrustTopic
{
   public class PartialTrustHelper : MarshalByRefObject
   {
      public void TestConnectionOpen(string connectionString)
      {
         // Try to open a connection.
         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            connection.Open();
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         TestCAS("secure-connnection-string1", "secure-connnection-string2");
      }

      static void TestCAS(string connectString1, string connectString2)
      {
         // Create permission set for sandbox AppDomain.
         // This example only allows execution.
         PermissionSet permissions = new PermissionSet(PermissionState.None);
         permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

         // Create sandbox AppDomain with permission set that only allows execution,
         // and has no SqlClientPermissions.
         AppDomainSetup appDomainSetup = new AppDomainSetup();
         appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
         AppDomain firstDomain = AppDomain.CreateDomain("NoSqlPermissions", null, appDomainSetup, permissions);

         // Create helper object in sandbox AppDomain so that code can be executed in that AppDomain.
         Type helperType = typeof(PartialTrustHelper);
         PartialTrustHelper firstHelper = (PartialTrustHelper)firstDomain.CreateInstanceAndUnwrap(helperType.Assembly.FullName, helperType.FullName);

         try
         {
            // Attempt to open a connection in the sandbox AppDomain.
            // This is expected to fail.
            firstHelper.TestConnectionOpen(connectString1);
            Console.WriteLine("Connection opened, unexpected.");
         }
         catch (System.Security.SecurityException ex)
         {
            Console.WriteLine("Failed, as expected: {0}",
                ex.FirstPermissionThatFailed);

            // Uncomment the following line to see Exception details.
            // Console.WriteLine("BaseException: " + ex.GetBaseException());
         }

         // Add permission for a specific connection string.
         SqlClientPermission sqlPermission = new SqlClientPermission(PermissionState.None);
         sqlPermission.Add(connectString1, "", KeyRestrictionBehavior.AllowOnly);

         permissions.AddPermission(sqlPermission);

         AppDomain secondDomain = AppDomain.CreateDomain("OneSqlPermission", null, appDomainSetup, permissions);
         PartialTrustHelper secondHelper = (PartialTrustHelper)secondDomain.CreateInstanceAndUnwrap(helperType.Assembly.FullName, helperType.FullName);

         // Try connection open again, it should succeed now.
         try
         {
            secondHelper.TestConnectionOpen(connectString1);
            Console.WriteLine("Connection opened, as expected.");
         }
         catch (System.Security.SecurityException ex)
         {
            Console.WriteLine($"Unexpected failure: {ex.Message}");
         }

         // Try a different connection string. This should fail.
         try
         {
            secondHelper.TestConnectionOpen(connectString2);
            Console.WriteLine("Connection opened, unexpected.");
         }
         catch (System.Security.SecurityException ex)
         {
            Console.WriteLine("Failed, as expected: {0}", ex.Message);
         }
      }
   }
}
// </Snippet1>
