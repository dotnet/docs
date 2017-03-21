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