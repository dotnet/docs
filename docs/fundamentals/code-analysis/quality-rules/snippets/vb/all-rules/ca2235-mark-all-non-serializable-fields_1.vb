Imports System
Imports System.Runtime.Serialization

Namespace ca2235

    Public Class Mouse

        ReadOnly Property NumberOfButtons As Integer

        ReadOnly Property ScanType As String

        Sub New(numberOfButtons As Integer, scanType As String)
            Me.NumberOfButtons = numberOfButtons
            Me.ScanType = scanType
        End Sub

    End Class

    <SerializableAttribute>
    Public Class InputDevices1

        ' Violates MarkAllNonSerializableFields.
        Dim opticalMouse As Mouse

        Sub New()
            opticalMouse = New Mouse(5, "optical")
        End Sub

    End Class

    <SerializableAttribute>
    Public Class InputDevices2

        ' Satisfies MarkAllNonSerializableFields.
        <NonSerializedAttribute>
        Dim opticalMouse As Mouse

        Sub New()
            opticalMouse = New Mouse(5, "optical")
        End Sub

    End Class

End Namespace
