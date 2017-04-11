 ' <Snippet1>
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration




NotInheritable Public Class UsingGenericEnumConverter
    
    Public Shared Sub GetPermission() 
        Try
            Dim section As CustomSection = _
            ConfigurationManager.GetSection("CustomSection")
            Console.WriteLine("Default Permission: {0}", _
            section.Permission.ToString())
        Catch e As System.Exception
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'GetPermission
    
    
    Public Shared Sub SetPermission() 
        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
            
            Dim section As CustomSection = _
            config.Sections.Get("CustomSection")
            
            section.Permission = _
            CustomSection.Permissions.FullControl
            
            section.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
            config.Save()
            
            Console.WriteLine( _
            "Current Protection: {0}", _
            section.Permission.ToString())
        Catch e As System.Exception
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'SetPermission
End Class 'UsingGenericEnumConverter
' </Snippet1>