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