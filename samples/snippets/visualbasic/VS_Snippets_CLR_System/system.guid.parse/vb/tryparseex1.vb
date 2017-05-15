' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim originalGuid As Guid = Guid.NewGuid()
      ' Create an array of string representations of the GUID.
      Dim stringGuids() As String = { originalGuid.ToString("B"),
                                      originalGuid.ToString("D"),
                                      originalGuid.ToString("X") }
      
      ' Parse each string representation.
      Dim newGuid As Guid
      For Each stringGuid In stringGuids
         If Guid.TryParse(stringGuid, newGuid) Then
            Console.WriteLine("Converted {0} to a Guid", stringGuid)
         Else
            Console.WriteLine("Unable to convert {0} to a Guid", 
                              stringGuid)
         End If     
      Next                                      
   End Sub
End Module
' The example displays the following output:
'    Converted {81a130d2-502f-4cf1-a376-63edeb000e9f} to a Guid
'    Converted 81a130d2-502f-4cf1-a376-63edeb000e9f to a Guid
'    Converted {0x81a130d2,0x502f,0x4cf1,{0xa3,0x76,0x63,0xed,0xeb,0x00,0x0e,0x9f}} to a Guid
' </Snippet2>
