'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class DayOfWeek03

        Private dayOfWeek(,) As String = {{"Wed", "Thu", "..."}, _
                                          {"Sat", "Sun", "..."}}
                                          ' ...

        Default ReadOnly Property Item(month As Integer, day As Integer) As String
            Get
                Return dayOfWeek(month - 1, day - 1)
            End Get
        End Property

    End Class

    Public Class RedesignedDayOfWeek03

        Private dayOfWeek() As String = _
            {"Tue", "Wed", "Thu", "Fri", "Sat", "Sun", "Mon"}
        Private daysInPreviousMonth() As Integer = _
            {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30}

        Function GetDayOfWeek(month As Integer, day As Integer) As String
            Return dayOfWeek((daysInPreviousMonth(month - 1) + day) Mod 7)
        End Function

    End Class

End Namespace
'</Snippet1>
