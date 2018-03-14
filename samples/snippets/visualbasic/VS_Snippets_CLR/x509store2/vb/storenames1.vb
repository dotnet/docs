' Snippet1 is in x509store2.vb
'
'<Snippet2>
Option Strict On

Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Module Example

    Sub Main()

        Console.WriteLine(vbCrLf & "Exists Certs Name and Location")
        Console.WriteLine("------ ----- -------------------------")

        For Each storeLocation As StoreLocation In _
                CType([Enum].GetValues(GetType(StoreLocation)), StoreLocation())

            For Each storeName As StoreName In _
                    CType([Enum].GetValues(GetType(StoreName)), StoreName())

                Dim store As New X509Store(StoreName, StoreLocation)

                Try
                    store.Open(OpenFlags.OpenExistingOnly)
                    Console.WriteLine("Yes    {0,4}  {1}, {2}", _
                        store.Certificates.Count, store.Name, store.Location)
                Catch e As CryptographicException
                    Console.WriteLine("No           {0}, {1}", _
                        store.Name, store.Location)
                End Try
            Next

            Console.WriteLine()
        Next
    End Sub
End Module

' This example produces output similar to the following:

'Exists Certs Name and Location
'------ ----- -------------------------
'Yes       1  AddressBook, CurrentUser
'Yes      25  AuthRoot, CurrentUser
'Yes     136  CA, CurrentUser
'Yes      55  Disallowed, CurrentUser
'Yes      20  My, CurrentUser
'Yes      36  Root, CurrentUser
'Yes       0  TrustedPeople, CurrentUser
'Yes       1  TrustedPublisher, CurrentUser

'No           AddressBook, LocalMachine
'Yes      25  AuthRoot, LocalMachine
'Yes     131  CA, LocalMachine
'Yes      55  Disallowed, LocalMachine
'Yes       3  My, LocalMachine
'Yes      36  Root, LocalMachine
'Yes       0  TrustedPeople, LocalMachine
'Yes       1  TrustedPublisher, LocalMachine

'</Snippet2>
