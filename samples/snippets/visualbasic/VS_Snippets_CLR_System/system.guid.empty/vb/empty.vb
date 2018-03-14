' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create a GUID and determine whether it consists of all zeros.
      Dim guid1 As Guid = Guid.NewGuid
      Console.WriteLine(guid1)
      Console.WriteLine("Empty: {0}", guid1 = Guid.Empty)
      Console.WriteLine()
      
      ' Create a GUID with all zeros and compare it to Empty.
      Dim bytes(15) As Byte
      Dim guid2 As New Guid(bytes)
      Console.WriteLine(guid2)
      Console.WriteLine("Empty: {0}", guid2 = Guid.Empty)
   End Sub
End Module
' The example displays output like the following:
'       11c43ee8-b9d3-4e51-b73f-bd9dda66e29c
'       Empty: False
'       
'       00000000-0000-0000-0000-000000000000
'       Empty: True
' </Snippet1>

