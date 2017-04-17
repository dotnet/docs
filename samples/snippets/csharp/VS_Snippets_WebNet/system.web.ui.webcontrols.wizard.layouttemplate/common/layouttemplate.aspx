<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<%-- <Snippet1> --%>
    <form id="form1" runat="server">
   <asp:Wizard ID="Wizard1" runat="server">
  <LayoutTemplate>
    <div>
      <asp:PlaceHolder ID="headerPlaceHolder" runat="server" />
    </div>
    <div>
      <asp:PlaceHolder ID="navigationPlaceHolder" runat="server" />
    </div>

    <div>
      <asp:PlaceHolder ID="sideBarPlaceHolder" runat="server" />
    </div>

    <div>
      <asp:PlaceHolder ID="WizardStepPlaceHolder" runat="server" />
    </div>
  </LayoutTemplate>

  <SideBarTemplate>
    <asp:ListView ID="sideBarList" runat="server">
      <LayoutTemplate>
        <div id="ItemPlaceHolder" runat="server"/>
      </LayoutTemplate>

      <ItemTemplate>
         <asp:LinkButton ID="sideBarButton" runat="server" 
             Text="Button" />
      </ItemTemplate>

    </asp:ListView>
  </SideBarTemplate>

  <HeaderTemplate>
     Header content.
  </HeaderTemplate>

  <WizardSteps>
    <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
        Step 1 Content.
   </asp:WizardStep>
  <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
        Step 2 Content.
  </asp:WizardStep>
  </WizardSteps>
</asp:Wizard>

    </form>

<%--</Snippet1>--%>
</body>
</html>






