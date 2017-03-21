      Dim values() As Single = { Single.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Single.MaxValue }
      Dim result As ULong
      
      For Each value As Single In values
         Try
            result = Convert.ToUInt64(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.", _
                              value.GetType().Name, value)
         End Try   
      Next                                 
      ' The example displays the following output:
   '    The Single value -3.402823E+38 is outside the range of the UInt64 type.
   '    The Single value -1.38E+10 is outside the range of the UInt64 type.
   '    The Single value -1023.299 is outside the range of the UInt64 type.
   '    The Single value -12.98 is outside the range of the UInt64 type.
   '    Converted the Single value 0 to the UInt64 value 0.
   '    Converted the Single value 9.113E-16 to the UInt64 value 0.
   '    Converted the Single value 103.919 to the UInt64 value 104.
   '    Converted the Single value 17834.19 to the UInt64 value 17834.
   '    The Single value 3.402823E+38 is outside the range of the UInt64 type.