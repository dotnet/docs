// <SNIPPET2>
using System;
using System.Security.Cryptography;

public class RSAKeyStoreSample
{
    public static void Main()
    {
        // Set the static UseMachineKeyStore property to use the machine key
        // store instead of the user profile key store. All CSP instances not
        // initialized with CspParameters will use this setting.
        RSACryptoServiceProvider.UseMachineKeyStore = true;
        try
        {
            // This CSP instance will use the Machine Store as set above and is
            // initialized with no parameters.
            using (RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider())
            {
                ShowContainerInfo(RSAalg.CspKeyContainerInfo);
                RSAalg.PersistKeyInCsp = false;
            }

            CspParameters cspParams = new CspParameters();

            cspParams.KeyContainerName = "MyKeyContainer";

            // This CSP instance will use the User Store since cspParams are used.
            using (RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider(cspParams))
            {
                ShowContainerInfo(RSAalg.CspKeyContainerInfo);
                RSAalg.PersistKeyInCsp = false;
            }

            cspParams.Flags |= CspProviderFlags.UseMachineKeyStore;

            // This CSP instance will use the Machine Store. Although cspParams are used,
            // the cspParams.Flags is set to CspProviderFlags.UseMachineKeyStore.
            using (RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider(cspParams))
            {
                ShowContainerInfo(RSAalg.CspKeyContainerInfo);
                RSAalg.PersistKeyInCsp = false;
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Exception: {0}", e.GetType().FullName);
            Console.WriteLine(e.Message);

        }
    }

    public static void ShowContainerInfo(CspKeyContainerInfo containerInfo)
    {
        string keyStore;

        Console.WriteLine();
        if (containerInfo.MachineKeyStore)
        {
            keyStore = "Machine Store";
        }
        else
        {
            keyStore = "User Store";
        }
        Console.WriteLine("Key Store:     {0}", keyStore);
        Console.WriteLine("Key Provider:  {0}", containerInfo.ProviderName);
        Console.WriteLine("Key Container: \"{0}\"", containerInfo.KeyContainerName);
        Console.WriteLine("Generated:     {0}", containerInfo.RandomlyGenerated);
        Console.WriteLine("Key Nubmer:    {0}", containerInfo.KeyNumber);
        Console.WriteLine("Removable Key: {0}", containerInfo.Removable);
    }
}
// </SNIPPET2>