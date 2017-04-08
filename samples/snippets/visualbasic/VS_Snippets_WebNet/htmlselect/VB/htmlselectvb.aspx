<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Sub Button_Click (sender As Object, e As EventArgs)
        
        Dim i As Integer

        Label1.Text = "You selected:"
        For i = 0 to Select1.Items.Count - 1
  
            If Select1.Items(i).Selected Then
               Label1.Text = Label1.Text & "<br /> &nbsp;&nbsp; -" _
                   & Select1.Items(i).Text
            End If         

        Next i

    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlSelect Example </title>
</head>
<body>
<form id="form1" runat="server">

    <h3> HtmlSelect Example </h3>

    Select items from the list: <br /><br />

    <select id="Select1" 
            multiple="true"
            runat="server">

        <option value="1" selected="selected"> Item 1 </option>
        <option value="2"> Item 2 </option>
        <option value="3"> Item 3 </option>
        <option value="4"> Item 4 </option>
        <option value="5"> Item 5 </option>
        <option value="6"> Item 6 </option>

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
