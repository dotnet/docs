Imports System

Namespace ca1401

    ' Violates rule: PInvokesShouldNotBeVisible.
    Public Class NativeMethods
        Public Declare Function RemoveDirectory Lib "kernel32" (
        ByVal Name As String) As Boolean
    End Class

End Namespace
