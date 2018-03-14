'<Snippet1>
Imports System
Imports System.Collections
Imports System.Text
Imports System.Security.Policy
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions



Public Class Program
    Inherits MarshalByRefObject
    <SecurityPermission(SecurityAction.Demand, ControlDomainPolicy:=true)> _
    Public Shared Sub Main(ByVal args() As String) 
        '<Snippet2>
        Console.WriteLine("Full name = " + _
            AppDomain.CurrentDomain.ActivationContext.Identity.FullName)
        '</Snippet2>
        '<Snippet3>
        Console.WriteLine("Code base = " + _
            AppDomain.CurrentDomain.ActivationContext.Identity.CodeBase)
        '</Snippet3>
        '<Snippet6>
        '<Snippet7>
        Dim asi As New ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext)     
        Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name)
        '</Snippet7>
        '<Snippet8>
        If Not (asi.ApplicationId.Culture Is Nothing) Then
            Console.WriteLine("ApplicationId.Culture property = " + _
            asi.ApplicationId.Culture.ToString())
        End If
        '</Snippet8>
        '<Snippet9>
        Console.WriteLine("ApplicationId.ProcessorArchitecture property = " + _
            asi.ApplicationId.ProcessorArchitecture)
        '</Snippet9>
        '<Snippet10>
        Console.WriteLine("ApplicationId.Version property = " + _
            asi.ApplicationId.Version.ToString())
        '</Snippet10>
        '<Snippet11>
        ' To display the value of the public key, enumerate the Byte array for the property.
        Console.Write("ApplicationId.PublicKeyToken property = ")
        Dim pk As Byte() = asi.ApplicationId.PublicKeyToken
        Dim i As Integer
        For i = 0 To (pk.GetLength(0))
            Console.Write("{0:x}", pk(i))
        Next i 
        '</Snippet11>
        '</Snippet6>
        Console.Read()
    
    End Sub 'Main
    
    Public Sub Run() 
        Main(New String() {})  
    End Sub 'Run
End Class 'Program
'</Snippet1>