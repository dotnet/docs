<%-- <Snippet1> --%>
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Private saveDir As String = "Uploads\\"

    Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        
        If (FileUpload1.HasFile AndAlso FileUpload1.FileBytes.Length < 10000 AndAlso _
           Not (CheckForFileName())) Then
            Dim savePath As String = Request.PhysicalApplicationPath & saveDir & _
               Server.HtmlEncode(FileName.Text)
            'Remove comment from the next line to upload file.
            'FileUpload1.SaveAs(savePath)
            UploadStatusLabel.Text = "The file was processed successfully."
        Else
            UploadStatusLabel.Text = "You did not specify a file to upload, or a file name, or the file was too large. Please try again."
        End If
        
    End Sub

    Protected Sub CheckButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (FileName.Text.Length > 0) Then
            Dim s As String
            If (CheckForFileName()) Then
                s = "exists already."
            Else
                s = "does not exist."
            End If
            UploadStatusLabel.Text = "The file name choosen " & s
        Else
            UploadStatusLabel.Text = "Specify a file name to check."
        End If
    End Sub

    Private Function CheckForFileName() As Boolean
        Dim fi As New System.IO.FileInfo(Request.PhysicalApplicationPath & _
           saveDir & Server.HtmlEncode(FileName.Text))
        Return fi.Exists
    End Function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PostBackTrigger Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    The upload button is defined as a PostBackTrigger.<br/>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
    <fieldset>
    <legend>FileUpload in an UpdatePanel</legend>
       First, enter a file name to upload your file to: 
       <asp:TextBox ID="FileName" runat="server" />
       <asp:Button ID="CheckButton" Text="Check" runat="server" OnClick="CheckButton_Click" />
       <br />
       Then, browse and find the file to upload:
       <asp:FileUpload id="FileUpload1"                 
           runat="server">
       </asp:FileUpload>
       <br />
       <asp:Button id="UploadButton" 
           Text="Upload file"
           OnClick="UploadButton_Click"
           runat="server">
       </asp:Button>    
       <br />
       <asp:Label id="UploadStatusLabel"
           runat="server" style="color:red;">
       </asp:Label>           
    </fieldset>
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="UploadButton" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>
