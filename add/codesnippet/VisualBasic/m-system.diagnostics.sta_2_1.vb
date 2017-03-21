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