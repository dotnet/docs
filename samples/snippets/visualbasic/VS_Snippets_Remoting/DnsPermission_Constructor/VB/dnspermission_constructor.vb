 '
'   This program demonstrates the 'Constructor' of 'DnsPermission' class.
'   It creates an instance of 'DnsPermission' class and checks for permission.Then it 
'   creates a 'SecurityElement' object and  prints it's attributes which hold the  XML
'   encoding of 'DnsPermission' instance .
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
        ' Create a SecurityElement object to hold XML encoding of the DnsPermission instance.
        Dim securityElementObj As SecurityElement = permission.ToXml()
        Console.WriteLine("Tag, Attributes and Values of 'DnsPermission' instance :")
        Console.WriteLine((ControlChars.Cr + ControlChars.Tab + "Tag :" + securityElementObj.Tag))
        ' Print the attributes and values.
        PrintKeysAndValues(securityElementObj.Attributes)
    End Sub 'useDns
    
    Private Sub PrintKeysAndValues(myList As Hashtable)
        ' Get the enumerator that can iterate through the hash table.
        Dim myEnumerator As IDictionaryEnumerator = myList.GetEnumerator()
        Console.WriteLine(ControlChars.Cr + ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues
' </Snippet1>    
End Class 'DnsPermissionExample