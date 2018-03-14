//<snippet1>
using System;
using System.IO;
using System.Security.AccessControl;

namespace FileSystemExample
{
    class FileExample
    {
        public static void Main()
        {
            try
            {
                string FileName = "test.xml";

                Console.WriteLine("Adding access control entry for " + FileName);

                // Add the access control entry to the file.
                AddFileAuditRule(FileName, @"MYDOMAIN\MyAccount", FileSystemRights.ReadData, AuditFlags.Failure);

                Console.WriteLine("Removing access control entry from " + FileName);

                // Remove the access control entry from the file.
                RemoveFileAuditRule(FileName, @"MYDOMAIN\MyAccount", FileSystemRights.ReadData, AuditFlags.Failure);

                Console.WriteLine("Done.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileAuditRule(string FileName, string Account, FileSystemRights Rights, AuditFlags AuditRule)
        {


            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(FileName);

            // Add the FileSystemAuditRule to the security settings. 
            fSecurity.AddAuditRule(new FileSystemAuditRule(Account,
                                                            Rights,
                                                            AuditRule));

            // Set the new access settings.
            File.SetAccessControl(FileName, fSecurity);

        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileAuditRule(string FileName, string Account, FileSystemRights Rights, AuditFlags AuditRule)
        {

            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(FileName);

            // Add the FileSystemAuditRule to the security settings. 
            fSecurity.RemoveAuditRule(new FileSystemAuditRule(Account,
                                                            Rights,
                                                            AuditRule));

            // Set the new access settings.
            File.SetAccessControl(FileName, fSecurity);

        }
    }
}
//</snippet1>