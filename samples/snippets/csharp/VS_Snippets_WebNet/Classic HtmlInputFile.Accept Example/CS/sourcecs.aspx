<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Button1_Click(object Source, EventArgs e)
    {

        // Check to see if a file was selected.
        if (Text1.Value == "")
        {
            Span1.InnerHtml = "Error: You must enter a file name.";
            return;
        }

        // Save the file.
        if (File1.PostedFile.ContentLength > 0)
        {
            try
            {
                try
                {
                    using (System.Drawing.Image input =
                        System.Drawing.Image.FromStream(File1.PostedFile.InputStream))
                    {
                        File1.PostedFile.SaveAs("c:\\temp\\" + 
                            Server.HtmlEncode(Text1.Value));
                        Span1.InnerHtml = "File uploaded successfully to <b>c:\\temp\\" +
                            Server.HtmlEncode(Text1.Value) + 
                            "</b> on the Web server.";
                    }
                }
                catch
                {
                    throw new Exception("Not a valid image file.");
                }
            }
            catch (Exception exc)
            {
                Span1.InnerHtml = "Error saving file <b>c:\\temp\\" +
                                   Server.HtmlEncode(Text1.Value) + 
                                   "</b>. " + exc.Message;
            }
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HmtlInputFile Example</title>
</head>
<body>
    <form id="Form1" enctype="multipart/form-data" 
          runat="server">
    <div>  
       Select File to Upload: 
       <input id="File1" 
              type="file"              
              accept="image/*"
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
