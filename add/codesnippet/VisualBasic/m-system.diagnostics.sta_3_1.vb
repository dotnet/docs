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