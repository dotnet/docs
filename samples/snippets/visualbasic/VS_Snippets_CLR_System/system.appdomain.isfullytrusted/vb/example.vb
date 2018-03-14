'<Snippet1>
Public Class Worker
    Inherits MarshalByRefObject
    
    Shared Sub Main()
 
        Dim w As New Worker()
        w.TestIsFullyTrusted()
        
        Dim adSandbox As AppDomain = GetInternetSandbox()
        w = CType(adSandbox.CreateInstanceAndUnwrap(
                            GetType(Worker).Assembly.FullName, 
                            GetType(Worker).FullName), 
                  Worker)
        w.TestIsFullyTrusted()
    
    End Sub 
    
    Public Sub TestIsFullyTrusted() 

        Dim ad As AppDomain = AppDomain.CurrentDomain
        Console.WriteLine(vbCrLf & "Application domain '{0}': IsFullyTrusted = {1}", 
                          ad.FriendlyName, ad.IsFullyTrusted)
        
        Console.WriteLine("   IsFullyTrusted = {0} for the current assembly", 
                          GetType(Worker).Assembly.IsFullyTrusted)
        
        Console.WriteLine("   IsFullyTrusted = {0} for mscorlib", 
                          GetType(Integer).Assembly.IsFullyTrusted)
    
    End Sub 
    
    ' ------------ Helper method ---------------------------------------
    Shared Function GetInternetSandbox() As AppDomain 

        ' Create the permission set to grant to all assemblies.
        Dim hostEvidence As New System.Security.Policy.Evidence()
        hostEvidence.AddHostEvidence(
                    New System.Security.Policy.Zone(System.Security.SecurityZone.Internet))
        Dim pset As System.Security.PermissionSet = 
                           System.Security.SecurityManager.GetStandardSandbox(hostEvidence)
        
        ' Identify the folder to use for the sandbox.
        Dim ads As New AppDomainSetup()
        ads.ApplicationBase = System.IO.Directory.GetCurrentDirectory()
        
        ' Create the sandboxed application domain.
        Return AppDomain.CreateDomain("Sandbox", hostEvidence, ads, pset, Nothing)
    
    End Function 
End Class 

' This example produces output similar to the following:
'
'Application domain 'Example.exe': IsFullyTrusted = True
'   IsFullyTrusted = True for the current assembly
'   IsFullyTrusted = True for mscorlib
'
'Application domain 'Sandbox': IsFullyTrusted = False
'   IsFullyTrusted = False for the current assembly
'   IsFullyTrusted = True for mscorlib
' 
'</Snippet1>