     Public Sub ConvertDoubleInt(ByVal doubleVal As Double)

         Dim intVal As Integer = 0
         ' Double to Integer conversion can overflow.
         Try
             intVal = System.Convert.ToInt32(doubleVal)
             System.Console.WriteLine("{0} as an Integer is: {1}", _
                                       doubleVal, intVal)
         Catch exception As System.OverflowException
             System.Console.WriteLine( _
                 "Overflow in Double-to-Byte conversion.")
         End Try

         ' Integer to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(intVal)
         System.Console.WriteLine("{0} as a Double is: {1}", _
                                   intVal, doubleVal)
     End Sub