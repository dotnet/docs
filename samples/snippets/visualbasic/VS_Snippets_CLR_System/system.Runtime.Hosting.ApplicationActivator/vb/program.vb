'<Snippet1>
Imports System
Imports System.Collections
Imports System.Text
Imports System.Security.Policy
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Runtime.Hosting



Public Class Program
    Inherits MarshalByRefObject

    <SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy:=True)> _
    Public Shared Sub Main(ByVal args() As String)
        '<Snippet2>
        ' Get the AppDomainManager from the current domain.
        Dim domainMgr As AppDomainManager = AppDomain.CurrentDomain.DomainManager
        ' Get the ApplicationActivator from the AppDomainManager.
        Dim appActivator As ApplicationActivator = domainMgr.ApplicationActivator
        Console.WriteLine("Assembly qualified name from the application activator.")
        Console.WriteLine(appActivator.GetType().AssemblyQualifiedName)
        '</Snippet2>
        '<Snippet3>
        '<Snippet4>
        Dim ac As ActivationContext = AppDomain.CurrentDomain.ActivationContext
        ' Get the ActivationArguments from the SetupInformation property of the domain.
        Dim activationArgs As ActivationArguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments
        '</Snippet3>
        ' Get the ActivationContext from the ActivationArguments.
        Dim actContext As ActivationContext = activationArgs.ActivationContext
        Console.WriteLine("The ActivationContext.Form property value is: " + _
         activationArgs.ActivationContext.Form.ToString())
        '</Snippet4>
        Console.Read()

    End Sub 'Main

    <SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy:=True)> _
    Public Sub Run()
        Main(New String() {})
        Console.ReadLine()

    End Sub 'Run
End Class 'Program
'</Snippet1>