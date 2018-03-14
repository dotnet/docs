
Imports System
Imports System.EnterpriseServices

'/ <summary>
'/ Summary description for Class1.
'/ </summary>

Class DeployServicedComponent
    
    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()>  _
    Shared Sub Main(ByVal args() As String) 
        '<snippet0>
        Try
            '<snippet1>
            Dim applicationName As String = "Queued Component"
            Dim typeLibraryName As String = Nothing
            Dim helper As New RegistrationHelper

            ' Call the InstallAssembly method passing it the name of the assembly to 
            ' install as a COM+ application, the COM+ application name, and 
            ' the name of the type library file.
            ' Setting the application name and the type library to NULL (nothing in Visual Basic .NET
            ' allows you to use the COM+ application name that is given in the assembly and 
            ' the default type library name. The application name in the assembly metadata 
            ' takes precedence over the application name you provide to InstallAssembly. 
            helper.InstallAssembly("C:..\..\QueuedComponent.dll", applicationName, typeLibraryName, InstallationFlags.CreateTargetApplication)
            MsgBox("Registration succeeded: Type library " & typeLibraryName & " created.")
            Console.Read()
            '</snippet1>

            '<snippet2>
            ' Create a RegistrationConfig object and set its attributes
            ' Create a RegistrationHelper object, and call the InstallAssemblyFromConfig
            ' method by passing the RegistrationConfiguration object to it as a 
            ' reference object
            Dim registrationConfiguration As New RegistrationConfig()
            registrationConfiguration.AssemblyFile = "C:..\..\QueuedComponent.dll"
            registrationConfiguration.Application = "MyApp"
            registrationConfiguration.InstallationFlags = InstallationFlags.CreateTargetApplication
            Dim helperFromConfig As New RegistrationHelper()
            helperFromConfig.InstallAssemblyFromConfig(registrationConfiguration)
            '</snippet2>

            '<snippet3>  
        Catch e As RegistrationException
            MsgBox(e.Message)
            ' </snippet3>

            ' <snippet4>
            ' Check whether the ErrorInfo property of the RegistrationException object is null. 
            ' If there is no extended error information about 
            ' methods related to multiple COM+ objects ErrorInfo will be null.
            If Not (e.ErrorInfo Is Nothing) Then
                ' Gets an array of RegistrationErrorInfo objects describing registration errors
                Dim registrationErrorInfos As RegistrationErrorInfo() = e.ErrorInfo

                ' Iterate through the array of RegistrationErrorInfo objects and disply the 
                ' ErrorString for each object.
                Dim registrationErrorInfo As RegistrationErrorInfo
                For Each registrationErrorInfo In registrationErrorInfos
                    MsgBox(registrationErrorInfo.ErrorString)
                Next registrationErrorInfo
            End If
            ' </snippet4>
            Console.Read()
        End Try
        '</snippet0>

    End Sub 'Main 
End Class 'DeployServicedComponent