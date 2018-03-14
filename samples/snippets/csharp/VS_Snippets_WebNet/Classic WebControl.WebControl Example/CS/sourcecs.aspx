<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 
    void Button1_Click(Object sender, EventArgs e) 
    {
        WebControl wc = new WebControl(HtmlTextWriterTag.Textarea);
        PlaceHolder1.Controls.Add(wc);
    }

</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>WebControl Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>WebControl Constructor Example</h3>
    <p>
        <asp:PlaceHolder id="PlaceHolder1"
            runat="Server"/>
    </p>

    <p>
        <asp:Button id="Button1" runat="Server"
            Text="Click to create a new TextArea" 
            OnClick="Button1_Click" />
    </p>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
