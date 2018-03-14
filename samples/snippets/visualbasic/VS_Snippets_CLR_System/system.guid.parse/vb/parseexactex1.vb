' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      ' Define an array of all format specifiers.
      Dim formats() As String = { "N", "D", "B", "P", "X" }
      Dim guid As Guid = Guid.NewGuid()
      ' Create an array of valid Guid string representations.
      Dim stringGuids(formats.Length - 1) As String
      For ctr As Integer = 0 To formats.Length - 1
         stringGuids(ctr) = guid.ToString(formats(ctr))
      Next

      ' Parse the strings in the array using the "B" format specifier.
      For Each stringGuid In stringGuids
         Try
            Dim newGuid As Guid = Guid.ParseExact(stringGuid, "B")
            Console.WriteLine("Successfully parsed {0}", stringGuid)
         Catch e As ArgumentNullException
            Console.WriteLine("The string to be parsed is null.")
         Catch e As FormatException
            Console.WriteLine("Bad Format: {0}", stringGuid)
         End Try   
      Next      
   End Sub
End Module
' The example displays the following output:
'    Bad Format: 3351d3f0006747089ff928b5179b2051
'    Bad Format: 3351d3f0-0067-4708-9ff9-28b5179b2051
'    Successfully parsed {3351d3f0-0067-4708-9ff9-28b5179b2051}
'    Bad Format: (3351d3f0-0067-4708-9ff9-28b5179b2051)
'    Bad Format: {0x3351d3f0,0x0067,0x4708,{0x9f,0xf9,0x28,0xb5,0x17,0x9b,0x20,0x51}}
' </Snippet4>
