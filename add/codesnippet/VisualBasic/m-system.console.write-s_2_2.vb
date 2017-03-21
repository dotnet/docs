Public Class FormatConverter
   Public Shared Sub Main()
      Dim lineInput As String
      lineInput = Console.ReadLine()
      While Not lineInput Is Nothing
         Dim fields() As String = lineInput.Split(ControlChars.Tab)
         Dim isFirstField As Boolean = True
         Dim item As String
         For Each item In  fields
            If isFirstField Then
               isFirstField = False
            Else
               Console.Write(",")
            End If
            ' If the field represents a boolean, replace with a numeric representation.
            Try
               Console.Write(Convert.ToByte(Convert.ToBoolean(item)))
            Catch
               Console.Write(item)
            End Try
         Next item
         Console.WriteLine()
         lineInput = Console.ReadLine()
      End While
   End Sub 'Main
End Class 'FormatConverter