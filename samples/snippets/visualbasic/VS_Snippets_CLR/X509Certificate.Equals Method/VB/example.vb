 ' <Snippet1>
Imports System
Imports System.Security.Cryptography.X509Certificates




Public Class X509
   
   
   Public Shared Sub Main()
      
      ' The path to the certificate.
      Dim Certificate As String = "Certificate.cer"
      Dim OtherCertificate As String = "OtherCertificate.cer"
      
      ' Load the certificate into an X509Certificate object.
      Dim cert As X509Certificate = X509Certificate.CreateFromCertFile(Certificate)
      
      ' Load the certificate into an X509Certificate object.
      Dim certTwo As X509Certificate = X509Certificate.CreateFromCertFile(OtherCertificate)
      
      ' Get the value.
      Dim result As Boolean = cert.Equals(certTwo)
      
      ' Display the value to the console.
      Console.WriteLine(result)
   End Sub  
End Class 

' </Snippet1>