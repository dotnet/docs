<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlSelect Example </title>
<script runat="server">

      Sub Button_Click (sender As Object, e As EventArgs)
        
         Label1.Text = "You selected the item with index number " & _
                       Select1.SelectedIndex.ToString() & _
                       " and contains the value " & _
                       Select1.Value & "."

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlSelect Example </h3>

      Select items from the list: <br /><br />

      <select id="Select1" 
              runat="server">

         <option value="Text for Item 1" selected="selected"> Item 1 </option>
         <option value="Text for Item 2"> Item 2 </option>
         <option value="Text for Item 3"> Item 3 </option>
         <option value="Text for Item 4"> Item 4 </option>
         <option value="Text for Item 5"> Item 5 </option>
         <option value="Text for Item 6"> Item 6 </option>

      </select>

      <br /><br />

      <button id="Button1"
              onserverclick="Button_Click"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

   </form>

</body>

</html>

<!--</Snippet1>-->