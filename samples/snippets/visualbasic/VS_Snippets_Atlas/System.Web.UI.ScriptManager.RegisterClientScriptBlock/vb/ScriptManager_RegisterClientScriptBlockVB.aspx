<!-- <Snippet1> -->

<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim script As String
        script = _
        "function ToggleItem(id)" & _
        "  {" & _
        "    var elem = $get('div'+id);" & _
        "    if (elem)" & _
        "    {" & _
        "      if (elem.style.display != 'block') " & _
        "      {" & _
        "        elem.style.display = 'block';" & _
        "        elem.style.visibility = 'visible';" & _
        "      } " & _
        "      else" & _
        "      {" & _
        "        elem.style.display = 'none';" & _
        "        elem.style.visibility = 'hidden';" & _
        "      }" & _
        "    }" & _
        "  }"
        
        ScriptManager.RegisterClientScriptBlock( _
            Me, _
            GetType(Page), _
            "ToggleScript", _
            script, _
            True)

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ScriptManager RegisterClientScriptInclude</title>
</head>
<body>
    <form id="Form1" runat="server">
        <div>
            <br />
            <asp:ScriptManager ID="ScriptManager1" 
                                 EnablePartialRendering="true"
                                 runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" 
                               UpdateMode="Conditional"
                               runat="server">
                <ContentTemplate>
                    <asp:XmlDataSource ID="XmlDataSource1"
                                       DataFile="~/App_Data/Contacts.xml"
                                       XPath="Contacts/Contact"
                                       runat="server"/>
                    <asp:DataList ID="DataList1" DataSourceID="XmlDataSource1"
                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None"
                        BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
                        runat="server">
                        <ItemTemplate>
                            <div style="font-size:larger; font-weight:bold; cursor:pointer;" 
                                 onclick='ToggleItem(<%# Eval("ID") %>);'>
                                <span><%# Eval("Name") %></span>
                            </div>
                            <div id='div<%# Eval("ID") %>' 
                                 style="display: block; visibility: visible;">
                                <span><%# Eval("Company") %></span>
                                <br />
                                <a href='<%# Eval("URL") %>' 
                                   target="_blank" 
                                   title='<%# Eval("Name", "Link to the {0} Web site") %>'>
                                   <%# Eval("URL") %></a>
                                </asp:LinkButton>
                                <hr />
                            </div>
                        </ItemTemplate>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingItemStyle BackColor="#F7F7F7" />
                        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    </asp:DataList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
