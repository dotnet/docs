<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FileUpload.SaveAs Method Example</title>
<script runat="server">
        
      Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            
        ' Before attempting to save the file, verify
        ' that the FileUpload control contains a file.
        If (FileUpload1.HasFile) Then
          ' Call a helper method routine to save the file.
          SaveFile(FileUpload1.PostedFile)
        Else
          ' Notify the user that a file was not uploaded.
          UploadStatusLabel.Text = "You did not specify a file to upload."
        End If

      End Sub
        
      Sub SaveFile(ByVal file As HttpPostedFile)
            
        ' Specify the path to save the uploaded file to.
        Dim savePath As String = "c:\temp\uploads\"
            
        ' Get the name of the file to upload.
        Dim fileName As String = FileUpload1.FileName
            
        ' Create the path and file name to check for duplicates.
        Dim pathToCheck As String = savePath + fileName
        
        ' Create a temporary file name to use for checking duplicates.
        Dim tempfileName As String
            
        ' Check to see if a file already exists with the
        ' same name as the file to upload.        
        If (System.IO.File.Exists(pathToCheck)) Then
          Dim counter As Integer = 2
          While (System.IO.File.Exists(pathToCheck))
            ' If a file with this name already exists,
            ' prefix the filename with a number.
            tempfileName = counter.ToString() + fileName
            pathToCheck = savePath + tempfileName
            counter = counter + 1
          End While
          
          fileName = tempfileName
          
          ' Notify the user that the file name was changed.
          UploadStatusLabel.Text = "A file with the same name already exists." + "<br />" + _
                                   "Your file was saved as " + fileName
          
        Else
          
          ' Notify the user that the file was saved successfully.
          UploadStatusLabel.Text = "Your file was uploaded successfully."
          
        End If

        ' Append the name of the file to upload to the path.
        savePath += fileName
            
        ' Call the SaveAs method to save the uploaded
        ' file to the specified directory.
        FileUpload1.SaveAs(savePath)
            
      End Sub
        
  </script>

</head>
<body>

    <h3>FileUpload.SaveAs Method Example</h3>

    <form id="Form1" runat="server">
   
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
         
    </form>

</body>
</html>
<!--</Snippet1>-->