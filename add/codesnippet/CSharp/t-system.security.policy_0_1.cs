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
            GacInstalled myGacInstalled = new GacInstalled();

            Object [] hostEvidence = {myGacInstalled};
            Object [] assemblyEvidence = {};
            Evidence myEvidence = new Evidence(hostEvidence,assemblyEvidence);
            GacIdentityPermission myPerm = 
                (GacIdentityPermission)myGacInstalled.CreateIdentityPermission(
                myEvidence);
            Console.WriteLine(myPerm.ToXml().ToString());

            GacInstalled myGacInstalledCopy = 
                (GacInstalled)myGacInstalled.Copy();
            bool result = myGacInstalled.Equals(myGacInstalledCopy);

            Console.WriteLine(
                "Hashcode = " + myGacInstalled.GetHashCode().ToString());

            Console.WriteLine(myGacInstalled.ToString());
        }
    }
}