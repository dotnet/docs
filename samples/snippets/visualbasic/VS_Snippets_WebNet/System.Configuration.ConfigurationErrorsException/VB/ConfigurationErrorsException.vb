 ' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Collections



' Define a custom section.

NotInheritable Public Class CustomSection
    Inherits ConfigurationSection
    
    Public Sub New() 
    
    End Sub 'New
    
    
    <ConfigurationProperty("fileName", DefaultValue:="default.txt", IsRequired:=True, IsKey:=False), StringValidator(InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", MinLength:=1, MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property
    
    
    <ConfigurationProperty("maxUsers", DefaultValue:=10, IsRequired:=False), LongValidator(MinValue:=1, MaxValue:=100, ExcludeRange:=False)> _
    Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = value
        End Set
    End Property
End Class 'CustomSection 


' Create the custom section and write it to
' the configuration file.

Class UsingConfigurationErrorsException
    
    ' Create a custom section.
    Shared Sub New()

        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' If the section does not exist in the configuration
        ' file, create it and save it to the file.
        If config.Sections("CustomSection") Is Nothing Then
            Dim custSection As New CustomSection()
            config.Sections.Add("CustomSection", custSection)
            custSection = config.GetSection("CustomSection")
            custSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
        End If

    End Sub 'New
    
    
    ' <Snippet2>
    ' Modify a custom section and cause configuration 
    ' error exceptions.
    Shared Sub ModifyCustomSection() 
        
        Try
            ' Get the application configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim custSection _
            As CustomSection = _
            config.Sections("CustomSection")
             
            ' Change the section properties.
            custSection.FileName = "newName.txt"
            
            ' Cause an exception.
            custSection.MaxUsers = _
            custSection.MaxUsers + 100
            
            If Not custSection.ElementInformation.IsLocked Then
                config.Save()
            Else
                Console.WriteLine( _
                "Section was locked, could not update.")
            End If
        Catch err As ConfigurationErrorsException
            
            ' <Snippet3>
            Dim msg As String = err.Message
            Console.WriteLine("Message: {0}", msg)
            ' </Snippet3>
            ' <Snippet4>
            Dim fileName As String = err.Filename
            Console.WriteLine("Filename: {0}", _
            fileName)
            ' </Snippet4>
            ' <Snippet5>
            Dim lineNumber As Integer = err.Line
            Console.WriteLine("Line: {0}", _
            lineNumber.ToString())
            ' </Snippet5>
            ' <Snippet6>
            Dim bmsg As String = err.BareMessage
            Console.WriteLine("BareMessage: {0}", bmsg)
            ' </Snippet6>
            ' <Snippet7>
            Dim src As String = err.Source
            Console.WriteLine("Source: {0}", src)
            ' </Snippet7>
            ' <Snippet8>
            Dim st As String = err.StackTrace
            Console.WriteLine("StackTrace: {0}", st)
            ' </Snippet8>    
        End Try

    End Sub 'ModifyCustomSection
    ' </Snippet2>

    Shared Sub Main(ByVal args() As String) 
        ModifyCustomSection()
    
    End Sub 'Main
End Class 'UsingConfigurationErrorsException 

' </Snippet1>