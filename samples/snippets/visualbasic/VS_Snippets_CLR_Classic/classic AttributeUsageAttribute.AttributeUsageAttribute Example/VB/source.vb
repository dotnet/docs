Imports System

' <Snippet1>
Namespace System.Runtime.InteropServices
    
    <AttributeUsage(AttributeTargets.Method _
        Or AttributeTargets.Field _
        Or AttributeTargets.Property)> _    
    Public Class DispIdAttribute    
        Inherits System.Attribute
        
        Public Sub New(value As Integer)
            ' . . .
        End Sub
        
        Public ReadOnly Property Value() As Integer
            Get
                ' . . .
                Return 0
            End Get
        End Property
    End Class
End Namespace
' </Snippet1>
