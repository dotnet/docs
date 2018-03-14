' <Snippet1>
Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

'Class to test for the ExplicitLayout property.
   <StructLayout(LayoutKind.Explicit, Size := 16, CharSet := CharSet.Ansi)>  _
   Public Class MySystemTime
      <FieldOffset(0)> Public wYear As Short
      <FieldOffset(2)> Public wMonth As Short
      <FieldOffset(4)> Public wDayOfWeek As Short
      <FieldOffset(6)> Public wDay As Short
      <FieldOffset(8)> Public wHour As Short
      <FieldOffset(10)> Public wMinute As Short
      <FieldOffset(12)> Public wSecond As Short
      <FieldOffset(14)> Public wMilliseconds As Short
   End Class 

Public Class Program
    Public Shared Sub Main()
        'Create an instance of type using the GetType method.
        Dim t As Type = GetType(MySystemTime)
        ' Get and display the IsExplicitLayout property.
        Console.WriteLine(vbCrLf & "IsExplicitLayout for MySystemTime is {0}.", _
            t.IsExplicitLayout)
    End Sub
End Class
' </Snippet1>