
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Class MyMainClass
    
    Public Shared Sub Main() 
        '<SNIPPET1>
        ' Create a new CspParameters object.
        Dim cspParams As New CspParameters()
        
        ' Specify an exchange key.
        cspParams.KeyNumber = Fix(KeyNumber.Exchange)
        
        ' Initialize the RSACryptoServiceProvider  
        ' with the CspParameters object.
        Dim RSACSP As New RSACryptoServiceProvider(cspParams)
	'</SNIPPET1>
    
    End Sub 'Main 
End Class 'MyMainClass