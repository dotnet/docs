// <snippet15>
using System;
using System.IO;
using System.Security.AccessControl;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorySecurity securityRules = new DirectorySecurity();
            securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\account1", FileSystemRights.Read, AccessControlType.Allow));
            securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\account2", FileSystemRights.FullControl, AccessControlType.Allow));

            DirectoryInfo di = Directory.CreateDirectory(@"C:\destination\NewDirectory", securityRules);
        }
    }
}
// </snippet15>
