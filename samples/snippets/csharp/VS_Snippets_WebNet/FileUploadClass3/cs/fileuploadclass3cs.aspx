<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        // Specify the path on the server to
        // save the uploaded file to.
        string savePath = @"c:\temp\uploads\";
                       
        // Before attempting to save the file, verify
        // that the FileUpload control contains a file.
        if (FileUpload1.HasFile)
        {                
            // Get the size in bytes of the file to upload.
            int fileSize = FileUpload1.PostedFile.ContentLength;
          
            // Allow only files less than 2,100,000 bytes (approximately 2 MB) to be uploaded.
            if (fileSize < 2100000)
            {
                        
                // Append the name of the uploaded file to the path.
                savePath += Server.HtmlEncode(FileUpload1.FileName);

                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath);
                
                // Notify the user that the file was uploaded successfully.
                UploadStatusLabel.Text = "Your file was uploaded successfully.";
            }
            else
            {
                // Notify the user why their file was not uploaded.
                UploadStatusLabel.Text = "Your file was not uploaded because " + 
                                         "it exceeds the 2 MB size limit.";
            }
        }   
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }
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
<!-- </Snippet1> -->