Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class Sample
    Inherits SoapExtension
       
' <Snippet1>
    Public Overrides Sub ProcessMessage(message As SoapMessage)
        Select Case message.Stage
            
            Case SoapMessageStage.BeforeSerialize
            
            Case SoapMessageStage.AfterSerialize
                WriteOutput(message)
            
            Case SoapMessageStage.BeforeDeserialize
                WriteInput(message)
            
            Case SoapMessageStage.AfterDeserialize
            
        End Select
    End Sub    
    
' </Snippet1>

    Public Overloads Overrides Function GetInitializer(lmi As LogicalMethodInfo, sea As SoapExtensionAttribute) As Object
        ' method added so sample will compile
        Dim myobject As New Object()
        Return myobject
    End Function 'GetInitializer    

    Public Overloads Overrides Function GetInitializer(t as Type) As Object
        ' method added so sample will compile
    End Function
    
    Public Overrides Sub Initialize(o As Object)
        ' method added so sample will compile
    End Sub 'Initialize     
    

    Public Sub WriteOutput(message As SoapMessage)
        ' method added so sample will compile
    End Sub 'WriteOutput     
    
    Public Sub WriteInput(message As SoapMessage)
        ' method added so sample will compile
    End Sub 'WriteInput 
End Class 'Sample

Public Class MyEntryClass
	Public Shared Sub Main()

	End Sub
End Class
