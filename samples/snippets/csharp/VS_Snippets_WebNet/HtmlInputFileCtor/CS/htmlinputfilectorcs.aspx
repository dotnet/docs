<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Button1_Click(object sender, EventArgs e)
  {

    // Get the HtmlInputFile control from the Controls collection 
    // of the PlaceHolder control.
    HtmlInputFile file = (HtmlInputFile)Place.FindControl("File1");

    // Make sure a file was submitted.
    if (Text1.Value == "")
    {
      Span1.InnerHtml = "Error: You must enter a file name.";
      return;
    }

    // Save the file.
    if (file.PostedFile.ContentLength > 0)
    {
      try
      {
        
        file.PostedFile.SaveAs("c:\\temp\\" + Text1.Value);
        Span1.InnerHtml = "File uploaded successfully to " +
           "<b>c:\\temp\\" + Text1.Value + "</b> on the Web server.";
        
      }
      catch (Exception exc)
      {
        
        Span1.InnerHtml = "Error saving file <b>c:\\temp\\" +
           Text1.Value + "</b><br />" + exc.ToString() + ".";
        
      }
    }
  }

  void Page_Load(object sender, EventArgs e)
  {

    // Create a new HtmlInputFile control.
    HtmlInputFile file = new HtmlInputFile();
    file.ID = "File1";

    // Add the control to the Controls collection of the
    // PlaceHolder control.
    Place.Controls.Clear();
    Place.Controls.Add(file);

  }
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HtmlInputFile Constructor Example</title>
  </head>

  <body>
 
   <h3>HtmlInputFile Constructor Example</h3>
 
   <form id="form1" enctype="multipart/form-data" 
         runat="server">
 
      Specify the file to upload:
      <asp:PlaceHolder id="Place" 
                       runat="server"/> 
 
      <p>
      Save as file name (no path): 
      <input id="Text1" 
             type="text" 
             runat="server" />
 
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

   </form>
 
</body>
</html>
<!-- </Snippet1> -->