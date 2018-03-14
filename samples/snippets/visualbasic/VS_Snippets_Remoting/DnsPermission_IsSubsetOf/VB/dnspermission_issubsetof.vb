 '
'   This program demonstrates the  'IsSubsetOf' method of 'DnsPermission' class.
'   'IsSubsetOf' method returns true, if the current DnsPermission instance allows no
'   more access to DNS servers than does the specified 'DnsPermission' instance.
'

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic


Class DnsPermissionExample
    
    ' private variables
    Private permission As DnsPermission
    
    
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
        permission = New DnsPermission(PermissionState.Unrestricted)
        Dim dnsPermission1 As New DnsPermission(PermissionState.None)
        ' Check  for permission.
        permission.Demand()
        dnsPermission1.Demand()
        ' Print the attributes and values.
        Console.WriteLine("Attributes and Values of 'DnsPermission' instance :")
        PrintKeysAndValues(permission.ToXml().Attributes)
        Console.WriteLine("Attributes and Values of specified 'DnsPermission' instance :")
        PrintKeysAndValues(dnsPermission1.ToXml().Attributes)
        Subset(dnsPermission1)
    End Sub 'useDns
    
    
    Private Sub Subset(Permission1 As DnsPermission)
        If permission.IsSubsetOf(Permission1) Then
            Console.WriteLine("Current 'DnsPermission' instance is a subset of specified 'DnsPermission' instance.")
        Else
            Console.WriteLine("Current 'DnsPermission' instance is not a subset of specified 'DnsPermission' instance.")
        End If
    End Sub 'Subset
     
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

