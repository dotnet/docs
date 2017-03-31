' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module ControlChar
   Public Sub Main()
      Dim sentence As String = "This is a " & vbCrLf & "two-line sentence."
      For ctr As Integer = 0 to sentence.Length - 1
         If Char.IsControl(sentence, ctr) Then
            Console.WriteLine("Control character \U{0} found in position {1}.", _
             Convert.ToInt32(sentence.Chars(ctr)).ToString("X4"), ctr)
          End If
       Next   
   End Sub
End Module
' The example displays the following output to the console:
'       Control character \U000D found in position 10.
'       Control character \U000A found in position 11.
' </Snippet2>
