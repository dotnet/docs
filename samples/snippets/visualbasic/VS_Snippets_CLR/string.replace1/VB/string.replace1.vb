 '<snippet1>
Class stringReplace1
   Public Shared Sub Main()
      Dim str As [String] = "1 2 3 4 5 6 7 8 9"
      Console.WriteLine("Original string: ""{0}""", str)
      Console.WriteLine("CSV string:      ""{0}""", str.Replace(" "c, ","c))
   End Sub
End Class
' This example produces the following output:
' Original string: "1 2 3 4 5 6 7 8 9"
' CSV string:      "1,2,3,4,5,6,7,8,9"
'</snippet1>