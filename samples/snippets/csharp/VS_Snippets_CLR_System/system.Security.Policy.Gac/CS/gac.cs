//<Snippet1>
using System;
using System.Security.Policy;
using System.Security;
using System.Security.Permissions;

namespace GacClass
{
    class GacDemo
    {
        [STAThread]
        static void Main(string[] args)
        {
            //<Snippet2>
            GacInstalled myGacInstalled = new GacInstalled();
            //</Snippet2>

            //<Snippet3>
            Object [] hostEvidence = {myGacInstalled};
            Object [] assemblyEvidence = {};
            Evidence myEvidence = new Evidence(hostEvidence,assemblyEvidence);
            GacIdentityPermission myPerm = 
                (GacIdentityPermission)myGacInstalled.CreateIdentityPermission(
                myEvidence);
            Console.WriteLine(myPerm.ToXml().ToString());
            //</Snippet3>

            //<Snippet4>
            GacInstalled myGacInstalledCopy = 
                (GacInstalled)myGacInstalled.Copy();
            bool result = myGacInstalled.Equals(myGacInstalledCopy);
            //</Snippet4>

            //<Snippet5>
            Console.WriteLine(
                "Hashcode = " + myGacInstalled.GetHashCode().ToString());
            //</Snippet5>

            //<Snippet6>
            Console.WriteLine(myGacInstalled.ToString());
            //</Snippet6>
        }
    }
}
//</Snippet1>
