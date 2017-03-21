            Dim strace As New StackTrace(1, True)
            Dim stFrames As StackFrame() = strace.GetFrames()

            Dim sf As StackFrame
            For Each sf In  stFrames
               Console.WriteLine("Method: {0}", sf.GetMethod())
            Next sf