<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom HtmlSelect - AddParsedSubObject - C# Example</title>
        <script runat="server">
      void HtmlInputButton1_ServerClick(Object sender, EventArgs e) 
      {
        if (HtmlSelect1.SelectedIndex >= 0)
        {
          if (HtmlSelect1.Multiple == true)
          {
            Div1.InnerHtml = "You selected:";
            for (int i=0; i<=HtmlSelect1.Items.Count - 1; i++)
            {
              if (HtmlSelect1.Items[i].Selected == true)
              {
                Div1.InnerHtml += "<br /> &nbsp;&nbsp; " + HtmlSelect1.Items[i].Value; 
              }     
            }
          }
          else
          {
            Div1.InnerHtml = "You selected " + HtmlSelect1.Value;
          }
        }
        else
        {
          Div1.InnerHtml = "You did not select an item.";
        }
      }
         </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom HtmlSelect - AddParsedSubObject - C# Example</h3>
            
            <p>
      <aspSample:CustomHtmlSelectAddParsedSubObject 
        id="HtmlSelect1" 
        name="HtmlSelect1"
        runat="server">
        <option value="Option1">Option1</option>
        <option value="Option2">Option2</option>
        <option value="Option3">Option3</option>
      </aspSample:CustomHtmlSelectAddParsedSubObject>
      </p>
      
      <p>
      <input 
        id="HtmlInputButton1" 
        runat="server" 
        type="button" 
        onserverclick="HtmlInputButton1_ServerClick"
        value="Select" 
        name="HtmlInputButton1" />&nbsp;&nbsp;
      </p>
      
      <br />
      <div id="Div1" runat="server" 
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
       
        </form>
    </body>
</html>
<!-- </Snippet1> -->
