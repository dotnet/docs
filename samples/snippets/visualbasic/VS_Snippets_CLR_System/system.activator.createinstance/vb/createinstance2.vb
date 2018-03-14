' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim characters() As Char = { "a"c, "b"c, "c"c, "d"c, "e"c, "f"c }
      Dim arguments()() As Object = new Object(2)() { New Object() { characters },
                                                      New Object() { characters, 1, 4 },
                                                      New Object() { characters(1), 20 } }

      For ctr As Integer = 0 To arguments.GetUpperBound(0)
         Dim args() As Object = arguments(ctr)
         Dim result As Object = Activator.CreateInstance(GetType(String), args)
         Console.WriteLine("{0}: {1}", result.GetType().Name, result)
      Next
   End Sub
End Module
' The example displays the following output:
'       String: abcdef
'       String: bcde
'       String: bbbbbbbbbbbbbbbbbbbb
' </Snippet4>
