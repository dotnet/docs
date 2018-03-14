' Snippet for U_SEIssuedTokenServiceCredential
' Type T:System.IdentityModel.Tokens.SamlSerializer
' Snippet used 0-1 cs 10
'
' problem to fix, cannot assign different type
'            ServiceCredentials creds = new ServiceCredentials();
'            creds.IssuedTokenAuthentication.TrustedStoreLocation =  
'                new X509Certificate2 ("mycert.cer");
' * how is TrustedStoreLocation used?
'
'<Snippet0>

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates

Namespace CS
	Friend Class MySamSerializer
		Inherits SamlSerializer
	End Class

    Module Module1
        Sub Main(ByVal args() As String)
            ' <Snippet1>
            Dim creds As New ServiceCredentials()
            creds.IssuedTokenAuthentication.SamlSerializer = New MySamSerializer()
            ' </Snippet1>

        End Sub

        Private Sub Main2()
            ' Problem, cannot covert X509Certificate2 to StoreLocation
            ' <Snippet2>

            Dim creds As New ServiceCredentials()
            '            creds.IssuedTokenAuthentication.TrustedStoreLocation =
            '                (StoreLocation) new X509Certificate2("mycert.cer");
            ' </Snippet2>   

        End Sub
    End Module
End Namespace
'</Snippet0>