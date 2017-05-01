// NclNetworkInfoPerms
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Examples.NetworkInformation.Permissions
{

    public class PermissionTest
    {

        public static void CreatePermission()
        {
            //<Snippet6>
            //<Snippet5>
            //<Snippet2>
            //<Snippet1>
            System.Net.NetworkInformation.NetworkInformationPermission unrestricted = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Security.Permissions.PermissionState.Unrestricted);
            //</Snippet1>

            Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted());
            //</Snippet2>

            //<Snippet4>
            //<Snippet3>
            System.Net.NetworkInformation.NetworkInformationPermission read = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Net.NetworkInformation.NetworkInformationAccess.Read);
            //</Snippet3>
            System.Net.NetworkInformation.NetworkInformationPermission copyPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Copy();
            //</Snippet4>
            System.Net.NetworkInformation.NetworkInformationPermission unionPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Union(unrestricted);
            Console.WriteLine("Is subset?" + read.IsSubsetOf(unionPermission));
            //</Snippet5>
            System.Net.NetworkInformation.NetworkInformationPermission intersectPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Intersect(unrestricted);
            //</Snippet6>

            //<Snippet7>
            System.Net.NetworkInformation.NetworkInformationPermission permission = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Security.Permissions.PermissionState.None);
            permission.AddPermission(
                    System.Net.NetworkInformation.NetworkInformationAccess.Read);
            Console.WriteLine("Access is {0}", permission.Access);
            //</Snippet7>
        }

        public static void Main()
        {
            CreatePermission();
        }
    }


}
