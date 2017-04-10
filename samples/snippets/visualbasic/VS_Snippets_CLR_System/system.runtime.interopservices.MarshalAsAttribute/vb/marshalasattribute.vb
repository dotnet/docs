'<snippet1>
Imports System.Runtime.InteropServices

Module Module1

    Sub Main()

    End Sub

    'Applied to a parameter.
    Public Sub M1(<MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal msg As String)
        msg = msg + "Goodbye"
    End Sub

    'Applied to a field within a class.
    Class MsgText
        <MarshalAsAttribute(UnmanagedType.LPWStr)> Public msg As String
    End Class

    'Applied to a a return value.
    Public Function M2() As <MarshalAsAttribute(UnmanagedType.LPWStr)> String
        Return "Hello World"
    End Function

End Module
'</snippet1>