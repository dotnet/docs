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