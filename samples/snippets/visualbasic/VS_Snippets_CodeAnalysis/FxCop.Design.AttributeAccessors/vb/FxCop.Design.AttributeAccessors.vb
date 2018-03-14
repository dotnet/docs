'<Snippet1>
Imports System

Namespace DesignLibrary

' Violates rule: DefineAccessorsForAttributeArguments.
<AttributeUsage(AttributeTargets.All)>  _
NotInheritable Public Class BadCustomAttribute
    Inherits Attribute
    Private data As String
    
    ' Missing the property that corresponds to 
    ' the someStringData parameter.
    Public Sub New(someStringData As String)
        data = someStringData
    End Sub 'New
End Class 'BadCustomAttribute

' Satisfies rule: Attributes should have accessors for all arguments.
<AttributeUsage(AttributeTargets.All)>  _
NotInheritable Public Class GoodCustomAttribute
    Inherits Attribute
    Private data As String
    
    Public Sub New(someStringData As String)
        data = someStringData
    End Sub 'New

    'The constructor parameter and property
    'name are the same except for case.
    
    Public ReadOnly Property SomeStringData() As String
        Get
            Return data
        End Get
    End Property
End Class 

End Namespace
'</Snippet1>
