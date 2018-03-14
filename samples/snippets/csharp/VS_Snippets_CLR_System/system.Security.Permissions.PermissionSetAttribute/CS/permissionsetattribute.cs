//<Snippet1>
// The #define statement for BuildFile must be included the first time this sample is run.  
// This causes the sample to create a file named 'LocalIntranet.xml' in the c:\temp folder.  
// After creating the LocalInternet.xml file, comment out the #define statement and rerun 
// the sample to demonstrate the use of the permission set attribute.
#define BuildFile
using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Collections;
using System.IO;

namespace PermissionSetAttributeDemo
{
    class Class1
    {		
        [STAThread]
        static void Main(string[] args)
        {
            // Run this sample with the BuildFile symbol defined to create the required file, then
            // comment out the #define statement to demonstrate the use of the attribute.
#if(BuildFile)
            using (StreamWriter sw = new StreamWriter("c:\\temp\\LocalIntranet.xml")) 
            {
                sw.WriteLine(GetNamedPermissionSet("LocalIntranet"));
                sw.Close();
            }
#endif
#if(!BuildFile)
            ReadFile1();
            ReadFile2();
            ReadFile3();
            Console.WriteLine("Press the Enter key to exit.");
            Console.Read();
#endif
        }
#if(!BuildFile)
        // Read the LocalIntranet.xml file.
        static void ReadFile1()
        {
            try
            {
                Console.WriteLine("Attempting to read a file using the FullTrust permission set.");
                using (StreamReader sr = new StreamReader("c:\\temp\\LocalIntranet.xml")) 
                {
                    string permissionSet = sr.ReadToEnd();
                    sr.Close();
                }
                Console.WriteLine("The file was successfully read.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //<Snippet2>
        [PermissionSetAttribute(SecurityAction.PermitOnly, File = "c:\\temp\\LocalIntranet.xml")]
            //</Snippet2>
            // Read the file with the specified security action on the file path.
        static void ReadFile2()
        {
            try
            {
                Console.WriteLine("Attempting to read a file using the LocalIntranet permission set.");
                using (StreamReader sr = new StreamReader("c:\\temp\\LocalIntranet.xml")) 
                {
                    string permissionSet = sr.ReadToEnd();
                    sr.Close();
                }
                Console.WriteLine("The file was successfully read.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //<Snippet3>
        [PermissionSetAttribute(SecurityAction.PermitOnly, Name = "LocalIntranet")]
            //</Snippet3>
            // Read the file with the specified security action on the permission set.
        static void ReadFile3()
        {
            try
            {
                Console.WriteLine("\nSecond attempt to read a file using " + 
                    "the LocalIntranet permission set.");
                using (StreamReader sr = new StreamReader("c:\\temp\\LocalIntranet.xml")) 
                {
                    string permissionSet = sr.ReadToEnd();
                    sr.Close();
                }
                Console.WriteLine("The file was successfully read.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
#endif
        // Locate the named permission set at the Machine level and return it as a string value.
        private static string GetNamedPermissionSet(string name)
        {
            IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
            // Move through the policy levels to the Machine Level.
            while(policyEnumerator.MoveNext())
            {
                PolicyLevel currentLevel = (PolicyLevel)policyEnumerator.Current;
                if(currentLevel.Label == "Machine")
                {
                    // Iterate through the permission sets at the Machine level.
                    IList namedPermissions = currentLevel.NamedPermissionSets;
                    IEnumerator namedPermission = namedPermissions.GetEnumerator();
                    // Locate the named permission set.
                    while(namedPermission.MoveNext())
                    {
                        if(((NamedPermissionSet)namedPermission.Current).Name == name)
                        {
                            return ((NamedPermissionSet)namedPermission.Current).ToString();
                        }
   
                    }
                }
            }
            return null;
        }
    }
}
//
// This sample produces the following output:
//
// File created at c:\temp\LocalIntranet.xml
// Uncomment the BuildFile=false line and run the sample again.
//
// This sample completed successfully; press Exit to continue.
//
//
// The second time the sample is ran (without DEBUG flag):
//
// Attempting to read a file using the FullTrust permission set.
// The file was successfully read.
// Attempting to read a file using the LocalIntranet permission set.
// Request for the permission of type
// System.Security.Permissions.FileIOPermission, mscorlib, Version=1.0.5000.0,
// Culture=neutral, PublicKeyToken=b77a5c561934e089 failed.
//
// Second attempt to read a file using the LocalIntranet permission set.
// Request for the permission of type System.Security.Permissions.FileIOPermission,
// mscorlib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// failed.
// Press the Enter key to exit.
//</Snippet1>
