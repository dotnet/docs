 ' <Snippet1>
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration




NotInheritable Public Class UsingTypeNameConverter
    
    Public Shared Sub GetTypeName() 
        Try
            
            Dim section As CustomSection = _
            ConfigurationManager.GetSection("CustomSection")
            Console.WriteLine( _
            "CustomSection type: {0}", section)
        Catch e As System.Exception
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'GetTypeName
End Class 'UsingTypeNameConverter 
' </Snippet1>