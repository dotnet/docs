' <SNIPPET1>
Imports System
Imports System.Threading
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions



Class ADSetAppDomainPolicy
   
   Overloads Shared Sub Main(args() As String)
      ' Create a new application domain.
      Dim domain As AppDomain = System.AppDomain.CreateDomain("MyDomain")
      
      ' Create a new AppDomain PolicyLevel.
      Dim polLevel As PolicyLevel = PolicyLevel.CreateAppDomainLevel()
      ' Create a new, empty permission set.
      Dim permSet As New PermissionSet(PermissionState.None)
      ' Add permission to execute code to the permission set.
      permSet.AddPermission(New SecurityPermission(SecurityPermissionFlag.Execution))
      ' Give the policy level's root code group a new policy statement based
      ' on the new permission set.
      polLevel.RootCodeGroup.PolicyStatement = New PolicyStatement(permSet)
      ' Give the new policy level to the application domain.
      domain.SetAppDomainPolicy(polLevel)
      
      ' Try to execute the assembly.
      Try
         ' This will throw a PolicyException if the executable tries to
         ' access any resources like file I/Q or window creation.
         domain.ExecuteAssembly("Assemblies\MyWindowsExe.exe")
      Catch e As PolicyException
         Console.WriteLine("PolicyException: {0}", e.Message)
      End Try
      
      AppDomain.Unload(domain)
   End Sub 'Main
End Class 'ADSetAppDomainPolicy
' </SNIPPET1>