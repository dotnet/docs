<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<script runat="server">
        
  Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            
    ' Specify the path on the server to
    ' save the uploaded file to.
    Dim savePath As String = "c:\temp\uploads\"
            
    ' Before attempting to perform operations
    ' on the file, verify that the FileUpload 
    ' control contains a file.
    If (FileUpload1.HasFile) Then
      ' Get the name of the file to upload.
      Dim fileName As String = FileUpload1.FileName
                      
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
                
      ' Notify the user of the name the file
      ' was saved under.
      UploadStatusLabel.Text = "Your file was saved as " & fileName
                
    Else
      ' Notify the user that a file was not uploaded.
      UploadStatusLabel.Text = "You did not specify a file to upload."
    End If

  End Sub
       
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FileUpload Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <h4>Select a file to upload:</h4>
   
       <asp:FileUpload id="FileUpload1"                 
           runat="server">
       </asp:FileUpload>
            
       <br /><br />
       
       <asp:Button id="UploadButton" 
           Text="Upload file"
           OnClick="UploadButton_Click"
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
<!--</Snippet1>-->