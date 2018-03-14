' Visual Basic .NET Document
Option Strict On

' <Snippet5>
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

      ' Try to parse the strings in the array using the "B" format specifier.
      For Each stringGuid In stringGuids
         Dim newGuid As Guid
         If Guid.TryParseExact(stringGuid, "B", newGuid) Then
            Console.WriteLine("Successfully parsed {0}", stringGuid)
         Else
            Console.WriteLine("Unable to parse '{0}'", stringGuid)
         End If   
      Next      
   End Sub
End Module
' The example displays the following output:
'    Unable to parse 'c0fb150f6bf344df984a3a0611ae5e4a'
'    Unable to parse 'c0fb150f-6bf3-44df-984a-3a0611ae5e4a'
'    Successfully parsed {c0fb150f-6bf3-44df-984a-3a0611ae5e4a}
'    Unable to parse '(c0fb150f-6bf3-44df-984a-3a0611ae5e4a)'
'    Unable to parse '{0xc0fb150f,0x6bf3,0x44df,{0x98,0x4a,0x3a,0x06,0x11,0xae,0x5e,0x4a}}'
' </Snippet5>
