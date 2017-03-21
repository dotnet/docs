      Dim dateAndTime As DateTime = #07/06/2011 7:32:00AM#
      Dim temperature As Double = 68.3
      Dim result As String = String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                           dateAndTime, temperature)
      Console.WriteLine(result)
      ' The example displays the following output:
      '       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.      