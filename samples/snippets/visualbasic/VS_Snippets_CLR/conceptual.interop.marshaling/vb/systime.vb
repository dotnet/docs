'<snippet25>
Imports System.Runtime.InteropServices

' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential)>
Public Class SystemTime
    Public year As Short
    Public month As Short
    Public weekday As Short
    Public day As Short
    Public hour As Short
    Public minute As Short
    Public second As Short
    Public millisecond As Short
End Class

Friend Class NativeMethods
    ' Declares a managed prototype for the unmanaged function.
    Friend Declare Sub GetSystemTime Lib "Kernel32.dll" (
        <[In](), Out()> ByVal st As SystemTime)
End Class

Public Class App
    Public Shared Sub Main()
        Console.WriteLine("VB .NET SysTime Sample using Platform Invoke")
        Dim st As New SystemTime()
        NativeMethods.GetSystemTime(st)
        Console.Write($"The Date is: {st.month} {st.day} {st.year}")
    End Sub
End Class
' The program produces output similar to the following:
'
' VB .NET SysTime Sample using Platform Invoke
' The Date is: 3 21 2010
'</snippet25>
