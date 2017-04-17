' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim mainGuid As Guid = Guid.Parse("01e75c83-c6f5-4192-b57e-7427cec5560d")
      Dim guid2 As New Guid(&h01e75c83, 
                            BitConverter.ToInt16(new Byte() { &hf5, &hc6 }, 0), 
                            &h4192, 
                            new Byte() { &hb5, &h7e, &h74, &h27, &hce, &hc5, &h56, &h0c} )
      Dim guid3 As Guid = Guid.Parse("01e75c84-c6f5-4192-b57e-7427cec5560d")
      
      Console.WriteLine("{0} {1:F} {2}", mainGuid, 
                        CType(mainGuid.CompareTo(guid2), Comparison), guid2)
      Console.WriteLine("{0} {1:F} {2}", mainGuid, 
                        CType(mainGuid.CompareTo(guid3), Comparison), guid3)
   End Sub
   
   Private Enum Comparison As Integer
      LessThan = -1
      Equals = 0
      GreaterThan = 1
   End Enum
End Module
' The example displays the following output:
'    01e75c83-c6f5-4192-b57e-7427cec5560d GreaterThan 01e75c83-c6f5-4192-b57e-7427cec5560c
'    01e75c83-c6f5-4192-b57e-7427cec5560d LessThan 01e75c84-c6f5-4192-b57e-7427cec5560d
' </Snippet1>


