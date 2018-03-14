' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module DelegateExample
   Public Sub Main()
      Dim title As String = "The House of the Seven Gables"
      Dim position As Integer = 0
      Dim finder As Func(Of String, Integer, Integer, StringComparison, Integer) _
                    = Function(s, pos, chars, type) _
                    title.IndexOf(s, pos, chars, type)
      Do
         Dim characters As Integer = title.Length - position
         position = finder("the", position, characters, _
                         StringComparison.InvariantCultureIgnoreCase) 
         If position >= 0 Then
            position += 1
            Console.WriteLine("'The' found at position {0} in {1}.", _
                              position, title)
         End If   
      Loop While position > 0   
   End Sub
End Module
' </Snippet4>
