<!-- <Snippet1> -->
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateControl XPath and XPathSelect Example</title>
</head>
<body>
    <h3>TemplateControl XPath Example</h3>
    <form id="form1" runat="server">
    <div>
      <asp:XmlDataSource
        id="XmlDataSource1" 
        runat="server"
        XPath="contacts" 
        DataFile="contacts.xml" />    
      <asp:FormView 
        id="FormView1" 
        runat="server" 
        DataSourceID="XmlDataSource1">
        <ItemTemplate>
          <hr />
          <asp:Repeater 
            id="Repeater1" 
            runat="server" 
            DataSource='<%# XPathSelect("contact") %>' >
            <ItemTemplate>
              Name: <%# XPath("name") %> <br />
              Note: <%# XPath("note") %> <br />
              <hr />
            </ItemTemplate>
          </asp:Repeater>
        </ItemTemplate>
      </asp:FormView>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->