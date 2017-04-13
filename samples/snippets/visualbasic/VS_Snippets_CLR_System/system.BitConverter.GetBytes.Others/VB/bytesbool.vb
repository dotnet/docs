'<Snippet1>
Module Example
   Public Sub Main()
      ' Define Boolean true and false values.
      Dim values() As Boolean = { true, false }

      ' Display the value and its corresponding byte array.
      Console.WriteLine("{0,10}{1,16}", "Boolean", "Bytes")
      Console.WriteLine()
      
      For Each value In values
         Dim bytes() As Byte = BitConverter.GetBytes(value) 
         Console.WriteLine("{0,10}{1,16}", value, 
                           BitConverter.ToString(bytes))
      Next
    End Sub 
End Module
' The example displays the following output:
'        Boolean           Bytes
'     
'           True              01
'          False              00
'</Snippet1>