<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Button1_Click(object sender, EventArgs e)
    {
        if (HyperLink1.CssClass == "CssStyle1")
            HyperLink1.CssClass = "CssStyle2";
        else
            HyperLink1.CssClass = "CssStyle1";
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>CssClass Property Example</title>
    <style type="text/css">
        .CssStyle1   
        { 
           font: 10pt Verdana; 
           font-weight:700;
           color: Green;
        }

        .CssStyle2
        { 
           font: 15pt Times; 
           font-weight:250;
           color: Blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>CssClass Property of a Web Control</h3>
        <asp:HyperLink id="HyperLink1" 
            NavigateUrl="http://www.microsoft.com" 
            CssClass="CssClass1" 
            Text="Click here to go to the Microsoft site" 
            Target="_new" runat="server" />
        <p><asp:Button id="Button1" 
            Text="Click to change the CSS style of the link"
            OnClick="Button1_Click" runat="server" />
         </p>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
