<!-- <snippet1> -->
<%@ page language="VB" %>
<%@ register tagprefix="uc1" 
    tagname="AccountUserControlVB" 
    src="AccountUserControlvb.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      Personalizable User Control with IWebPart Properties
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
      <asp:webpartzone 
        id="zone1" 
        runat="server" 
        headertext="Main" 
        CloseVerb-Enabled="false">
        <zonetemplate>
          <uc1:AccountUserControlVB 
            runat="server" 
            id="accountwebpart" 
            title="Account Form"
            Description="Account Form with default values."
            CatalogIconImageUrl="MyCatalogIcon.gif"
            TitleIconImageUrl="MyTitleIcon.gif"
            TitleUrl="MyUrl.html"/>
        </zonetemplate>
      </asp:webpartzone>    
    </form>
  </body>
</html>
<!-- </snippet1> -->