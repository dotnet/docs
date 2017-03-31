'Types:System.AppDomain,System.AppDomainSetup Vendor: Richter
'<snippet1>
Imports System
Imports System.Reflection
Imports System.Threading

'<snippet2>
Module Module1
    Sub Main()

        ' Get and display the friendly name of the default AppDomain.
        Dim callingDomainName As String = Thread.GetDomain().FriendlyName
        Console.WriteLine(callingDomainName)

        ' Get and display the full name of the EXE assembly.
        Dim exeAssembly As String = [Assembly].GetEntryAssembly().FullName
        Console.WriteLine(exeAssembly)

        ' Construct and initialize settings for a second AppDomain.
        Dim ads As New AppDomainSetup()
        ads.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
        ads.DisallowBindingRedirects = False
        ads.DisallowCodeDownload = True
        ads.ConfigurationFile = _
            AppDomain.CurrentDomain.SetupInformation.ConfigurationFile

        ' Create the second AppDomain.
        Dim ad2 As AppDomain = AppDomain.CreateDomain("AD #2", Nothing, ads)

        ' Create an instance of MarshalbyRefType in the second AppDomain. 
        ' A proxy to the object is returned.
        Dim mbrt As MarshalByRefType = CType( _
            ad2.CreateInstanceAndUnwrap(exeAssembly, _
                 GetType(MarshalByRefType).FullName), MarshalByRefType)

        ' Call a method on the object via the proxy, passing the default 
        ' AppDomain's friendly name in as a parameter.
        mbrt.SomeMethod(callingDomainName)

        ' Unload the second AppDomain. This deletes its object and 
        ' invalidates the proxy object.
        AppDomain.Unload(ad2)
        Try
            ' Call the method again. Note that this time it fails because 
            ' the second AppDomain was unloaded.
            mbrt.SomeMethod(callingDomainName)
            Console.WriteLine("Sucessful call.")
        Catch e As AppDomainUnloadedException
            Console.WriteLine("Failed call; this is expected.")
        End Try

    End Sub
End Module
'</snippet2>

'<snippet3>
' Because this class is derived from MarshalByRefObject, a proxy 
' to a MarshalByRefType object can be returned across an AppDomain 
' boundary.
Public Class MarshalByRefType
    Inherits MarshalByRefObject

    '  Call this method via a proxy.
    Public Sub SomeMethod(ByVal callingDomainName As String)

        ' Get this AppDomain's settings and display some of them.
        Dim ads As AppDomainSetup = AppDomain.CurrentDomain.SetupInformation
        Console.WriteLine("AppName={0}, AppBase={1}, ConfigFile={2}", _
            ads.ApplicationName, ads.ApplicationBase, ads.ConfigurationFile)

        ' Display the name of the calling AppDomain and the name 
        ' of the second domain.
        ' NOTE: The application's thread has transitioned between 
        ' AppDomains.
        Console.WriteLine("Calling from '{0}' to '{1}'.", _
            callingDomainName, Thread.GetDomain().FriendlyName)
    End Sub
End Class
'</snippet3>

'This code produces output similar to the following:
' 
' AppDomainX.exe
' AppDomainX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
' AppName=, AppBase=C:\AppDomain\bin, ConfigFile=C:\AppDomain\bin\AppDomainX.exe.config
' Calling from 'AppDomainX.exe' to 'AD #2'.
' Failed call; this is expected.
'</snippet1>

