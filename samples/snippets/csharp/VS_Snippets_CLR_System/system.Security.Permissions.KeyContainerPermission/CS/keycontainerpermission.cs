//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Cryptography;

namespace KeyContainerPermissionDemo
{
    public class KeyContainerPermissionDemo
    {
        private static CspParameters cspParams = new CspParameters();
        private static RSACryptoServiceProvider rsa = 
            new RSACryptoServiceProvider();
        private static string providerName;
        private static int providerType;
        private static string myKeyContainerName;
        
        // Create three KeyContainerPermissionAccessEntry objects, 
        // each with a different constructor.
        //<Snippet2>
        private static KeyContainerPermissionAccessEntry 
            keyContainerPermAccEntry1 = new KeyContainerPermissionAccessEntry(
            "MyKeyContainer", KeyContainerPermissionFlags.Create);
        //</Snippet2>
        //<Snippet3>
        private static KeyContainerPermissionAccessEntry 
            keyContainerPermAccEntry2 = new KeyContainerPermissionAccessEntry(
            cspParams, KeyContainerPermissionFlags.Open);
        //</Snippet3>
        //<Snippet4>
        private static KeyContainerPermissionAccessEntry 
            keyContainerPermAccEntry3 = new KeyContainerPermissionAccessEntry(
            "Machine", providerName, providerType, myKeyContainerName, 1, 
            KeyContainerPermissionFlags.Open);
        //</Snippet4>

        public static int Main()
        {
            try
            {
                // Create a key container for use in the sample.
                GenKey_SaveInContainer("MyKeyContainer");
                
                // Initialize property values for creating a 
                // KeyContainerPermissionAccessEntry object.
                myKeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName;
                providerName = rsa.CspKeyContainerInfo.ProviderName;
                providerType = rsa.CspKeyContainerInfo.ProviderType;
                cspParams.KeyContainerName = myKeyContainerName;
                cspParams.ProviderName = providerName;
                cspParams.ProviderType = providerType;

                // Display the KeyContainerPermissionAccessEntry properties  
                // using the third KeyContainerPermissionAccessEntry object.
                DisplayAccessEntryMembers();
                
                //<Snippet22>
                // Add access entry objects to a key container permission.
                KeyContainerPermission keyContainerPerm1 = 
                    new KeyContainerPermission(PermissionState.Unrestricted);
                Console.WriteLine("Is the permission unrestricted? " + 
                    keyContainerPerm1.IsUnrestricted());
                keyContainerPerm1.AccessEntries.Add(keyContainerPermAccEntry1);
                keyContainerPerm1.AccessEntries.Add(keyContainerPermAccEntry2);
                //</Snippet22>

                // Display the permission.
                System.Console.WriteLine(keyContainerPerm1.ToXml().ToString());

                //<Snippet13>
                // Create an array of KeyContainerPermissionAccessEntry objects
                KeyContainerPermissionAccessEntry[] keyContainerPermAccEntryArray 
                    = { keyContainerPermAccEntry1, keyContainerPermAccEntry2 };

                // Create a new KeyContainerPermission using the array.
                KeyContainerPermission keyContainerPerm2 = 
                    new KeyContainerPermission(
                    KeyContainerPermissionFlags.AllFlags,
                    keyContainerPermAccEntryArray);
                //</Snippet13>

                DisplayPermissionMembers(
                    keyContainerPerm2, keyContainerPermAccEntryArray);

                // Demonstrate the effect of a deny for opening a key container.
                DenyOpen();

                // Demonstrate the deletion of a key container.           
                DeleteContainer();

                Console.WriteLine("Press the Enter key to exit.");
                Console.Read();
                return 0;
            // Close the current try block that did not expect an exception.
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception thrown:  " + e.Message);
                return 0;
            }
        }

        private static void DisplayAccessEntryMembers()
        {
            //<Snippet5>
            Console.WriteLine("\nKeycontainerName is " + 
                keyContainerPermAccEntry3.KeyContainerName);
            //</Snippet5>
            //<Snippet6>
            Console.WriteLine("KeySpec is " + (1 == 
                keyContainerPermAccEntry3.KeySpec ? "AT_KEYEXCHANGE " : 
                "AT_SIGNATURE"));
            //</Snippet6>
            //<Snippet7>
            Console.WriteLine("KeyStore is " + 
                keyContainerPermAccEntry3.KeyStore);
            //</Snippet7>
            //<Snippet8>
            Console.WriteLine("ProviderName is " + 
                keyContainerPermAccEntry3.ProviderName);
            //</Snippet8>
            //<Snippet9>
            Console.WriteLine("ProviderType is " + (1 == 
                keyContainerPermAccEntry3.ProviderType ? "PROV_RSA_FULL" :
                keyContainerPermAccEntry3.ProviderType.ToString()));
            //</Snippet9>
            //<Snippet10>
            Console.WriteLine("Hashcode = " + 
                keyContainerPermAccEntry3.GetHashCode());
            //</Snippet10>
            //<Snippet11>
            Console.WriteLine(
                "Are the KeyContainerPermissionAccessEntry objects equal? " + 
                keyContainerPermAccEntry3.Equals(keyContainerPermAccEntry2));
            //</Snippet11>
        }

