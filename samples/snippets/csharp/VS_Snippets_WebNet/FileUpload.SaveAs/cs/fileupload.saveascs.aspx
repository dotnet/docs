<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FileUpload.SaveAs Method Example</title>
<script runat="server">
        
    protected void  UploadButton_Click(object sender, EventArgs e)
    {
        // Before attempting to save the file, verify
        // that the FileUpload control contains a file.
        if (FileUpload1.HasFile) 
          // Call a helper method routine to save the file.
          SaveFile(FileUpload1.PostedFile);
        else
          // Notify the user that a file was not uploaded.
          UploadStatusLabel.Text = "You did not specify a file to upload.";
    }
            
      void SaveFile(HttpPostedFile file)
      {            
        // Specify the path to save the uploaded file to.
        string savePath = "c:\\temp\\uploads\\";
            
        // Get the name of the file to upload.
        string fileName = FileUpload1.FileName;
            
        // Create the path and file name to check for duplicates.
        string pathToCheck = savePath + fileName;
        
        // Create a temporary file name to use for checking duplicates.
        string tempfileName = "";
            
        // Check to see if a file already exists with the
        // same name as the file to upload.        
        if (System.IO.File.Exists(pathToCheck)) 
        {
          int counter = 2;
          while (System.IO.File.Exists(pathToCheck))
          {
            // if a file with this name already exists,
            // prefix the filename with a number.
            tempfileName = counter.ToString() + fileName;
            pathToCheck = savePath + tempfileName;
            counter ++;
          }
          
          fileName = tempfileName;
          
          // Notify the user that the file name was changed.
          UploadStatusLabel.Text = "A file with the same name already exists." + 
              "<br />Your file was saved as " + fileName;
        }
        else
        {
          // Notify the user that the file was saved successfully.
          UploadStatusLabel.Text = "Your file was uploaded successfully.";
        }

        // Append the name of the file to upload to the path.
        savePath += fileName;
            
        // Call the SaveAs method to save the uploaded
        // file to the specified directory.
        FileUpload1.SaveAs(savePath);
            
      }
        
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