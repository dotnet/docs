     Public Sub ConvertBoolean()
         Const year As Integer = 1979
         Const month As Integer = 7
         Const day As Integer = 28
         Const hour As Integer = 13
         Const minute As Integer = 26
         Const second As Integer = 15
         Const millisecond As Integer = 53

         Dim dateTime As New DateTime(year, month, day, hour, minute, _
                                      second, millisecond)

         Dim boolVal As Boolean

         ' System.InvalidCastException is always thrown.
         Try
             boolVal = System.Convert.ToBoolean(dateTime)
         Catch exception As System.InvalidCastException
             System.Console.WriteLine("Conversion from DateTime to " + _
                     "Boolean is not supported by the .NET Framework.")
         End Try
     End Sub