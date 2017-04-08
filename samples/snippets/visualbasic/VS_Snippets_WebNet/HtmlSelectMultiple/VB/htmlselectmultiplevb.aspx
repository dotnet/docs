<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Sub Button_Click (sender As Object, e As EventArgs)
        Dim i As Integer

        Label1.Text = "You selected:"
        For i = 0 to Select1.Items.Count - 1
           If Select1.Items(i).Selected Then
               Label1.Text = Label1.Text & "<br /> &nbsp;&nbsp; -" & Select1.Items(i).Text
           End If         
        Next

        Select1.Size = CInt(Select2.Value)

      End Sub

      Sub Check_Changed (sender As Object, e As EventArgs)
         Select1.Multiple = CheckBox1.Checked
      End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> HtmlSelect Example </title>
</head>
<body>
<form id="form1" runat="server">
   <div>

      <h3> HtmlSelect Example </h3>

      Select item(s) from the list: <br /><br />

      <select id="Select1" 
              multiple="true"
              runat="server">

         <option value="1"> Item 1 </option>
         <option value="2"> Item 2 </option>
         <option value="3"> Item 3 </option>
         <option value="4" selected="selected"> Item 4 </option>
         <option value="5"> Item 5 </option>
         <option value="6"> Item 6 </option>

      </select>

      <hr />

      HtmlSelect Size: <br />

      <select id="Select2" 
              runat="server">

         <option value="1" selected="selected"> 1 </option>
         <option value="2"> 2 </option>
         <option value="3"> 3 </option>
         <option value="4"> 4 </option>
         <option value="5"> 5 </option>
         <option value="6"> 6 </option>

      </select>

      &nbsp;&nbsp;

      <asp:CheckBox id="CheckBox1"
           Text="Enable Multiple Property"
           AutoPostBack="True"
           OnCheckedChanged="Check_Changed"
           Checked="True"
           runat="server"/>

      <br /><br />

      <button id="Button1"
              onserverclick="Button_Click"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1" runat="server"/>

   </div>
</form>
</body>
</html>
<!--</Snippet1>-->