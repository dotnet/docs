'<snippet1>
Public Class Example
   Public Shared Sub Main()
      Dim strSource() As String = { "<b>This is bold text</b>", 
                         "<H1>This is large Text</H1>", 
                         "<b><i><font color = green>This has multiple tags</font></i></b>", 
                         "<b>This has <i>embedded</i> tags.</b>", 
                         "<This line simply begins with a lesser than symbol, it should not be modified" }

      ' Display the initial string array.
      Console.WriteLine("The original strings:")
      Console.WriteLine("---------------------")
      For Each s In strSource
         Console.WriteLine(s)
      Next 
      Console.WriteLine()

      Console.WriteLine("Strings after starting tags have been stripped:")
      Console.WriteLine("-----------------------------------------------") 

      ' Display the strings with starting tags removed.
      For Each s In strSource
         Console.WriteLine(StripStartTags(s))
      Next 
   End Sub 

   Private Shared Function StripStartTags(item As String) As String
      ' Determine whether a tag begins the string.
      If item.Trim().StartsWith("<") Then
         ' Find the closing tag.
         Dim lastLocation As Integer = item.IndexOf(">")
         If lastLocation >= 0 Then
            ' Remove the tag.
            item = item.Substring((lastLocation + 1))
            
            ' Remove any additional starting tags.
            item = StripStartTags(item)
         End If
      End If
      
      Return item
   End Function 
End Class 
' The example displays the following output:
'    The original strings:
'    ---------------------
'    <b>This is bold text</b>
'    <H1>This is large Text</H1>
'    <b><i><font color = green>This has multiple tags</font></i></b>
'    <b>This has <i>embedded</i> tags.</b>
'    <This line simply begins with a lesser than symbol, it should not be modified
'    
'    Strings after starting tags have been stripped:
'    -----------------------------------------------
'    This is bold text</b>
'    This is large Text</H1>
'    This has multiple tags</font></i></b>
'    This has <i>embedded</i> tags.</b>
'    <This line simply begins with a lesser than symbol, it should not be modified
'</snippet1>