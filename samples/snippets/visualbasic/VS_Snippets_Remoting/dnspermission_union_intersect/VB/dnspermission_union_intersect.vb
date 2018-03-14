 '
'   This program demonstrates the 'Intersect' and 'Union' methods of 'DnsPermission' class.
'   It creates a 'DnsPermission' instance that is the Union/Intersection of current permission 
'   instance and specified permission instance.
'

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic


Class DnsPermissionExample
    
    ' private variables
    Private dnsPermission1 As DnsPermission
    Private dnsPermission2 As DnsPermission
    
    
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
    Private Sub MyUnion()
        ' Create a DnsPermission instance which is the union of the current DnsPermission instance and the specified DnsPermission instance.
        Dim permission As DnsPermission = CType(dnsPermission1.Union(dnsPermission2), DnsPermission)
        ' Print the attributes and values of the union instance of DnsPermission.
        PrintKeysAndValues(permission.ToXml().Attributes)
    End Sub 'MyUnion
' <Snippet2>    
    Public Sub useDns()
        ' Create a DnsPermission instance.
        dnsPermission1 = New DnsPermission(PermissionState.Unrestricted)
        dnsPermission2 = New DnsPermission(PermissionState.None)
        ' Check for permission.
        dnsPermission1.Demand()
        dnsPermission2.Demand()
        Console.WriteLine("Attributes and Values of first DnsPermission instance :")
        PrintKeysAndValues(dnsPermission1.ToXml().Attributes)
        Console.WriteLine("Attributes and Values of second DnsPermission instance :")
        PrintKeysAndValues(dnsPermission2.ToXml().Attributes)
        Console.WriteLine("Union of both instances : ")
        MyUnion()
        Console.WriteLine("Intersection of both instances : ")
        MyIntersection()
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

    Private Sub MyIntersection()
        ' Create a DnsPermission instance that is the intersection of the current
        ' DnsPermission instance and the specified DnsPermission instance.
        Dim permission As DnsPermission = CType(dnsPermission1.Intersect(dnsPermission2), DnsPermission)
        ' Print the attributes and values of the intersection instance of DnsPermission.
        PrintKeysAndValues(permission.ToXml().Attributes)
    End Sub 'MyIntersection
' </Snippet2>
End Class 'DnsPermissionExample 
