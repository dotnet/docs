 '
'   This program demonstrates the 'FromXml' method of 'DnsPermission' class.
'   It creates an instance of 'DnsPermission' class and prints the XML encoding of that instance.Then it 
'   creates a 'SecurityElement' object and adds the attributes corresponding to the above 'DnsPermission'
'   object. A new 'DnsPermission' instance is reconstructed from the 'SecurityElement' instance by calling 
'   'FromXml' method and it's XML encoding is printed.
'

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic


Class DnsPermissionExample
    
    
    Public Shared Sub Main()
        Dim dnsPermissionExampleObj As New DnsPermissionExample()
        dnsPermissionExampleObj.ConstructDnsPermission()
    End Sub 'Main
    
' <Snippet1>	
    Public Sub ConstructDnsPermission()
        Try
            ' Create a DnsPermission instance.
            Dim permission As New DnsPermission(PermissionState.None)
            ' Create a SecurityElement instance by calling the ToXml method on the
            ' DnsPermission instance and print its attributes, 
            ' which hold the  XML encoding of the DnsPermission instance.
            Console.WriteLine("Attributes and Values of 'DnsPermission' instance :")
            PrintKeysAndValues(permission.ToXml().Attributes)
            
            ' Create a SecurityElement instacnce .
            Dim securityElementObj As New SecurityElement("IPermission")
            ' Add attributes and values of the SecurityElement instance corresponding to
            ' teh permission instance.
            securityElementObj.AddAttribute("version", "1")
            securityElementObj.AddAttribute("Unrestricted", "true")
            securityElementObj.AddAttribute("class", "System.Net.DnsPermission")
            
            ' Reconstruct a DnsPermission instance from an XML encoding.
            Dim permission1 As New DnsPermission(PermissionState.None)
            permission1.FromXml(securityElementObj)
            
            ' Print the attributes and values of the constructed DnsPermission object.
            Console.WriteLine("After reconstruction Attributes and Values of new DnsPermission instance :")
            PrintKeysAndValues(permission1.ToXml().Attributes)
        Catch e As NullReferenceException
            Console.WriteLine("NullReferenceException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As SecurityException
            Console.WriteLine("SecurityException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'ConstructDnsPermission
    
    
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
