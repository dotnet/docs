' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim nFailed As Integer = 0
      Dim idnStd As New IdnMapping()
      idnStd.UseStd3AsciiRules = True
      
      Dim idnRelaxed As New IdnMapping
      idnRelaxed.UseStd3AsciiRules = False     ' The default, but make it explicit.
      
      For ctr As Integer = 0 To &h7F 
         Dim name As String = "Prose" + ChrW(ctr) + "ware.com"
         
         Dim stdFailed As Boolean = False
         Dim relaxedFailed As Boolean = False
         Dim punyCode As String
         Try
            punyCode = idnStd.GetAscii(name)
         Catch e As ArgumentException
            stdFailed = True
         End Try       
         
         Try
            punyCode = idnRelaxed.GetAscii(name)
         Catch e As ArgumentException
            relaxedFailed = True
         End Try       
         
         If relaxedFailed <> stdFailed Then
            Console.Write("U+{0:X4}     ", ctr)
            nFailed += 1
            If nFailed Mod 5 = 0 Then Console.WriteLine()         
         End If 
      Next   
   End Sub
End Module
' The example displays the following output:
'       U+0020     U+0021     U+0022     U+0023     U+0024
'       U+0025     U+0026     U+0027     U+0028     U+0029
'       U+002A     U+002B     U+002C     U+002F     U+003A
'       U+003B     U+003C     U+003D     U+003E     U+003F
'       U+0040     U+005B     U+005C     U+005D     U+005E
'       U+005F     U+0060     U+007B     U+007C     U+007D
'       U+007E
' </Snippet1>
