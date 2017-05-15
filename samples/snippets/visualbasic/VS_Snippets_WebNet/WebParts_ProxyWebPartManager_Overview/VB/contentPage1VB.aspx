<%-- <snippet2> --%>
<%@ Page Language="VB" MasterPageFile="~/MasterPageVB.master" 
  Title="Connections Page" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls" %>

<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)

    Dim lblText As StringBuilder = New StringBuilder()

    If Not (Page.Master.FindControl("WebPartManager1") Is Nothing) Then
      Dim theMgr As WebPartManager = _
        CType(Page.Master.FindControl("WebPartManager1"), WebPartManager)
      lblText.Append("WebPartManager:  <br /><pre>" & _
        "  Master page file is " & Page.MasterPageFile & "<br />" & _
        "  ID is " & theMgr.ID & "<br />" & _
        "  Connection count is " & _
           theMgr.StaticConnections.Count.ToString() & "<br />" & _
        "  WebParts count is " & _
           theMgr.WebParts.Count.ToString() & "</pre><br />")
    End If

    If Not (proxymgr1 Is Nothing) Then
      lblText.Append("ProxyWebPartManager:  <br /><pre>" & _
        "  Content page file is " & Request.Path & "<br />" & _
        "  ID is " & proxymgr1.ID & "<br />" & _
        "  Connection count is " & _
           proxymgr1.StaticConnections.Count.ToString() & "</pre><br />")
    End If

    Literal1.Text = lblText.ToString()
    
  End Sub

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
  <asp:literal id="Literal1" runat="server" />
  </div>
  
  <asp:connectionszone id="ConnectionsZone1" runat="server" />
  
</asp:Content>
<%-- </snippet2> --%>