'<snippet1>
Class Sample
   Public Shared Sub Main()
      Dim val As [String]() =  {"apple", "orange", "grape", "pear"}
      Dim sep As [String] = ", "
      Dim result As [String]
      
      Console.WriteLine("sep = '{0}'", sep)
      Console.WriteLine("val() = {{'{0}' '{1}' '{2}' '{3}'}}", val(0), val(1), val(2), val(3))
      result = [String].Join(sep, val, 1, 2)
      Console.WriteLine("String.Join(sep, val, 1, 2) = '{0}'", result)
   End Sub
End Class 
'This example displays the following output:
'       sep = ', '
'       val() = {'apple' 'orange' 'grape' 'pear'}
'       String.Join(sep, val, 1, 2) = 'orange, grape'
'</snippet1>