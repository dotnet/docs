      Dim numbers() As Single = { Single.MinValue, -1011.351, -17.45, -3e-16, _
                                  0, 4.56e-12, 16.0001, 10345.1221, Single.MaxValue }
      Dim result As String
      
      For Each number As Single In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next                            
      ' The example displays the following output:
      '    Converted the Single value -3.402823E+38 to the String value -3.402823E+38.
      '    Converted the Single value -1011.351 to the String value -1011.351.
      '    Converted the Single value -17.45 to the String value -17.45.
      '    Converted the Single value -3E-16 to the String value -3E-16.
      '    Converted the Single value 0 to the String value 0.
      '    Converted the Single value 4.56E-12 to the String value 4.56E-12.
      '    Converted the Single value 16.0001 to the String value 16.0001.
      '    Converted the Single value 10345.12 to the String value 10345.12.
      '    Converted the Single value 3.402823E+38 to the String value 3.402823E+38.