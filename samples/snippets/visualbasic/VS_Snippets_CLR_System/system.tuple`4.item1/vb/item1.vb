' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim temperatures() = 
             { Tuple.Create("New York, NY", 4, 61, 43), _
               Tuple.Create("Chicago, IL", 2, 34, 18), _ 
               Tuple.Create("Newark, NJ", 4, 61, 43), _
               Tuple.Create("Boston, MA", 6, 77, 59), _
               Tuple.Create("Detroit, MI", 9, 74, 53), _
               Tuple.Create("Minneapolis, MN", 8, 81, 61) } 
      ' Display the array of 4-tuples.
      Console.WriteLine("{0,41}", "Temperatures")
      Console.WriteLine("{0,-20} {1,5}    {2,4}  {3,4}", 
                        "City", "Month", "High", "Low")
      Console.WriteLine()
      For Each temperature In temperatures
         Console.WriteLine("{0,-20} {1,5}    {2,4:N1}  {3,4:N1}", 
                           temperature.Item1, 
                           DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(temperature.Item2 - 1), 
                           temperature.Item3, temperature.Item4)
      Next
   End Sub
End Module
' The example displays the following output:
'                                    Temperatures
'       City                 Month    High   Low
'       
'       New York, NY           Mar    61.0  43.0
'       Chicago, IL            Jan    34.0  18.0
'       Newark, NJ             Mar    61.0  43.0
'       Boston, MA             May    77.0  59.0
'       Detroit, MI            Aug    74.0  53.0
'       Minneapolis, MN        Jul    81.0  61.0
' </Snippet1>
