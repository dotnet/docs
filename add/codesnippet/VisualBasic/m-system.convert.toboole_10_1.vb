     Public Sub ConvertDoubleBool(ByVal doubleVal As Double)
         Dim boolVal As Boolean

         'Double to Boolean conversion cannot overflow.
         boolVal = System.Convert.ToBoolean(doubleVal)
         System.Console.WriteLine("{0} as a Boolean is: {1}.", _
                                   doubleVal, boolVal)

         'Boolean to Double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(boolVal)
         System.Console.WriteLine("{0} as a Double is: {1}.", _
                                   boolVal, doubleVal)
     End Sub