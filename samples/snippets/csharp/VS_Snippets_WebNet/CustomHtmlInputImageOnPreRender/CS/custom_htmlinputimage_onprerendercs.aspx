<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load(Object sender, EventArgs e)
  {    
    
    // Define the onclick attribute of custom HtmlInputImage.
    HtmlInputImage1.Attributes.Add("onclick", "alert('Hello client-side world.');");
    
  }

  void HtmlInputImage1_ServerClick(Object sender, ImageClickEventArgs e)
  {
    
    // Set the inner HTML of the DIV element.
    Div1.InnerHtml = "Hello server-side world.";
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom HtmlInputImage - Method - C# Example</title>
    </head>
    <body>
        <form id="form1" runat="server">

            <h3>Custom HtmlInputImage - Method - C# Example</h3>
        
          <aspSample:CustomHtmlInputImageOnPreRender 
            id="HtmlInputImage1" 
        alt="image1.jpg"
            name="HtmlInputImage1"
            runat="server" 
            type="image" 
        src="image1.jpg"
        onserverclick="HtmlInputImage1_ServerClick" />
     
      <br />
      <br />

      <div 
        id="Div1" 
        runat="server" 
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px"/>
        
        </form>
    </body>
</html>
<!-- </Snippet1> -->
