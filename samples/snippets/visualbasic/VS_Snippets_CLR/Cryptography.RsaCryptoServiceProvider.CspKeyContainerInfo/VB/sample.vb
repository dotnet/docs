'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Module CspKeyContainerInfoExample

    Sub Main(ByVal args() As String)
        Dim rsa As New RSACryptoServiceProvider()

        Try
            ' Note: In cases where a random key is generated,   
            ' a key container is not created until you call  
            ' a method that uses the key.  This example calls
            ' the Encrypt method before calling the
            ' CspKeyContainerInfo property so that a key
            ' container is created.  
            ' Create some data to encrypt and display it.
            Dim data As String = "Here is some data to encrypt."

            Console.WriteLine("Data to encrypt: " + data)

            ' Convert the data to an array of bytes and 
            ' encrypt it.
            Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)

            Dim encData As Byte() = rsa.Encrypt(byteData, False)

            ' Display the encrypted value.
            Console.WriteLine("Encrypted Data: " + Encoding.ASCII.GetString(encData))

            Console.WriteLine()

            Console.WriteLine("CspKeyContainerInfo information:")

            Console.WriteLine()

            ' Create a new CspKeyContainerInfo object.
            Dim keyInfo As CspKeyContainerInfo = rsa.CspKeyContainerInfo

            ' Display the value of each property.
            Console.WriteLine("Accessible property: " + keyInfo.Accessible.ToString())

            Console.WriteLine("Exportable property: " + keyInfo.Exportable.ToString())

            Console.WriteLine("HardwareDevice property: " + keyInfo.HardwareDevice.ToString())

            Console.WriteLine("KeyContainerName property: " + keyInfo.KeyContainerName)

            Console.WriteLine("KeyNumber property: " + keyInfo.KeyNumber.ToString())

            Console.WriteLine("MachineKeyStore property: " + keyInfo.MachineKeyStore.ToString())

            Console.WriteLine("Protected property: " + keyInfo.Protected.ToString())

            Console.WriteLine("ProviderName property: " + keyInfo.ProviderName)

            Console.WriteLine("ProviderType property: " + keyInfo.ProviderType.ToString())

            Console.WriteLine("RandomlyGenerated property: " + keyInfo.RandomlyGenerated.ToString())

            Console.WriteLine("Removable property: " + keyInfo.Removable.ToString())

            Console.WriteLine("UniqueKeyContainerName property: " + keyInfo.UniqueKeyContainerName)


        Catch e As Exception
            Console.WriteLine(e.ToString())
        Finally
            ' Clear the key.
            rsa.Clear()
        End Try
        Console.ReadLine()

    End Sub
End Module
'</SNIPPET1>