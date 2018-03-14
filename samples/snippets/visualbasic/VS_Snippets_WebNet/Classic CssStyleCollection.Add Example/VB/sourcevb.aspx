<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    
    SubmitBtn.Style.Add("letter-spacing", "10px")
    FirstSelect.Style.Add(HtmlTextWriterStyle.Color, FirstSelect.Items(FirstSelect.SelectedIndex).Value.ToString())
    Message.Style.Add(HtmlTextWriterStyle.Color, FirstSelect.Items(FirstSelect.SelectedIndex).Value.ToString())
    Message.Text = "The select style is: " + FirstSelect.Style.Value

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CssStyleCollection Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Select a color and then click submit.
    <br />
    <select id="FirstSelect" 
            style="font: 10pt verdana;color:black;" 
            runat="server">
        <option value="black">black</option>
        <option value="red">red</option>
        <option value="blue">blue</option>
        <option value="green">green</option>
    </select> 
    <input id="SubmitBtn" 
           value="Submit" 
           type="submit" 
           onserverclick="SubmitBtn_Click"
           runat="server" /><br />
    <br />
    <asp:Label id="Message"
               runat="server"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->