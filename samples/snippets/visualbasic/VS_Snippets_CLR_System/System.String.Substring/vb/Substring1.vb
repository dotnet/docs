' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim pairs() As String = { "Color1=red", "Color2=green", "Color3=blue",
                                "Title=Code Repository" }
      For Each pair In pairs
         Dim position As Integer = pair.IndexOf("=")
         If position < 0 then Continue For
         Console.WriteLine("Key: {0}, Value: '{1}'", 
                           pair.Substring(0, position),
                           pair.Substring(position + 1))
      Next                          
   End Sub
End Module
' The example displays the following output:
'     Key: Color1, Value: 'red'
'     Key: Color2, Value: 'green'
'     Key: Color3, Value: 'blue'
'     Key: Title, Value: 'Code Repository'
' </Snippet1>
