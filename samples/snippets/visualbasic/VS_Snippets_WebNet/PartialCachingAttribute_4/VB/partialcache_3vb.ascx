<!-- <snippet3> -->
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="partialcache_3vb.ascx.vb" Inherits="ctlSelect" %>

<br />

<asp:DropDownList id="state" runat="server">
            <asp:ListItem> </asp:ListItem>  
            <asp:ListItem>Idaho</asp:ListItem>
            <asp:ListItem>Montana</asp:ListItem>
            <asp:ListItem>Nevada</asp:ListItem>
            <asp:ListItem>Oregon</asp:ListItem>
            <asp:ListItem>Washington</asp:ListItem>
            <asp:ListItem>Wyoming</asp:ListItem>
        </asp:DropDownList>
<br />

<asp:DropDownList id="country" runat="server">
      <asp:ListItem>  </asp:ListItem>
      <asp:ListItem>Austria</asp:ListItem>
      <asp:ListItem>France</asp:ListItem>
      <asp:ListItem>Italy</asp:ListItem>
      <asp:ListItem>Germany</asp:ListItem>
      <asp:ListItem>Spain</asp:ListItem>
      <asp:ListItem>Switzerland</asp:ListItem>
</asp:DropDownList>
<br />
<asp:button id="btnSelect" text="Submit" OnClick="SubmitBtn_Click" runat="server"/>
<br />    
<asp:Label id="Label1" Font-Names="Verdana" font-size="10pt" runat="server">
          Select values from the lists
</asp:Label>

<br /> <br />

Control generated at: <asp:label id="TimeMsg" runat="server" />
<!-- </snippet3> -->