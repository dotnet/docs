'<snippet1>
Imports System
Imports System.Diagnostics

Imports SampleInternal

Namespace SamplePublic
   
   ' This console application illustrates various uses
   ' of the StackTrace and StackFrame classes.
   
   Class ConsoleApp
      
'<snippet2>
      <STAThread()>  _
      Shared Sub Main()
         Dim mainClass As New ClassLevel1
         
         Try
            mainClass.InternalMethod()
         Catch
            Console.WriteLine(" Main method exception handler")
            
            ' Display file and line information, if available.
            Dim st As New StackTrace(New StackFrame(True))
            Console.WriteLine(" Stack trace for current level: {0}", _
               st.ToString())
            Console.WriteLine(" File: {0}", _
               st.GetFrame(0).GetFileName())
            Console.WriteLine(" Line Number: {0}", _
               st.GetFrame(0).GetFileLineNumber().ToString())
            
            Console.WriteLine()
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
         End Try
      End Sub 'Main
'</snippet2>
   End Class 'ConsoleApp
End Namespace 'StackFramePublic 

Namespace SampleInternal
   
   Public Class ClassLevel1
      
'<snippet3>
      Public Sub InternalMethod()
         Try
            Dim nestedClass As New ClassLevel2
            nestedClass.Level2Method()
         Catch e As Exception
            Console.WriteLine(" InternalMethod exception handler")
            
            ' Build a stack trace from one frame, skipping the 
            ' current frame and using the next frame.  By default,
            ' file and line information are not displayed.
            Dim st As New StackTrace(New StackFrame(1))
            Console.WriteLine(" Stack trace for next level frame: {0}", _
               st.ToString())
            Console.WriteLine(" Stack frame for next level: ")
            Console.WriteLine("   {0}", st.GetFrame(0).ToString())
            
            Console.WriteLine(" Line Number: {0}", _
               st.GetFrame(0).GetFileLineNumber().ToString())
            
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'InternalMethod
'</snippet3>
   End Class 'ClassLevel1
   
   Public Class ClassLevel2
      
'<snippet4>
      Public Sub Level2Method()
         Try
            Dim nestedClass As New ClassLevel3
            nestedClass.Level3Method()
         
         Catch e As Exception
            Console.WriteLine(" Level2Method exception handler")
            
            ' Display the full call stack at this level.
            Dim st1 As New StackTrace(True)
            Console.WriteLine(" Stack trace for this level: {0}", _
               st1.ToString())
            
            ' Build a stack trace from one frame, skipping the current
            ' frame and using the next frame.
            Dim st2 As New StackTrace(New StackFrame(1, True))
            Console.WriteLine(" Stack trace built with next level frame: {0}", _
                st2.ToString())
            
            ' Build a stack trace skipping the current frame, and
            ' including all the other frames.
            Dim st3 As New StackTrace(1, True)
            Console.WriteLine(" Stack trace built from the next level up: {0}", _
                st3.ToString())
            
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'Level2Method
'</snippet4>
   End Class 'ClassLevel2
   
   Public Class ClassLevel3
      
'<snippet5>
      Public Sub Level3Method()
         Try
            Dim nestedClass As New ClassLevel4()
            nestedClass.Level4Method()
         Catch e As Exception
            Console.WriteLine(" Level3Method exception handler")
            
            ' Build a stack trace from a dummy stack frame.
            ' Explicitly specify the source file name and line number.
            Dim st As New StackTrace(New StackFrame("source.cs", 60))
            Console.WriteLine(" Stack trace with dummy stack frame: {0}", _
               st.ToString())
            Dim i As Integer
            For i = 0 To st.FrameCount - 1
'<snippet7>
               ' Display the stack frame properties.
               Dim sf As StackFrame = st.GetFrame(i)
               Console.WriteLine(" File: {0}", sf.GetFileName())
               Console.WriteLine(" Line Number: {0}", _
                  sf.GetFileLineNumber())
               ' The column number defaults to zero when not initialized.
               Console.WriteLine(" Column Number: {0}", _
                  sf.GetFileColumnNumber())
               If sf.GetILOffset <> StackFrame.OFFSET_UNKNOWN
                  Console.WriteLine(" Intermediate Language Offset: {0}", _
                      sf.GetILOffset())
               End If
               If sf.GetNativeOffset <> StackFrame.OFFSET_UNKNOWN
                 Console.WriteLine(" Native Offset: {0}", _
                     sf.GetNativeOffset())
               End If
'</snippet7>
            Next i 
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'Level3Method
'</snippet5>
   End Class 'ClassLevel3
   
   Public Class ClassLevel4
      
      Public Sub Level4Method()
'<snippet6>
         Try
            Dim [nestedClass] As New ClassLevel5()
            [nestedClass].Level5Method()
         Catch e As Exception
            Console.WriteLine(" Level4Method exception handler")
            
            ' Build a stack trace from a dummy stack frame.
            ' Explicitly specify the source file name, line number
            ' and column number.
            Dim st As New StackTrace(New StackFrame("source.cs", 79, 24))
            Console.WriteLine(" Stack trace with dummy stack frame: {0}", _
               st.ToString())
            
            ' Access the StackFrames explicitly to display the file
            ' name, line number and column number properties.
            ' StackTrace.ToString only includes the method name. 
            Dim i As Integer
            For i = 0 To st.FrameCount - 1
               Dim sf As StackFrame = st.GetFrame(i)
               Console.WriteLine(" File: {0}", sf.GetFileName())
               Console.WriteLine(" Line Number: {0}", _
                  sf.GetFileLineNumber())
               Console.WriteLine(" Column Number: {0}", _
                  sf.GetFileColumnNumber())
            Next i
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'Level4Method 
'</snippet6>
   End Class 'ClassLevel4
  
   
   Public Class ClassLevel5
      
'<snippet8>
      Public Sub Level5Method()
         Try
            Dim nestedClass As New ClassLevel6()
            nestedClass.Level6Method()
         Catch e As Exception
            Console.WriteLine(" Level5Method exception handler")
            
            Dim st As New StackTrace()
            
            ' Display the most recent function call.
            Dim sf As StackFrame = st.GetFrame(0)
            Console.WriteLine()
            Console.WriteLine("  Exception in method: ")
            Console.WriteLine("      {0}", sf.GetMethod())
            
            If st.FrameCount > 1 Then
               ' Display the highest-level function call in the trace.
               sf = st.GetFrame((st.FrameCount - 1))
               Console.WriteLine("  Original function call at top of call stack):")
               Console.WriteLine("      {0}", sf.GetMethod())
            End If
            
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'Level5Method
'</snippet8>
   End Class 'ClassLevel5 
  
   
   Public Class ClassLevel6
      Public Sub Level6Method()
         Throw New Exception("An error occurred in the lowest internal class method.")
      End Sub 'Level6Method
   End Class 'ClassLevel6 

End Namespace 'StackFrameInternal
'</snippet1>