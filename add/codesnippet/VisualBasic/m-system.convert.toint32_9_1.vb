      Dim values() As Single = { Single.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Single.MaxValue }
      Dim result As Integer
      
      For Each value As Single In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int32 type.", value)
         End Try   
      Next                                 
      ' The example displays the following output:
      '    -3.40282346638529E+38 is outside the range of the Int32 type.
      '    -13799999488 is outside the range of the Int32 type.
      '    Converted the Double value -1023.29901123047 to the Int32 value -1023.
      '    Converted the Double value -12.9799995422363 to the Int32 value -13.
      '    Converted the Double value 0 to the Int32 value 0.
      '    Converted the Double value 9.11299983940444E-16 to the Int32 value 0.
      '    Converted the Double value 103.918998718262 to the Int32 value 104.
      '    Converted the Double value 17834.19140625 to the Int32 value 17834.
      '    3.40282346638529E+38 is outside the range of the Int32 type.