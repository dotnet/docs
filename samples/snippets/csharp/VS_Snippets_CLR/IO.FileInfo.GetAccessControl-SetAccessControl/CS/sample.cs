//<SNIPPET1>
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
                string FileName = "c:/test.xml";

                Console.WriteLine("Adding access control entry for " + FileName);

                // Add the access control entry to the file.
                // Before compiling this snippet, change MyDomain to your 
                // domain name and MyAccessAccount to the name 
                // you use to access your domain.
                AddFileSecurity(FileName, @"MyDomain\MyAccessAccount", FileSystemRights.ReadData, AccessControlType.Allow);

                Console.WriteLine("Removing access control entry from " + FileName);

                // Remove the access control entry from the file.
                // Before compiling this snippet, change MyDomain to your 
                // domain name and MyAccessAccount to the name 
                // you use to access your domain.
                RemoveFileSecurity(FileName, @"MyDomain\MyAccessAccount", FileSystemRights.ReadData, AccessControlType.Allow);

                Console.WriteLine("Done.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);

            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = fInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            fSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));

            // Set the new access settings.
            fInfo.SetAccessControl(fSecurity);

        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);

            // Get a FileSecurity object that represents the 
            // current security settings.
            FileSecurity fSecurity = fInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));

            // Set the new access settings.
            fInfo.SetAccessControl(fSecurity);

        }
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Adding access control entry for c:\test.xml
//Removing access control entry from c:\test.xml
//Done.
//
//</SNIPPET1>