//<SnippetDetectPermsCODE1>
using System.IO; // File, FileStream, StreamWriter
using System.IO.IsolatedStorage; // IsolatedStorageFile
using System.Security; // CodeAccesPermission, IsolatedStorageFileStream
using System.Security.Permissions; // FileIOPermission, FileIOPermissionAccess
using System.Windows; // MessageBox

namespace SDKSample
{
    public class FileHandling
    {
        public void Save()
        {
            if (IsPermissionGranted(new FileIOPermission(FileIOPermissionAccess.Write, @"c:\newfile.txt")))
            {
                // Write to local disk
                using (FileStream stream = File.Create(@"c:\newfile.txt"))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("I can write to local disk.");
                }
            }
            else
            {
                MessageBox.Show("I can't write to local disk.");
            }
        }

        // Detect whether or not this application has the requested permission
        bool IsPermissionGranted(CodeAccessPermission requestedPermission)
        {
            try
            {
                // Try and get this permission
                requestedPermission.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //</SnippetDetectPermsCODE1>
        //<SnippetDetectPermsCODE2>
    }
}
//</SnippetDetectPermsCODE2>