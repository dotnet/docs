'<Snippet1>
' To replace the default AppDomainManager, identify  the 
' replacement assembly and replacement type in the 
' APPDOMAIN_MANAGER_ASM and APPDOMAIN_MANAGER_TYPE  
' environment variables. For example:
' set APPDOMAIN_MANAGER_TYPE=library.TestAppDomainManager
' set APPDOMAIN_MANAGER_ASM=library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f1368f7b12a08d72
Imports System
Imports System.Collections
Imports System.Net
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Security.Principal
Imports System.Threading
Imports System.Runtime.InteropServices

<assembly: System.Security.AllowPartiallyTrustedCallersAttribute()>
<SecurityPermissionAttribute(SecurityAction.LinkDemand, _
    Flags:=SecurityPermissionFlag.Infrastructure)> _
<SecurityPermissionAttribute(SecurityAction.InheritanceDemand, _
    Flags:=SecurityPermissionFlag.Infrastructure)> _
<GuidAttribute("F4D15099-3407-4A7E-A607-DEA440CF3891")> _
Public Class MyAppDomainManager
    Inherits AppDomainManager
    Private mySecurityManager As HostSecurityManager = Nothing
    
    Public Sub New() 
        Console.WriteLine(" My AppDomain Manager ")
        mySecurityManager = AppDomain.CurrentDomain.CreateInstanceAndUnwrap( _
            "CustomSecurityManager, Version=1.0.0.3, Culture=neutral, " & _
            "PublicKeyToken=5659fc598c2a503e", "MyNamespace.MySecurityManager")
        Console.WriteLine(" Custom Security Manager Created.")    
    End Sub 'New
    
    '<Snippet2>
    Public Overrides Sub InitializeNewDomain(ByVal appDomainInfo _
        As AppDomainSetup) 
        Console.Write("Initialize new domain called:  ")
        Console.WriteLine(AppDomain.CurrentDomain.FriendlyName)
        InitializationFlags = _
            AppDomainManagerInitializationOptions.RegisterWithHost   
    End Sub 'InitializeNewDomain
    '</Snippet2>

    '<Snippet3>
    Public Overrides ReadOnly Property HostSecurityManager() _
        As HostSecurityManager 
        Get
            Return mySecurityManager
        End Get
    End Property
End Class 'MyAppDomainManager 
    '</Snippet3>
'</Snippet1>