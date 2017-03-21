      Dim numbers() As UInteger = { UInt32.MinValue, 121, 12345, UInt32.MaxValue }
      Dim result As Single
      
      For Each number As UInteger In numbers
         result = Convert.ToSingle(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next   
      ' The example displays the following output:
   '    Converted the UInt32 value '0' to the Single value 0.
   '    Converted the UInt32 value '121' to the Single value 121.
   '    Converted the UInt32 value '12345' to the Single value 12345.
   '    Converted the UInt32 value '4294967295' to the Single value 4.294967E+09.