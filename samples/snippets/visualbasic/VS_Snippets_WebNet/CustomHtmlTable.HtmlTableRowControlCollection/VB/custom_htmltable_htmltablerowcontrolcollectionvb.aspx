<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlTable - CustomHtmlTableRowControlCollection Example</title>
  </head>
  <body>
    <form id="Form1" 
          method="post" 
          runat="server">
      <h3>Custom HtmlTable - CustomHtmlTableRowControlCollection Example</h3>
      
      <aspSample:CustomHtmlTableRowControlCollection 
        id="HtmlTable1" 
        name="HtmlTable1" 
        runat="server" 
        border="1"
        cellSpacing="0" 
        cellPadding="5">
        <tr>
          <td>1,1</td>
          <td>1,2</td>
          <td>1,3</td>
        </tr>
        <tr>
          <td>2,1</td>
          <td>2,2</td>
          <td>2,3</td>
        </tr>
        <tr>
          <td>3,1</td>
          <td>3,2</td>
          <td>3,3</td>
        </tr>
      </aspSample:CustomHtmlTableRowControlCollection>

    </form>

  </body>
</html>
<!-- </Snippet1> -->
