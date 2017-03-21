Module Example
   Public Sub Main()
      Dim c1 As Complex = New Complex(12.1, 15.4)
      Console.WriteLine("Formatting with ToString():       " + 
                        c1.ToString())
      Console.WriteLine("Formatting with ToString(format): " + 
                        c1.ToString("N2"))
      Console.WriteLine("Custom formatting with I0:        " + 
                        String.Format(New ComplexFormatter(), "{0:I0}", c1))
      Console.WriteLine("Custom formatting with J3:        " + 
                        String.Format(New ComplexFormatter(), "{0:J3}", c1))
   End Sub
End Module
' The example displays the following output:
'    Formatting with ToString():       (12.1, 15.4)
'    Formatting with ToString(format): (12.10, 15.40)
'    Custom formatting with I0:        12 + 15i
'    Custom formatting with J3:        12.100 + 15.400j