' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim guid As Guid = Guid.NewGuid
      Console.WriteLine("Guid: {0}", guid)
      Dim bytes() As Byte = guid.ToByteArray
      For Each byt In bytes
         Console.Write("{0:X2} ", byt)
      Next
      Console.WriteLine()
      Dim guid2 As New Guid(bytes)
      Console.WriteLine("Guid: {0} (Same as First Guid: {1})", guid2, guid2.Equals(guid))
   End Sub
End Module
' The example displays the following output:
'    Guid: 35918bc9-196d-40ea-9779-889d79b753f0
'    C9 8B 91 35 6D 19 EA 40 97 79 88 9D 79 B7 53 F0
'    Guid: 35918bc9-196d-40ea-9779-889d79b753f0 (Same as First Guid: True)
' </Snippet1>

