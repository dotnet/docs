<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub UploadBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Specify the path on the server to
        ' save the uploaded file to.
        Dim savePath As String = "c:\temp\uploads\"
            
        ' Before attempting to save the file, verify
        ' that the FileUpload control contains a file.
        If (FileUpload1.HasFile) Then
            
            ' Get the name of the file to upload.
            Dim fileName As String = Server.HtmlEncode(FileUpload1.FileName)
            
            ' Get the extension of the uploaded file.
            Dim extension As String = System.IO.Path.GetExtension(fileName)
            
            ' Allow only files with .doc or .xls extensions
            ' to be uploaded.
            If (extension = ".doc") Or (extension = ".xls") Then
                        
                ' Append the name of the file to upload to the path.
                savePath += fileName
            
                ' Call the SaveAs method to save the 
                ' uploaded file to the specified path.
                ' This example does not perform all
                ' the necessary error checking.               
                ' If a file with the same name
                ' already exists in the specified path,  
                ' the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath)
                
                ' Notify the user that their file was successfully uploaded.
                UploadStatusLabel.Text = "Your file was uploaded successfully."
            
            Else
                ' Notify the user why their file was not uploaded.
                UploadStatusLabel.Text = "Your file was not uploaded because " + _
                                         "it does not have a .doc or .xls extension."
            End If
                
        Else
            ' Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload."
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FileUpload Class Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>Select a file to upload:</h4>
       
        <asp:FileUpload id="FileUpload1"                 
            runat="server">
        </asp:FileUpload>
            
        <br/><br/>
       
        <asp:Button id="UploadBtn" 
            Text="Upload file"
            OnClick="UploadBtn_Click"
            runat="server">
        </asp:Button>    
       
        <hr />
       
        <asp:Label id="UploadStatusLabel"
            runat="server">
        </asp:Label>     
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
