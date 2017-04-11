' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim g As New Guid(&hA, &hB, &hC, 
                        New Byte() { 0, 1, 2, 3, 4, 5, 6, 7 } )
      Console.WriteLine("{0:B}", g)
   End Sub
End Module
' The example displays the following output:
'   {0000000a-000b-000c-0001-020304050607}
' </Snippet2>
