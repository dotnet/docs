' <Snippet1>            
Class Example
   Public Shared Sub Main()
      Dim value1 As UInt64 = 50
      Dim value2 As UInt64 = 50
      
      'Display the values.
      Console.WriteLine("value1:   Type: {0}   Value: {1}",
                        value1.GetType().Name, value1)
      Console.WriteLine("value2:   Type: {0}   Value: {1}",
                        value2.GetType().Name, value2)

      ' Compare the two values.
      Console.WriteLine("value1 and value2 are equal: {0}",
                        value1.Equals(value2))
   End Sub
End Class 
' The example displays the following output:
'       value1:   Type: UInt64   Value: 50
'       value2:   Type: UInt64   Value: 50
'       value1 and value2 are equal: True
' </Snippet1>            
