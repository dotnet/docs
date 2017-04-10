' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      ' Initialize array of characters from a to z.
      Dim chars(25) As Char 
      For ctr As Short = 0 To 25
         chars(ctr) = ChrW(ctr + &h0061)
      Next 
      Dim obj As Object = Activator.CreateInstance(GetType(String),
                                                   { chars, 13, 10 })
      Console.WriteLine(obj)                                          
   End Sub
End Module
' The example displays the following output:
'       nopqrstuvw
' </Snippet5>

