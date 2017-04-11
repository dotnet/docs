<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Set the OnClick attribute of the custom HtmlInputImage control.
    HtmlInputImage1.Attributes.Add("onclick", "alert('Hello client-side world.');")

  End Sub

  Sub HtmlInputImage1_ServerClick(ByVal sender As Object, ByVal e As ImageClickEventArgs)

    ' Set the inner HTML of the div element.
    Div1.InnerHtml = "Hello server-side world."

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom HtmlInputImage - RenderAttributes - Visual Basic Example</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <h3>Custom HtmlInputImage - RenderAttributes - Visual Basic Example</h3>
        
          <aspSample:CustomHtmlInputImageRenderAttributes 
            id="HtmlInputImage1"
            name="HtmlInputImage1"
            runat="server" 
            type="image" 
                    src="Image1.jpg"
                    alt="Microsoft"
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