        private static void DisplayPermissionMembers(
            KeyContainerPermission keyContainerPermParam,
            KeyContainerPermissionAccessEntry[] 
            keyContainerPermAccEntryArrayParam)
        {
            KeyContainerPermission keyContainerPerm2 = keyContainerPermParam;
            KeyContainerPermissionAccessEntry[] keyContainerPermAccEntryArray = 
                keyContainerPermAccEntryArrayParam;

            // Display the KeyContainerPermission properties.
            //<Snippet12>
            Console.WriteLine("\nFlags value is " + 
                keyContainerPerm2.Flags.ToString());
            //</Snippet12>
            //<Snippet14>
            KeyContainerPermission keyContainerPerm3 = 
                (KeyContainerPermission)keyContainerPerm2.Copy();
            Console.WriteLine("Is the copy equal to the original? " + 
                keyContainerPerm3.Equals(keyContainerPerm2));
            //</Snippet14>

            //<Snippet15>
            // Perform an XML roundtrip.
            keyContainerPerm3.FromXml(keyContainerPerm2.ToXml());
            Console.WriteLine("Was the XML roundtrip successful? " + 
                keyContainerPerm3.Equals(keyContainerPerm2));
            //</Snippet15>
            KeyContainerPermission keyContainerPerm4 = 
                new KeyContainerPermission(KeyContainerPermissionFlags.Open,
                keyContainerPermAccEntryArray);
            //<Snippet16>
            KeyContainerPermission keyContainerPerm5 = 
                (KeyContainerPermission)keyContainerPerm2.Intersect(
                keyContainerPerm4);
            Console.WriteLine("Flags value after the intersection is " + 
                keyContainerPerm5.Flags.ToString());
            //</Snippet16>
            //<Snippet17>
            keyContainerPerm5 = (KeyContainerPermission)keyContainerPerm2.Union(
                keyContainerPerm4);
            //</Snippet17>
            //<Snippet18>
            Console.WriteLine("Flags value after the union is " + 
                keyContainerPerm5.Flags.ToString());
            //</Snippet18>
            //<Snippet19>
            Console.WriteLine("Is one permission a subset of the other? " + 
                keyContainerPerm4.IsSubsetOf(keyContainerPerm2));
            //</Snippet19>
        }

        private static void GenKey_SaveInContainer(string containerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            cspParams = new CspParameters();

            cspParams.KeyContainerName = containerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container identified by the containerName parameter.
            rsa = new RSACryptoServiceProvider(cspParams);

            // Display the key information to the console.
            Console.WriteLine("\nKey added to container: \n  {0}", 
                rsa.ToXmlString(true));
        }
        private static void GetKeyFromContainer(string containerName)
        {
            try
            {
                cspParams = new CspParameters();
                cspParams.KeyContainerName = containerName;

                // Create a new instance of RSACryptoServiceProvider that accesses
                // the key container identified by the containerName parameter.
                // If the key container does not exist, a new one is created.
                rsa = new RSACryptoServiceProvider(cspParams);

                // Use the rsa object to access the key. 
                // Display the key information to the console.
                Console.WriteLine("\nKey retrieved from container : \n {0}", 
                    rsa.ToXmlString(true));
                Console.WriteLine("KeycontainerName is " + 
                    rsa.CspKeyContainerInfo.KeyContainerName);
                Console.WriteLine("ProviderName is " + 
                    rsa.CspKeyContainerInfo.ProviderName);
                Console.WriteLine("ProviderType is " + (1 == 
                    rsa.CspKeyContainerInfo.ProviderType ? "PROV_RSA_FULL" : 
                    rsa.CspKeyContainerInfo.ProviderType.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown:  " + e.Message);
            }

        }
        private static void DeleteKeyContainer(string containerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.

            cspParams = new CspParameters();
            cspParams.KeyContainerName = containerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container.
            rsa = new RSACryptoServiceProvider(cspParams);

            // Do not persist the key entry, effectively deleting the key.
            rsa.PersistKeyInCsp = false;

            // Call Clear to release the key container resources.
            rsa.Clear();
            Console.WriteLine("\nKey container released.");
        }
        private static void DenyOpen()
        {
            try
            {
                //<Snippet20>
                // Create a KeyContainerPermission with the right 
                // to open the key container.
                KeyContainerPermission keyContainerPerm = new
                     KeyContainerPermission(KeyContainerPermissionFlags.Open);
                //</Snippet20>

                // Demonstrate the results of a deny for an open action.
                keyContainerPerm.Deny();

                // The next line causes an exception to be thrown when the
                // infrastructure code attempts to open the key container.
                CspKeyContainerInfo info = new CspKeyContainerInfo(cspParams);
            }
            catch (Exception e)
            {
                Console.WriteLine("Expected exception thrown: " + e.Message);
            }

            // Revert the deny.
            CodeAccessPermission.RevertDeny();
        }
        private static void DeleteContainer()
        {
            try
            {
                // Create a KeyContainerPermission with the right to 
                // create a key container.
                KeyContainerPermission keyContainerPerm = new 
                    KeyContainerPermission(KeyContainerPermissionFlags.Create);

                // Deny the ability to create a key container.
                // This deny is used to show the key container has been 
                // successfully deleted.
                keyContainerPerm.Deny();

                // Retrieve the key from the container.
                // This code executes successfully because the key 
                // container already exists.
                // The deny for permission to create a key container 
                // does not affect this method call.
                GetKeyFromContainer("MyKeyContainer");

                // Delete the key and the container.
                DeleteKeyContainer("MyKeyContainer");

                // Attempt to obtain the key from the deleted key container.
                // This time the method call results in an exception because of
                // an attempt to create a new key container.
                Console.WriteLine("\nAttempt to create a new key container " +
                    "with create permission denied.");
                GetKeyFromContainer("MyKeyContainer");
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Expected exception thrown: " + e.Message);
            }
        }
    }
}
//</Snippet1>

