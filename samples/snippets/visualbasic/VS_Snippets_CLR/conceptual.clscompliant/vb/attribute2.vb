' Visual Basic .NET Document
Option Strict On

' <Snippet33>
<Assembly: CLSCompliantAttribute(True)>

Public Enum DescriptorType As Integer
    Type = 0
    Member = 1
End Enum

Public Class Descriptor
    Public Type As DescriptorType
    Public Description As String
End Class

<AttributeUsage(AttributeTargets.All)> _
Public Class DescriptionAttribute : Inherits Attribute
    Private desc As Descriptor

    Public Sub New(d As Descriptor)
        desc = d
    End Sub

    Public ReadOnly Property Descriptor As Descriptor
        Get
            Return desc
        End Get
    End Property
End Class
' </Snippet33>

Module Example
    Public Sub Main()

    End Sub
End Module

