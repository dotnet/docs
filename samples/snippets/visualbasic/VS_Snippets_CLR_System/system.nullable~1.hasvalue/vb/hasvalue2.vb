' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim n1 As New Nullable(Of Integer)(10)
      Dim n2 As Nullable(Of Integer)
      Dim n3 As New Nullable(Of Integer)(20)
      n3 = Nothing
      Dim items() As Nullable(Of Integer) = { n1, n2, n3 }

      For Each item In items
         Console.WriteLine("Has a value: {0}", item.HasValue)
         If item.HasValue Then
            Console.WriteLine("Type: {0}", item.GetType().Name)
            Console.WriteLine("Value: {0}", item.Value)
         Else
            Console.WriteLine("Null: {0}", item Is Nothing)
            Console.WriteLine("Default Value: {0}", item.GetValueOrDefault())
         End If
         Console.WriteLine()
      Next                  
   End Sub
End Module
' The example displays the following output:
'       Has a value: True
'       Type: Int32
'       Value: 10
'       
'       Has a value: False
'       Null: True
'       Default Value: 0
'       
'       Has a value: False
'       Null: True
'       Default Value: 0
' </Snippet1>
