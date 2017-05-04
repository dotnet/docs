'<snippet25>
Imports System
Imports System.Runtime.InteropServices

' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential)> _
Public Class SystemTime
    Public year As Short
    Public month As Short
    Public weekday As Short
    Public day As Short
    Public hour As Short
    Public minute As Short
    Public second As Short
    Public millisecond As Short
End Class 'SystemTime

Public Class LibWrap
    ' Declares a managed prototype for the unmanaged function.
    Declare Sub GetSystemTime Lib "Kernel32.dll" _
        (<[In](), Out()> ByVal st As SystemTime)
End Class 'LibWrap

Public Class App
    Public Shared Sub Main()
        Console.WriteLine("VB .NET SysTime Sample using Platform Invoke")
        Dim st As New SystemTime()
        LibWrap.GetSystemTime(st)
        Console.Write("The Date is: {0} {1} {2}", st.month, st.day, st.year)
    End Sub 'Main
End Class 'App

' The program produces output similar to the following:
'
' VB .NET SysTime Sample using Platform Invoke
' The Date is: 3 21 2010
'</snippet25>
