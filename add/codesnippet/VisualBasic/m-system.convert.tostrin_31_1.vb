     Public Sub ConvertDoubleString(ByVal doubleVal As Double)

         Dim stringVal As String

         ' A conversion from Double to String cannot overflow.       
         stringVal = System.Convert.ToString(doubleVal)
         System.Console.WriteLine("{0} as a String is: {1}", _
                                   doubleVal, stringVal)

         Try
             doubleVal = System.Convert.ToDouble(stringVal)
             System.Console.WriteLine("{0} as a Double is: {1}", _
                                       stringVal, doubleVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in String-to-Double conversion.")
         Catch exception As System.FormatException
             System.Console.WriteLine( _
                 "The string is not formatted as a Double.")
         Catch exception As System.ArgumentException
             System.Console.WriteLine("The string is null.")
         End Try

     End Sub