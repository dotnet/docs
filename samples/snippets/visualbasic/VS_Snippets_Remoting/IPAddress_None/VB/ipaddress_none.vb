 '
'   This program demonstrates the 'None' field of 'IPAddress' class.
'   Provides an IP address indicating that no network interface should be used.
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Class NoneFieldAddress

' <Snippet1>	    
    Public Shared Sub Main()

        ' Gets the IP address indicating that no network interface should be used
        ' and converts it to a string. 
        Dim address As String = IPAddress.None.ToString()
        Console.WriteLine(("IP address : " + address))
    End Sub 'Main 
' </Snippet1>	

End Class 'NoneFieldAddress