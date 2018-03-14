' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim guidStrings() As String = { "ca761232ed4211cebacd00aa0057b223",
                                      "CA761232-ED42-11CE-BACD-00AA0057B223", 
                                      "{CA761232-ED42-11CE-BACD-00AA0057B223}", 
                                      "(CA761232-ED42-11CE-BACD-00AA0057B223)", 
                                      "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}" }
      For Each guidString In guidStrings
         Dim guid As New Guid(guidString)
         Console.WriteLine("Original string: {0}", guidString)
         Console.WriteLine("Guid:            {0}", guid)
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    Original string: ca761232ed4211cebacd00aa0057b223
'    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
'    
'    Original string: CA761232-ED42-11CE-BACD-00AA0057B223
'    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
'    
'    Original string: {CA761232-ED42-11CE-BACD-00AA0057B223}
'    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
'    
'    Original string: (CA761232-ED42-11CE-BACD-00AA0057B223)
'    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
'    
'    Original string: {0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}
'    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
' </Snippet1>

