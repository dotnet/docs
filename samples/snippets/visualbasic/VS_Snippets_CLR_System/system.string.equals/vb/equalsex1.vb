Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Console.OutputEncoding = System.Text.Encoding.UTF8
      
      Dim word As String = "File"
      Dim others() As String = { word.ToLower(), word, word.ToUpper(), _
                                 "fıle" }
      For Each other As String In others
         If word.Equals(other) Then 
            Console.WriteLine("{0} = {1}", word, other)
         Else
            Console.WriteLine("{0} {1} {2}", word, ChrW(&H2260), other)
         End If      
      Next        
   End Sub
End Module
' The example displays the following output:
'       File ≠ file
'       File = File
'       File ≠ FILE
'       File ≠ fıle
' </Snippet2>

