' <Snippet1>
Public Module Example
    Public Sub Main()
        Dim strSource() As String = { "<b>This is bold text</b>", 
                    "<H1>This is large Text</H1>", 
                    "<b><i><font color = green>This has multiple tags</font></i></b>", 
                    "<b>This has <i>embedded</i> tags.</b>", 
                    "This line simply ends with a greater than symbol, it should not be modified>" }

        Console.WriteLine("The following lists the items before the ends have been stripped:")
        Console.WriteLine("-----------------------------------------------------------------")

        ' Display the initial array of strings.
        For Each s As String In  strSource
            Console.WriteLine(s)
        Next
        Console.WriteLine()

        Console.WriteLine("The following lists the items after the ends have been stripped:")
        Console.WriteLine("----------------------------------------------------------------")

        ' Display the array of strings.
        For Each s As String In strSource
            Console.WriteLine(StripEndTags(s))
        Next 
    End Sub 

    Private Function StripEndTags(item As String) As String
        Dim found As Boolean = False
        
        ' Try to find a tag at the end of the line using EndsWith.
        If item.Trim().EndsWith(">") Then
            ' now search for the opening tag...
            Dim lastLocation As Integer = item.LastIndexOf("</")
            If lastLocation >= 0 Then
                found = True
                
                ' Remove the identified section, if it is a valid region.
                item = item.Substring(0, lastLocation)
            End If
        End If
        
        If found Then item = StripEndTags(item)
        Return item
    End Function 
End Module
' The example displays the following output:
'    The following lists the items before the ends have been stripped:
'    -----------------------------------------------------------------
'    <b>This is bold text</b>
'    <H1>This is large Text</H1>
'    <b><i><font color = green>This has multiple tags</font></i></b>
'    <b>This has <i>embedded</i> tags.</b>
'    This line simply ends with a greater than symbol, it should not be modified>
'    
'    The following lists the items after the ends have been stripped:
'    ----------------------------------------------------------------
'    <b>This is bold text
'    <H1>This is large Text
'    <b><i><font color = green>This has multiple tags
'    <b>This has <i>embedded</i> tags.
'    This line simply ends with a greater than symbol, it should not be modified>
' </Snippet1>
