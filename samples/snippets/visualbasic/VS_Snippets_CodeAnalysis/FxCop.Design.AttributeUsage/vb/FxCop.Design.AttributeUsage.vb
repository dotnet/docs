'<Snippet1>
Imports System

Namespace DesignLibrary

' Violates rule: MarkAttributesWithAttributeUsage.
NotInheritable Public Class BadCodeMaintainerAttribute
    Inherits Attribute
    Private developer As String
    
    Public Sub New(developerName As String)
        developer = developerName
    End Sub 'New
    
    Public ReadOnly Property DeveloperName() As String
        Get
            Return developer
        End Get
    End Property
End Class 

' Satisfies rule: Attributes specify AttributeUsage.
' The attribute is valid for type-level targets.
<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Enum Or _ 
   AttributeTargets.Interface Or AttributeTargets.Delegate)> _
NotInheritable Public Class GoodCodeMaintainerAttribute
    Inherits Attribute
    Private developer As String
    
    Public Sub New(developerName As String)
        developer = developerName
    End Sub 'New
    
    Public ReadOnly Property DeveloperName() As String
        Get
            Return developer
        End Get
    End Property
End Class 

End Namespace
'</Snippet1>
