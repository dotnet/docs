<%-- <snippet2> --%>
<%@ Page Language="C#" MasterPageFile="~/MasterPageCS.master" 
  Title="Connections Page" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>

<script runat="server">

  protected void Button1_Click(object sender, EventArgs e)
  {
    StringBuilder lblText = new StringBuilder();
    
    if (Page.Master.FindControl("WebPartManager1") != null)
    {
      WebPartManager theMgr = 
        (WebPartManager)Page.Master.FindControl("WebPartManager1");
      lblText.Append("WebPartManager:  <br /><pre>" +
        "  Master page file is " + Page.MasterPageFile + "<br />" +
        "  ID is " + theMgr.ID + "<br />" +
        "  Connection count is " +
           theMgr.StaticConnections.Count.ToString() + "<br />" +
        "  WebParts count is " +
           theMgr.WebParts.Count.ToString() + "</pre><br />");
    }

    if (proxymgr1 != null)
    {
      lblText.Append("ProxyWebPartManager:  <br /><pre>" +
        "  Content page file is " + Request.Path + "<br />" +
        "  ID is " + proxymgr1.ID + "<br />" +
        "  Connection count is " +
           proxymgr1.StaticConnections.Count.ToString() + 
           "</pre><br />");
    }

    Literal1.Text = lblText.ToString();
    
  }
  
</script>

<asp:Content ID="Content1" Runat="Server" 
  ContentPlaceHolderID="ContentPlaceHolder1" >
 
  <asp:proxywebpartmanager id="proxymgr1" runat="server">
    <staticconnections>
      <asp:webpartconnection id="connection1" 
        consumerconnectionpointid="ZipCodeConsumer"
        consumerid="zipConsumer"
        providerconnectionpointid="ZipCodeProvider" 
        providerid="zipProvider" />
    </staticconnections>    
  </asp:proxywebpartmanager>

  <div>
  <asp:webpartzone id="zone1" runat="server">
    <zonetemplate>
      <aspsample:zipcodewebpart id="zipProvider" runat="server" 
        title="Zip Code Provider"  />
      <aspsample:weatherwebpart id="zipConsumer" runat="server" 
        title="Zip Code Consumer" />
    </zonetemplate>
  </asp:webpartzone>
  </div>
  
  <div>
  <asp:button id="Button1" runat="server" 
    text="WebPartManager Information" onclick="Button1_Click" />
  <br />
  
  </div>
  
  <asp:connectionszone id="ConnectionsZone1" runat="server" />
  <asp:literal id="Literal1" runat="server" />

</asp:Content>
<%-- </snippet2> --%>