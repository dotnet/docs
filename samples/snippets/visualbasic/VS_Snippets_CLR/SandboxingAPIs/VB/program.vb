 '<Snippet1>
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Reflection
Imports System.IO



Class Program
    
    Shared Sub Main(ByVal args() As String) 
        ' Create the permission set to grant to other assemblies.
        ' In this case we are granting the permissions found in the LocalIntranet zone.
        Dim e As New Evidence()
        e.AddHostEvidence(New Zone(SecurityZone.Intranet))
        Dim pset As PermissionSet = SecurityManager.GetStandardSandbox(e)
        
        Dim ads As New AppDomainSetup()
        ' Identify the folder to use for the sandbox.
        ads.ApplicationBase = "C:\Sandbox"
        ' Copy the application to be executed to the sandbox.
        Directory.CreateDirectory("C:\Sandbox")
        File.Copy("..\..\..\HelloWorld\bin\debug\HelloWorld.exe", "C:\sandbox\HelloWorld.exe", True)
        
        ' Create the sandboxed domain.
        Dim sandbox As AppDomain = AppDomain.CreateDomain("Sandboxed Domain", e, ads, pset, Nothing)
        sandbox.ExecuteAssemblyByName("HelloWorld")
    
    End Sub 'Main
End Class 'Program

'</Snippet1>