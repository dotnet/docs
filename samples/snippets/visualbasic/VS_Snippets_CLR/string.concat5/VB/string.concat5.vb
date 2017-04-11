 '<snippet1>
Class stringConcat5
   Public Shared Sub Main()
      Dim i As Integer = - 123
      Dim o As [Object] = i
      Dim objs() As [Object] = {-123, -456, -789}
      
      Console.WriteLine("Concatenate 1, 2, and 3 objects:")
      Console.WriteLine("1) {0}", [String].Concat(o))
      Console.WriteLine("2) {0}", [String].Concat(o, o))
      Console.WriteLine("3) {0}", [String].Concat(o, o, o))
      
      Console.WriteLine(vbCrLf & "Concatenate 4 objects and a variable length parameter list:")
      Console.WriteLine("4) {0}", String.Concat(o, o, o, o))
      Console.WriteLine("5) {0}", String.Concat(o, o, o, o, o))
      
      Console.WriteLine(vbCrLf & "Concatenate a 3-element object array:")
      Console.WriteLine("6) {0}", [String].Concat(objs))
   End Sub
End Class
'The example displays the following output:
'    Concatenate 1, 2, and 3 objects:
'    1) -123
'    2) -123-123
'    3) -123-123-123
'    
'    Concatenate 4 objects and a variable length parameter list:
'    4) -123-123-123-123
'    5) -123-123-123-123-123
'         
'    Concatenate a 3-element object array:
'    6) -123-456-789
'</snippet1>