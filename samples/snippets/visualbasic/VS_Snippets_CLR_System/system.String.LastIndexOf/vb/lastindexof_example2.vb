' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim strSource As String() = { "<b>This is bold text</b>", _
                    "<H1>This is large Text</H1>", _
                    "<b><i><font color=green>This has multiple tags</font></i></b>", _
                    "<b>This has <i>embedded</i> tags.</b>", _
                    "This line ends with a greater than symbol and should not be modified>" }

      ' Strip HTML start and end tags from each string if they are present.
      For Each s As String In strSource
         Console.WriteLine("Before: " + s)
         ' Use EndsWith to find a tag at the end of the line.
         If s.Trim().EndsWith(">") Then 
            ' Locate the opening tag.
            Dim endTagStartPosition As Integer = s.LastIndexOf("</")
            ' Remove the identified section if it is valid.
            If endTagStartPosition >= 0 Then
               s = s.Substring(0, endTagStartPosition)
            End If
            
            ' Use StartsWith to find the opening tag.
            If s.Trim().StartsWith("<") Then
               ' Locate the end of opening tab.
               Dim openTagEndPosition As Integer = s.IndexOf(">")
               ' Remove the identified section if it is valid.
               If openTagEndPosition >= 0 Then
                  s = s.Substring(openTagEndPosition + 1)
               End If   
            End If      
         End If
         ' Display the trimmed string.
         Console.WriteLine("After: " + s)
         Console.WriteLine()
      Next                   
   End Sub
End Module
' The example displays the following output:
'    Before: <b>This is bold text</b>
'    After: This is bold text
'    
'    Before: <H1>This is large Text</H1>
'    After: This is large Text
'    
'    Before: <b><i><font color=green>This has multiple tags</font></i></b>
'    After: <i><font color=green>This has multiple tags</font></i>
'    
'    Before: <b>This has <i>embedded</i> tags.</b>
'    After: This has <i>embedded</i> tags.
'    
'    Before: This line ends with a greater than symbol and should not be modified>
'    After: This line ends with a greater than symbol and should not be modified>
' </Snippet2>