<!--<Snippet11> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Naming Container Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="XmlDataSource1" 
                           runat="server" 
                           XPath="Books/LanguageBooks/Book">
        <Data>
         <Books>
            <LanguageBooks>
              <Book Title="Pure JavaScript" 
                    Author="Wyke, Gilliam, and Ting"/>
              <Book Title="Effective C++ Second Edition" 
                    Author="Scott Meyers"/>
              <Book Title="Assembly Language Step-By-Step" 
                    Author="Jeff Duntemann"/>
              <Book Title="Oracle PL/SQL" 
                    Author="Steven Feuerstein"/>
            </LanguageBooks>
            <SecurityBooks>
              <Book Title="Counter Hack" 
                    Author="Ed Skoudis"/>
            </SecurityBooks>
          </Books>
        </Data>
        </asp:XmlDataSource>
        <asp:GridView ID="GridView1" 
                      runat="server" 
                      DataSourceID="XmlDataSource1" 
                      AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Title" >
                    <ItemTemplate>
                        <!--<Snippet8>-->
                        <asp:Label ID="Label1" runat="server">
                        <%# Container.DataItemIndex + 1 %>. <%# Eval("Title") %>
                        </asp:Label>
                        <!--</Snippet8>-->
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
<!--</Snippet11> -->