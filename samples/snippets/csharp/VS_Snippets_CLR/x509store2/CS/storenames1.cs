// Snippet1 is in x509store2.cs.
//
//<Snippet2>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Example
{
    static void Main()
    {
        Console.WriteLine("\r\nExists Certs Name and Location");
        Console.WriteLine("------ ----- -------------------------");

        foreach (StoreLocation storeLocation in (StoreLocation[]) 
            Enum.GetValues(typeof(StoreLocation)))
        {
            foreach (StoreName storeName in (StoreName[]) 
                Enum.GetValues(typeof(StoreName)))
            {
                X509Store store = new X509Store(storeName, storeLocation);

                try
                {
                    store.Open(OpenFlags.OpenExistingOnly);

                    Console.WriteLine("Yes    {0,4}  {1}, {2}", 
                        store.Certificates.Count, store.Name, store.Location);
                }   
                catch (CryptographicException)
                {
                    Console.WriteLine("No           {0}, {1}", 
                        store.Name, store.Location);
                }
            }
            Console.WriteLine();
        }
    }
}

/* This example produces output similar to the following:

Exists Certs Name and Location
------ ----- -------------------------
Yes       1  AddressBook, CurrentUser
Yes      25  AuthRoot, CurrentUser
Yes     136  CA, CurrentUser
Yes      55  Disallowed, CurrentUser
Yes      20  My, CurrentUser
Yes      36  Root, CurrentUser
Yes       0  TrustedPeople, CurrentUser
Yes       1  TrustedPublisher, CurrentUser

No           AddressBook, LocalMachine
Yes      25  AuthRoot, LocalMachine
Yes     131  CA, LocalMachine
Yes      55  Disallowed, LocalMachine
Yes       3  My, LocalMachine
Yes      36  Root, LocalMachine
Yes       0  TrustedPeople, LocalMachine
Yes       1  TrustedPublisher, LocalMachine

 */
//</Snippet2>
