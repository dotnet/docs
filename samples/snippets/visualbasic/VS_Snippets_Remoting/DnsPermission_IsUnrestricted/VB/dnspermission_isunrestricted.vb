 '
'   This program demonstrates the 'IsUnrestricted' method of 'DnsPermission' class.
'   It checks the overall permission state of the object and it will return true if the
'   'DnsPermission' instance was created with unrestricted permission state otherwise false.
'

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic


Class DnsPermissionExample
    
    
    Public Shared Sub Main()
        Try
            Dim dnsPermissionExampleObj As New DnsPermissionExample()
            dnsPermissionExampleObj.useDns()
        Catch e As SecurityException
            Console.WriteLine("SecurityException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'Main
    
' <Snippet1>	
    Public Sub useDns()
        ' Create a DnsPermission instance.
        Dim permission As New DnsPermission(PermissionState.Unrestricted)
        ' Check for permission.
        permission.Demand()
        Console.WriteLine("Attributes and Values of DnsPermission instance :")
        ' Print the attributes and values.
        PrintKeysAndValues(permission.ToXml().Attributes)
        ' Check the permission state.
        If permission.IsUnrestricted() Then
            Console.WriteLine("Overall permissions : Unrestricted")
        Else
            Console.WriteLine("Overall permissions : Restricted")
        End If
    End Sub 'useDns
     
    Private Sub PrintKeysAndValues(myList As Hashtable)
        ' Get the enumerator that can iterate through the hash table.
        Dim myEnumerator As IDictionaryEnumerator = myList.GetEnumerator()
        Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues
' </Snippet1>	
End Class 'DnsPermissionExample 
