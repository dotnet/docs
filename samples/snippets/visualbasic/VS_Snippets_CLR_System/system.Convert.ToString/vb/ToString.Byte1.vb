' <Snippet3> 
Public Module Example
   Public Sub Main()
      Dim values() As Byte = { Byte.MinValue, 12, 100, 179, Byte.MaxValue }

      For Each value In values
         Console.WriteLine("{0,3} ({1}) --> {2}", value, 
                           value.GetType().Name, 
                           Convert.ToString(value))
      Next                           
   End Sub
End Module
' The example displays the following output:
'       0 (Byte) --> 0
'      12 (Byte) --> 12
'     100 (Byte) --> 100
'     179 (Byte) --> 179
'     255 (Byte) --> 255
' </Snippet3> 
