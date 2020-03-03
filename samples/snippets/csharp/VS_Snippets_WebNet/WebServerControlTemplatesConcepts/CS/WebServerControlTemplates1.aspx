<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Web Server Control Templates</title>
</head>

<body>
    <form id="form1" runat="server">
      <div>
      
        <!--<Snippet1>-->
        <asp:datalist id="DataList1" runat="server">
          <HeaderTemplate>
          Employee List
          </HeaderTemplate>
          <ItemTemplate>
            <asp:label id="Label1" runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.EmployeeName")%>'></asp:label>
            <asp:label id="Label2" runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.PhoneNumber")%>'></asp:label>
            <asp:Hyperlink id="Hyperlink1" runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'
                NavigateURL='<%# DataBinder.Eval(Container, "DataItem.Link") %>'>
            </asp:Hyperlink>
          </ItemTemplate>
        </asp:datalist>
       <!--</Snippet1>-->
       
    </div>
    </form>
</body>
</html>
