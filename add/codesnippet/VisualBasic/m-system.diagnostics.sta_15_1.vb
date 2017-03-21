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
            Next i 
            Console.WriteLine()
            Console.WriteLine("   ... throwing exception to next level ...")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Throw e
         End Try
      End Sub 'Level3Method