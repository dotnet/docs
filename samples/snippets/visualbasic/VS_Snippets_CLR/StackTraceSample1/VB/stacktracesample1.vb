'<snippet1>
Imports System
Imports System.Diagnostics

Class StackTraceSample
   
    <STAThread()>  _
    Public Shared Sub Main()

        Dim sample As New StackTraceSample()
        Try
   
            sample.MyPublicMethod()
        Catch
            ' Create a StackTrace that captures
            ' filename, line number, and column
            ' information for the current thread.
            Dim st As New StackTrace(True)
            Dim i As Integer

            For i = 0 To st.FrameCount - 1

                ' Note that high up the call stack, there is only
                ' one stack frame.
                Dim sf As StackFrame = st.GetFrame(i)
                Console.WriteLine()
                Console.WriteLine("High up the call stack, Method: {0}", _
                    sf.GetMethod())
            
                Console.WriteLine("High up the call stack, Line Number: {0}", _
                    sf.GetFileLineNumber())
            Next i
        End Try
    End Sub
   
   Public Sub MyPublicMethod()
      MyProtectedMethod()
   End Sub
    
   Protected Sub MyProtectedMethod()
      Dim mic As New MyInternalClass()
      mic.ThrowsException()
   End Sub
   
   
   Class MyInternalClass
      
      Public Sub ThrowsException()
         Try
            Throw New Exception("A problem was encountered.")
         Catch e As Exception

            ' Create a StackTrace that captures filename,
            ' line number and column information.
            Dim st As New StackTrace(True)

            Dim stackIndent As String = ""
            Dim i As Integer
            For i = 0 To st.FrameCount - 1
               ' Note that at this level, there are four
               ' stack frames, one for each method invocation.
               Dim sf As StackFrame = st.GetFrame(i)
               Console.WriteLine()
               Console.WriteLine(stackIndent + " Method: {0}", _
                   sf.GetMethod())
               Console.WriteLine(stackIndent + " File: {0}", _
                   sf.GetFileName())
               Console.WriteLine(stackIndent + " Line Number: {0}", _
                   sf.GetFileLineNumber())
               stackIndent += "  "
            Next i
            Throw e
         End Try
      End Sub
   End Class
End Class


' This console application produces the following output when
' compiled with the Debug configuration.
'   
'    Method: Void ThrowsException()
'    File: c:\pp\samples\stacktraceframe\myclass.vb
'    Line Number: 55
' 
'      Method: Void MyProtectedMethod()
'      File: c:\pp\samples\stacktraceframe\myclass.vb
'      Line Number: 42
' 
'        Method: Void MyPublicMethod()
'        File: c:\pp\samples\stacktraceframe\myclass.vb
'        Line Number: 37
' 
'          Method: Void Main(System.String[])
'          File: c:\pp\samples\stacktraceframe\myclass.vb
'          Line Number: 13
' 
'   High up the call stack, Method: Void Main(System.String[])
'   High up the call stack, Line Number: 18
' 
' 
' This console application produces the following output when
' compiled with the Release configuration.
' 
'    Method: Void ThrowsException()
'    File:
'    Line Number: 0
' 
'      Method: Void Main(System.String[])
'      File:
'      Line Number: 0
' 
'   High up the call stack, Method: Void Main()
'   High up the call stack, Line Number: 0
'
'</snippet1>