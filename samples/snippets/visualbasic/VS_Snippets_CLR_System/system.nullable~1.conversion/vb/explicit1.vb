' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
       Dim nullInt = New Nullable(Of Integer)(172)
       ' Convert with CInt conversion method.
       Console.WriteLine(CInt(nullInt))
       ' Convert with CType conversion method.
       Console.WriteLine(CType(nullInt, Integer))
       ' Convert with Convert.ChangeType.
       Console.WriteLine(Convert.ChangeType(nullInt, GetType(Integer)))
   End Sub
End Module
' The example displays the following output:
'       172
'       172
'       172
' </Snippet1>
