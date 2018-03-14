 ' <Snippet1>
Imports System
Imports System.Security.Cryptography.X509Certificates




Public Class X509
   
   
   Public Shared Sub Main()
      
      ' The path to the certificate.
      Dim Certificate As String = "Certificate.cer"
      
      ' Load the certificate into an X509Certificate object.
      Dim cert As X509Certificate = X509Certificate.CreateFromCertFile(Certificate)
      
      ' Get the value.
      Dim resultsTrue As String = cert.ToString(True)
      
      ' Display the value to the console.
      Console.WriteLine(resultsTrue)
      
      ' Get the value.
      Dim resultsFalse As String = cert.ToString(False)
      
      ' Display the value to the console.
      Console.WriteLine(resultsFalse)
   End Sub  
End Class 

' </Snippet1>