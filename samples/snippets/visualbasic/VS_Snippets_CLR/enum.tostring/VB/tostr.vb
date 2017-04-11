'<snippet1>
' Sample for Enum.ToString(String)
Imports System

Class Sample
   Enum Colors
      Red
      Green
      Blue
      Yellow = 12
   End Enum 'Colors
   
   Public Shared Sub Main()
      Dim myColor As Colors = Colors.Yellow
      
      Console.WriteLine("Colors.Red = {0}", Colors.Red.ToString("d"))
      Console.WriteLine("Colors.Green = {0}", Colors.Green.ToString("d"))
      Console.WriteLine("Colors.Blue = {0}", Colors.Blue.ToString("d"))
      Console.WriteLine("Colors.Yellow = {0}", Colors.Yellow.ToString("d"))
      
      Console.WriteLine("{0}myColor = Colors.Yellow{0}", Environment.NewLine)
      
      Console.WriteLine("myColor.ToString(""g"") = {0}", myColor.ToString("g"))
      Console.WriteLine("myColor.ToString(""G"") = {0}", myColor.ToString("G"))
      
      Console.WriteLine("myColor.ToString(""x"") = {0}", myColor.ToString("x"))
      Console.WriteLine("myColor.ToString(""X"") = {0}", myColor.ToString("X"))
      
      Console.WriteLine("myColor.ToString(""d"") = {0}", myColor.ToString("d"))
      Console.WriteLine("myColor.ToString(""D"") = {0}", myColor.ToString("D"))
      
      Console.WriteLine("myColor.ToString(""f"") = {0}", myColor.ToString("f"))
      Console.WriteLine("myColor.ToString(""F"") = {0}", myColor.ToString("F"))
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Colors.Red = 0
'Colors.Green = 1
'Colors.Blue = 2
'Colors.Yellow = 12
'
'myColor = Colors.Yellow
'
'myColor.ToString("g") = Yellow
'myColor.ToString("G") = Yellow
'myColor.ToString("x") = 0000000C
'myColor.ToString("X") = 0000000C
'myColor.ToString("d") = 12
'myColor.ToString("D") = 12
'myColor.ToString("f") = Yellow
'myColor.ToString("F") = Yellow
'
'</snippet1>