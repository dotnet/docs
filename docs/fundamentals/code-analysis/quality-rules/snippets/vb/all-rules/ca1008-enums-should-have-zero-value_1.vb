Imports System

Namespace ca1008

    Public Enum TraceLevel
        Off = 0
        AnError = 1
        Warning = 2
        Info = 3
        Verbose = 4
    End Enum

    <Flags>
    Public Enum TraceOptions
        None = 0
        CallStack = &H1
        LogicalStack = &H2
        DateTime = &H4
        Timestamp = &H8
    End Enum

    <Flags>
    Public Enum BadTraceOptions
        CallStack = 0
        LogicalStack = &H1
        DateTime = &H2
        Timestamp = &H4
    End Enum

    Class UseBadTraceOptions

        Shared Sub Main1008()

            ' Set the flags.
            Dim badOptions As BadTraceOptions =
            BadTraceOptions.LogicalStack Or BadTraceOptions.Timestamp

            ' Check whether CallStack is set.
            If ((badOptions And BadTraceOptions.CallStack) =
             BadTraceOptions.CallStack) Then
                ' This 'If' statement is always true.
            End If

        End Sub

    End Class

End Namespace
