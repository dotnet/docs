 '
'   This program demonstrates the 'Copy' method of 'DnsPermission' class.
'   It creates an identical copy of 'DnsPermission' instance.
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
            dnsPermissionExampleObj.UseDns()
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
    Public Sub UseDns()
        ' Create a DnsPermission instance.
        Dim myPermission As New DnsPermission(PermissionState.Unrestricted)
        ' Check for permission.
        myPermission.Demand()
        ' Create an identical copy of the above DnsPermission object.
        Dim myPermissionCopy As DnsPermission = CType(myPermission.Copy(), DnsPermission)
        Console.WriteLine("Attributes and Values of 'DnsPermission' instance :")
        ' Print the attributes and values.
        PrintKeysAndValues(myPermission.ToXml().Attributes)
        Console.WriteLine("Attribute and values of copied instance :")
        PrintKeysAndValues(myPermissionCopy.ToXml().Attributes)
    End Sub 'UseDns
    
    
    Private Sub PrintKeysAndValues(myHashtable As Hashtable)
        ' Get the enumerator that can iterate through he hash table.
        Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
        Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues

' </Snippet1>	

End Class 'DnsPermissionExample

