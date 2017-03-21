     Public Sub CovertDoubleFloat(ByVal doubleVal As Double)
         Dim singleVal As Single = 0

         ' Double to Single conversion cannot overflow.
             singleVal = System.Convert.ToSingle(doubleVal)
             System.Console.WriteLine("{0} as a Single is {1}", _
                                       doubleVal, singleVal)

         ' Conversion from Single to Double cannot overflow.
         doubleVal = System.Convert.ToDouble(singleVal)
         System.Console.WriteLine("{0} as a Double is: {1}", _
                                   singleVal, doubleVal)
     End Sub