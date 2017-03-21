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
        Console.WriteLine("Full name = " + _
            AppDomain.CurrentDomain.ActivationContext.Identity.FullName)
        Console.WriteLine("Code base = " + _
            AppDomain.CurrentDomain.ActivationContext.Identity.CodeBase)
        Dim asi As New ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext)     
        Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name)
        If Not (asi.ApplicationId.Culture Is Nothing) Then
            Console.WriteLine("ApplicationId.Culture property = " + _
            asi.ApplicationId.Culture.ToString())
        End If
        Console.WriteLine("ApplicationId.ProcessorArchitecture property = " + _
            asi.ApplicationId.ProcessorArchitecture)
        Console.WriteLine("ApplicationId.Version property = " + _
            asi.ApplicationId.Version.ToString())
        ' To display the value of the public key, enumerate the Byte array for the property.
        Console.Write("ApplicationId.PublicKeyToken property = ")
        Dim pk As Byte() = asi.ApplicationId.PublicKeyToken
        Dim i As Integer
        For i = 0 To (pk.GetLength(0))
            Console.Write("{0:x}", pk(i))
        Next i 
        Console.Read()
    
    End Sub 'Main
    
    Public Sub Run() 
        Main(New String() {})  
    End Sub 'Run
End Class 'Program