<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
       <title>How to: Add Server Controls to a Web Forms Page Using ASP.NET Syntax</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<!-- <Snippet2> -->
<!-- Textbox Web server control -->
<asp:textbox id="TextBox1" runat="Server" Text=""></asp:textbox>

<!-- Same, but with self-closing element -->
<asp:textbox id="Textbox2" runat="Server" Text="" />

<!-- Web DropDownList control, which contains subelements -->
<asp:DropDownList id="DropDown1" runat="server">
   <asp:ListItem Value="0">0</asp:ListItem>
   <asp:ListItem Value="1">1</asp:ListItem>
   <asp:ListItem Value="2">2</asp:ListItem>
   <asp:ListItem Value="3">3</asp:ListItem>
</asp:DropDownList>

<asp:Repeater id="Repeater2" runat="server">
   <HeaderTemplate>
       Company data:
   </HeaderTemplate>
   <ItemTemplate>
       <asp:Label ID="Label1" runat="server" 
             Font-Names="verdana" Font-Size="10pt"
             Text='<%# Eval("Name") %>' />
       ( <asp:Label ID="Label2" runat="server"
             Font-Names="verdana" Font-Size="10pt"
             Text='<%# Eval("Ticker") %>'/>
        )
   </ItemTemplate>
   <SeparatorTemplate>
       ,
   </SeparatorTemplate>
</asp:Repeater>
<!--</Snippet2>-->

    </div>
    </form>
</body>
</html>
