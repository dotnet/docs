 ' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections.Specialized


' This example dDemonstrates how to access and modify remote 
' configuration files


Public Class RemoteConfiguration
    
    
    ' The application entry point.
    Public Shared Sub Main(ByVal args() As String) 
    
        ' This string  contains the name of 
        ' the remote server.
        Dim machineName As String = String.Empty
        
        ' Get the user's input.
        If args.Length > 0 Then
            ' Get the name of the remote server.
            ' The machine name must be in the format
            ' accepted by the operating system.
            machineName = args(0)
            
            ' Get the user name and password.
            If args.Length > 1 Then
                Dim userName As String = args(1)
                Dim password As String = String.Empty
                If args.Length > 2 Then
                    password = args(2)
                End If 
                ' Update the site configuration.
                UpdateConfiguration(machineName, userName, password)
            Else
                ' Update the site configuration.
                UpdateConfiguration(machineName)
            End If
        Else
            Console.WriteLine("Enter a valid server name.")
        End If
    
    End Sub 'Main
    
    
    ' Update the configuration file using the credentials
    ' of the user running this application. Tthen,
    ' call the routine that reads the configuration 
    ' settings.
    ' Note that the system issues an error if the user
    ' does not have administrative privileges on the server.
    Public Overloads Shared Sub _
    UpdateConfiguration(ByVal machineName As String)
        Try
            Console.WriteLine("MachineName:  [{0}]", machineName)
            Console.WriteLine("UserDomainName:  [{0}]", _
                Environment.UserDomainName)
            Console.WriteLine("UserName:  [{0}]", _
                Environment.UserName)

            ' Get the configuration.
            Dim config As Configuration = _
                WebConfigurationManager.OpenWebConfiguration("/", _
                "Default Web Site", Nothing, machineName)

            ' Add a new key/value pair to appSettings.
            Dim count As String = _
                config.AppSettings.Settings.Count.ToString()
            config.AppSettings.Settings.Add("key_" + count, _
                "value_" + count)

            ' Save changes to the file.
            config.Save()

            ' Read the new appSettings.
            ReadAppSettings(config)
        Catch err As Exception
            Console.WriteLine(err.ToString())
        End Try

    End Sub 'UpdateConfiguration
    
    
    ' Update the configuration file using the credentials
    ' of the passed user,  then call the routine that reads 
    ' the configuration settings.
    ' Note that the system issues an error if the user
    ' does not have administrative privileges on the server.
    Public Overloads Shared Sub UpdateConfiguration(ByVal _
        machineName As String, ByVal userName As String, ByVal _
        password As String)
        Try
            Console.WriteLine("MachineName:  [{0}]", machineName)
            Console.WriteLine("UserName:  [{0}]", userName)
            Console.WriteLine("Password:  [{0}]", password)

            ' Get the configuration.
            Dim config As Configuration = _
                WebConfigurationManager.OpenWebConfiguration("/", _
                "Default Web Site", Nothing, machineName, _
                userName, password)


            ' Add a new key/value pair to appSettings
            Dim count As String = _
                config.AppSettings.Settings.Count.ToString()
            config.AppSettings.Settings.Add("key_" + _
                count, "value_" + count)
            ' Save to the file,
            config.Save()

            ' Read the new appSettings.
            ReadAppSettings(config)

        Catch err As Exception
            Console.WriteLine(err.ToString())
        End Try

    End Sub 'UpdateConfiguration
    
    
    ' Read the appSettings on the remote server.
    Public Shared Sub ReadAppSettings(ByVal config As Configuration) 
        Try
            Console.WriteLine("--- Printing appSettings at [{0}] ---", _
                config.FilePath)
            Console.WriteLine("Count: [{0}]", _
                config.AppSettings.Settings.Count)
            Dim key As String
            For Each key In  config.AppSettings.Settings.AllKeys
                Console.WriteLine("  [{0}] = [{1}]", _
                    key, config.AppSettings.Settings(key).Value)
            Next key
            Console.WriteLine()
        
        Catch err As Exception
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'ReadAppSettings
End Class 'RemoteConfiguration

' </Snippet1>
