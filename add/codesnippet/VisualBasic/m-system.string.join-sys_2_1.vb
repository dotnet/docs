   Dim values() As Object = { Nothing, "Cobb", 4189, 11434, .366 }
   If values(0) Is Nothing Then values(0) = String.Empty
   Console.WriteLine(String.Join("|", values))
   ' The example displays the following output:
   '      |Cobb|4189|11434|0.366