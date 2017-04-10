 ' <Snippet1>
Public Class StringSplit2
   Public Shared Sub Main()
      
      Dim delimStr As String = " ,.:"
      Dim delimiter As Char() = delimStr.ToCharArray()
      Dim words As String = "one two,three:four."
      Dim split As String() = Nothing
      
      Console.WriteLine("The delimiters are -{0}-", delimStr)
      Dim x As Integer
      For x = 1 To 5
         split = words.Split(delimiter, x)
         Console.WriteLine(ControlChars.Cr + "count = {0,2} ..............", x)
         Dim s As String
         For Each s In  split
            Console.WriteLine("-{0}-", s)
         Next s
      Next x
   End Sub 
End Class 
' The example displays the following output:
'       The delimiters are - ,.:-
'       count =  1 ..............
'       -one two,three:four.-
'       count =  2 ..............
'       -one-
'       -two,three:four.-
'       count =  3 ..............
'       -one-
'       -two-
'       -three:four.-
'       count =  4 ..............
'       -one-
'       -two-
'       -three-
'       -four.-
'       count =  5 ..............
'       -one-
'       -two-
'       -three-
'       -four-
'       --
' </Snippet1>
