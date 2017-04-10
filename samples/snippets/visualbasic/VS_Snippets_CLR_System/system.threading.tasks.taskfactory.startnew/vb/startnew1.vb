' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading.Tasks

Public Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim tasks As New List(Of Task)
      ' Execute the task 10 times.
      For ctr As Integer = 1 To 9
         tasks.Add(Task.Factory.StartNew(Sub()
                                            Dim utf32 As Integer
                                            SyncLock(rnd)
                                               ' Get UTF32 value.
                                               utf32 = rnd.Next(0, &hE01F0)
                                            End SyncLock
                                            ' Convert it to a UTF16-encoded character.
                                            Dim utf16 As String = Char.ConvertFromUtf32(utf32)
                                            ' Display information about the character.
                                            Console.WriteLine("0x{0:X8} --> '{1,2}' ({2})", 
                                                              utf32, utf16, ShowHex(utf16))
                                         End Sub))                           
      Next
      Task.WaitAll(tasks.ToArray()) 
   End Sub
   
   Private Function ShowHex(value As String) As String
      Dim hexString As String = Nothing
      ' Handle only non-control characters.
      If Not Char.IsControl(value, 0) Then
         For Each ch In value
            hexString += String.Format("0x{0} ", Convert.ToUInt16(ch))
         Next
      End If   
      Return hexString.Trim()
   End Function
End Module
' The example displays output similar to the following:
'       0x00097103 --> 'Ì®úÌ¥É' (0x55836 0x56579)
'       0x000A98A1 --> 'Ì©¶Ì≤°' (0x55910 0x56481)
'       0x00050002 --> 'Ì§ÄÌ∞Ç' (0x55552 0x56322)
'       0x0000FEF1 --> ' Ôª±' (0x65265)
'       0x0008BC0A --> 'ÌßØÌ∞ä' (0x55791 0x56330)
'       0x000860EA --> 'ÌßòÌ≥™' (0x55768 0x56554)
'       0x0009AC5A --> 'Ì®´Ì±ö' (0x55851 0x56410)
'       0x00053320 --> 'Ì§åÌº†' (0x55564 0x57120)
'       0x000874EF --> 'ÌßùÌ≥Ø' (0x55773 0x56559)
' </Snippet1>
