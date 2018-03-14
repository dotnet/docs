<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom HtmlSelect - AddParsedSubObject - VB.NET Example</title>
        <script runat="server">
      Sub HtmlInputButton1_ServerClick(sender As Object, e As EventArgs)
        If HtmlSelect1.SelectedIndex >= 0 Then
            If HtmlSelect1.Multiple = True Then
              Div1.InnerHtml = "You selected:"
              Dim i As Integer
              For i = 0 To HtmlSelect1.Items.Count - 1
                  If HtmlSelect1.Items(i).Selected = True Then
                    Div1.InnerHtml += "<br /> &nbsp;&nbsp; " & HtmlSelect1.Items(i).Value
                  End If
              Next i
            Else
              Div1.InnerHtml = "You selected " & HtmlSelect1.Value
            End If
        Else
            Div1.InnerHtml = "You did not select an item."
        End If
      End Sub
         </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom HtmlSelect - AddParsedSubObject - VB.NET Example</h3>
            
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
