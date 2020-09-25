Imports System

Namespace ca1721

    Public Class Test

        Public ReadOnly Property [Date]() As DateTime
            Get
                Return DateTime.Today
            End Get
        End Property

        ' Violates rule: PropertyNamesShouldNotMatchGetMethods.
        Public Function GetDate() As String
            Return Me.Date.ToString()
        End Function

    End Class

End Namespace
