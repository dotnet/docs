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