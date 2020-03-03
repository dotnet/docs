<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Check to see if a file was selected.
        If (Text1.Value = "") Then
            Span1.InnerHtml = "Error: You must enter a file name."
            Return
        End If
        
        ' Save the file
        If (File1.PostedFile.ContentLength > 0) Then
            Try
                Try
                    Using input As System.Drawing.Image = _
                       System.Drawing.Image.FromStream(File1.PostedFile.InputStream)
                        File1.PostedFile.SaveAs("c:\\temp\\" & _
                            Server.HtmlEncode(Text1.Value))
                        Span1.InnerHtml = "File uploaded successfully to <b>c:\\temp\\" & _
                            Server.HtmlEncode(Text1.Value) & _
                            "</b> on the Web server."
                        
                    End Using
                Catch
                    Throw New Exception("Not a valid image file.")
                End Try
            Catch exc As Exception
                Span1.InnerHtml = "Error saving file <b>c:\\temp\\" & _
                                   Server.HtmlEncode(Text1.Value) & _
                                   "</b>. " & exc.Message
            End Try
        End If
        
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlInputFile Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       Select File to Upload: 
       <input id="File1" 
              type="file"              
              accept="image/jpeg"
              runat="server"/>
       <p>
       Save as file name (no path): 
       <input id="Text1" 
              type="text" 
              runat="server"/>
       </p>
       <p>
       <span id="Span1" 
             style="font: 8pt verdana;" 
             runat="server" />
 
       </p>
       <p>
       <input type="button" 
              id="Button1" 
              value="Upload" 
              onserverclick="Button1_Click" 
              runat="server" />
       </p>    
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
