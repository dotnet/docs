      Dim interval As New TimeSpan(12, 30, 45)
      Dim output As String
      Try
         output = String.Format("{0:r}", interval)
      Catch e As FormatException
         output = "Invalid Format"
      End Try
      Console.WriteLine(output)
      ' Output from .NET Framework 3.5 and earlier versions:
      '       12:30:45
      ' Output from .NET Framework 4:
      '       Invalid Format