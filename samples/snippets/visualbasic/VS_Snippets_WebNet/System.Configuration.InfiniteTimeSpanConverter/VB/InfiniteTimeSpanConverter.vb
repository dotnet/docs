'<Snippet1>
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration


NotInheritable Public Class UsingInfiniteTimeSpanConverter
    
    Public Shared Sub GetTimeDelay() 
        Try
            Dim section As CustomSection = _
            ConfigurationManager.GetSection( _
            "CustomSection")
            Console.WriteLine("timeDelay: {0}", _
            section.TimeDelay.ToString())
        Catch e As System.Exception
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'GetTimeDelay
    
    
    Public Shared Sub SetTimeDelay() 
        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
            
            Dim section As CustomSection = _
            config.Sections.Get("CustomSection")
            
            Dim td As New TimeSpan()
            
            td = _
            TimeSpan.FromMinutes( _
            DateTime.Now.Minute)
            
            section.TimeDelay = td
            
            section.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
            config.Save()
            
            Console.WriteLine("timeDelay: {0}", _
            section.TimeDelay.ToString())
        Catch e As System.Exception
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'SetTimeDelay
End Class 'UsingInfiniteTimeSpanConverter
'</Snippet1>