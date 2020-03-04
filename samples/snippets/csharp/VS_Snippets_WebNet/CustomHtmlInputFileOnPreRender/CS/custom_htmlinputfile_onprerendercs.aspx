<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button1_Click(object Source, EventArgs e)
  {
    // Make sure a file was submitted.
    if (HtmlInputText1.Value == "")
    {
      
      Span1.InnerHtml = "Error: You must enter a file name.";
      
    }
      
    // Save the file.
    else if (HtmlInputFile1.PostedFile != null)
    {  
      try
      {
        
        HtmlInputFile1.PostedFile.SaveAs("c:\\temp\\" + HtmlInputText1.Value);
        Span1.InnerHtml = "File uploaded successfully to: <b>c:\\temp\\" + 
                           HtmlInputText1.Value + "</b> on the Web server.";
               
      }
      catch (Exception exc)
      {
        
        Span1.InnerHtml = "Error saving <b>c:\\temp\\" +
                           HtmlInputText1.Value + "</b><br />" + exc.ToString() + ".";
        
      }
      
    }
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlInputFile OnPreRender Example</title>
  </head>
  <body>
    <form id="form1" enctype="multipart/form-data"
          runat="server">

      <h3>Custom HtmlInputFile OnPreRender Example</h3>
 
      Select File to Upload:
      <aspSample:CustomHtmlInputFileOnPreRender
        id="HtmlInputFile1"
        type="file"
        runat="server"
        name="HtmlInputFile1">

      <p>
      Save as file name (no path):
      <input id="HtmlInputText1"
        type="text"
        runat="server"
        name="Text1" />

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
        runat="server"
        name="Button1" />

      </p>

    </form>

  </body>
</html>
<!-- </Snippet1> -->
