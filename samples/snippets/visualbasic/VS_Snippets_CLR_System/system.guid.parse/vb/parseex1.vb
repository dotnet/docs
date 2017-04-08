' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim originalGuid As Guid = Guid.NewGuid()
      ' Create an array of string representations of the GUID.
      Dim stringGuids() As String = { originalGuid.ToString("B"),
                                      originalGuid.ToString("D"),
                                      originalGuid.ToString("X") }
      
      ' Parse each string representation.
      For Each stringGuid In stringGuids
         Try 
            Dim newGuid As Guid = Guid.Parse(stringGuid) 
            Console.WriteLine("Converted {0} to a Guid", stringGuid)
         Catch e As ArgumentNullException
            Console.WriteLine("The string to be parsed is null.")   
         Catch e As FormatException
            Console.WriteLine("Bad format: {0}", stringGuid)
         End Try     
      Next                                      
   End Sub
End Module
' The example displays the following output:
'    Converted {81a130d2-502f-4cf1-a376-63edeb000e9f} to a Guid
'    Converted 81a130d2-502f-4cf1-a376-63edeb000e9f to a Guid
'    Converted {0x81a130d2,0x502f,0x4cf1,{0xa3,0x76,0x63,0xed,0xeb,0x00,0x0e,0x9f}} to a Guid
' </Snippet3>
