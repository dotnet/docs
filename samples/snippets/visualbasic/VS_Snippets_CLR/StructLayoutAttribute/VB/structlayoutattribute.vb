'  System.Runtime.InteropServices.StructLayoutAttribute.StructLayoutAttribute(LayoutKind)
'  System.Runtime.InteropServices.StructLayoutAttribute.CharSet
'  System.Runtime.InteropServices.StructLayoutAttribute.Size
   
'  The program shows a managed declaration of the GetSystemTime function and defines 
'  MySystemTime class with explicit layout. The GetSystemTime get the system time
'  and print to the console.

' <Snippet1>
Imports System
Imports System.Runtime.InteropServices

Namespace InteropSample

' <Snippet2>
' <Snippet3>
   <StructLayout(LayoutKind.Explicit, Size:=16, CharSet:=CharSet.Ansi)> _
   Public Class MySystemTime
      <FieldOffset(0)> Public wYear As Short
      <FieldOffset(2)> Public wMonth As Short
      <FieldOffset(4)> Public wDayOfWeek As Short
      <FieldOffset(6)> Public wDay As Short
      <FieldOffset(8)> Public wHour As Short
      <FieldOffset(10)> Public wMinute As Short
      <FieldOffset(12)> Public wSecond As Short
      <FieldOffset(14)> Public wMilliseconds As Short
   End Class 'MySystemTime


   Class LibWrapper

      <DllImport("kernel32.dll")> _
      Public Shared Sub GetSystemTime(<MarshalAs(UnmanagedType.LPStruct)> ByVal st As MySystemTime)
      End Sub
   End Class 'LibWrapper

   Class TestApplication

      Public Shared Sub Main()
         Try
            Dim sysTime As New MySystemTime()
            LibWrapper.GetSystemTime(sysTime)
            Console.WriteLine("The System time is {0}/{1}/{2} {3}:{4}:{5}", sysTime.wDay, sysTime.wMonth, sysTime.wYear, sysTime.wHour, sysTime.wMinute, sysTime.wSecond)
         Catch e As TypeLoadException
            Console.WriteLine(("TypeLoadException : " + e.Message.ToString()))
         Catch e As Exception
            Console.WriteLine(("Exception : " + e.Message.ToString()))
         End Try
      End Sub 'Main
   End Class 'TestApplication
End Namespace 'InteropSample 
' </Snippet3>
' </Snippet2>
' </Snippet1>