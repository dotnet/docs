'<Snippet1>
Imports System

Namespace PerformanceLibrary

' Satisfies rule: AvoidUnsealedAttributes.
<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Struct)>  _
NotInheritable Public Class DeveloperAttribute
    Inherits Attribute
    Private nameValue As String
    
    Public Sub New(name As String)
        nameValue = name
    End Sub
    
    
    Public ReadOnly Property Name() As String
        Get
            Return nameValue
        End Get
    End Property
End Class 

End Namespace
'</Snippet1>
