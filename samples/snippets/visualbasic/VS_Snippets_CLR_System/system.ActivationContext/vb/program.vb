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

    <SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy:=True)> _
    Public Shared Sub Main(ByVal args() As String) 
        '<Snippet3>
        '<Snippet2>
        Dim ac As ActivationContext = AppDomain.CurrentDomain.ActivationContext
        Dim ai As ApplicationIdentity = ac.Identity
        '</Snippet2>
        Console.WriteLine("Full name = " + ai.FullName)
        Console.WriteLine("Code base = " + ai.CodeBase)
        '</Snippet3>
        Console.Read()
    
    End Sub 'Main

    <SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy:=True)> _
    Public Sub Run() 
        Main(New String() {})
        Console.ReadLine()
    
    End Sub 'Run
End Class 'Program
'</Snippet1>