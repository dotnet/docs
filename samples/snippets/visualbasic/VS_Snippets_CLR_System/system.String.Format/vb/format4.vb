' <Snippet4>
Public Module Example
   Public Sub Main()
      Dim formatString As String = "    {0,10} ({0,8:X8})" + vbCrLf +  _
                                   "And {1,10} ({1,8:X8})" + vbCrLf + _
                                   "  = {2,10} ({2,8:X8})"
      Dim value1 As Integer = 16932
      Dim value2 As Integer = 15421
      Dim result As String = String.Format(formatString, _
                                           value1, value2, value1 And value2)
      Console.WriteLine(result)                          
   End Sub
End Module
' The example displays the following output:
'                16932 (00004224)
'       And      15421 (00003C3D)
'         =         36 (00000024)
' </Snippet4>
