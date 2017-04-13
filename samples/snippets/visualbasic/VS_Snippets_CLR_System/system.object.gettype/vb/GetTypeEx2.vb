' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim values() As Object = { 12, CLng(10653), CByte(12), 
                                 CSbyte(-5), 16.3, "string" } 
      For Each value In values
         Dim t AS Type = value.GetType()
         If t.Equals(GetType(Byte))
            Console.WriteLine("{0} is an unsigned byte.", value)
         ElseIf t.Equals(GetType(SByte))
            Console.WriteLine("{0} is a signed byte.", value)
         ElseIf t.Equals(GetType(Integer))   
            Console.WriteLine("{0} is a 32-bit integer.", value)
         ElseIf t.Equals(GetType(Long))   
            Console.WriteLine("{0} is a 32-bit integer.", value)
         ElseIf t.Equals(GetType(Double))
            Console.WriteLine("{0} is a double-precision floating point.", 
                              value)
         Else
            Console.WriteLine("'{0}' is another data type.", value)
         End If   
      Next      
   End Sub
End Module
' The example displays the following output:
'       12 is a 32-bit integer.
'       10653 is a 32-bit integer.
'       12 is an unsigned byte.
'       -5 is a signed byte.
'       16.3 is a double-precision floating point.
'       'string' is another data type.
' </Snippet2>
