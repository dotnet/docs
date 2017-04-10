' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Try
         ' Outer block to handle any unexpected exceptions.
         Try
            Dim s As String = "This"
            s = s.Insert(2, "is ")

            ' Throw an OutOfMemoryException exception.
            Throw New OutOfMemoryException()
         Catch e As ArgumentException
            Console.WriteLine("ArgumentException in String.Insert")
         End Try
         
         ' Execute program logic.

      Catch e As OutOfMemoryException
         Console.WriteLine("Terminating application unexpectedly...")
         Environment.FailFast(String.Format("Out of Memory: {0}",
                                            e.Message))
      End Try
   End Sub
End Module
' The example displays the following output:
'       Terminating application unexpectedly...
' </Snippet2>
