      Dim values() As String = { "1603", "1,603", "one", "1.6e03", "1.2e-02", _
                                 "-1326", "1074122" }
      Dim result As UShort
      
      For Each value As String In values
         Try
            result = Convert.ToUInt16(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not in a recognizable format.", _
                              value.GetType().Name, value)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the UInt16 type.", value)
         End Try   
      Next
      ' The example displays the following output:
      '    Converted the String value '1603' to the UInt16 value 1603.
      '    The String value 1,603 is not in a recognizable format.
      '    The String value one is not in a recognizable format.
      '    The String value 1.6e03 is not in a recognizable format.
      '    The String value 1.2e-02 is not in a recognizable format.
      '    -1326 is outside the range of the UInt16 type.
      '    1074122 is outside the range of the UInt16 type.      