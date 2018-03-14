<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<script language="C#" runat="server">
   void Page_Load(Object sender, EventArgs e) 
   {
      Message.InnerHtml = "<h4>The select box's style collection contains:</h4>";
     
      IEnumerator keys = Select.Style.Keys.GetEnumerator();

      while (keys.MoveNext()) 
      {

         String key = (String)keys.Current;
         Message.InnerHtml += key + "=" + Select.Style[key] + "<br />";

      }
   }

</script>

<head runat="server">
    <title>The select box's style collection contains:</title>
</head>
<body>
<form id="Form1" runat="server">

   <h3>HtmlControl Style Collection Example</h3>

   Make a selection:

   <select id="Select" 
           style="font: 12pt verdana;
                 background-color:yellow;
                 color:red;" 
           runat="server">

      <option>Item 1</option>
      <option>Item 2</option>
      <option>Item 3</option>

   </select>

   <br />

   <span id="Message" enableviewstate="false" runat="server" />
   
</form>
</body>
</html>
   
<!--</Snippet1>-->
