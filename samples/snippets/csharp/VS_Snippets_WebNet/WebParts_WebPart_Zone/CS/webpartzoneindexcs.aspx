<!-- <snippet1> -->
<%@ page language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  String labelText = @"<p><strong>Text WebPart " +
                     "Zone Information</strong></p>";

  void Button1_Click(object sender, EventArgs e)
  {
    // Get the zone for the Web Parts control.
    WebPartZoneBase theZone = textpart1.Zone;
    Label1.Text = labelText +
                  "Zone ID:  " + theZone.ID +
                  @"<br />" +
                  "Zone Index:  " +
                  textpart1.ZoneIndex.ToString();
    // Change the type of button for the verb.
    theZone.VerbButtonType = ButtonType.Button;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <asp:Calendar ID="cal1" Runat="server" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:webpartzone
      id="WebPartZone2"
      runat="server"
      title="Zone 2"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <aspSample:textdisplaywebpart 
            id="textpart1" 
            runat="server" 
            Title="Text WebPart" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:Button ID="Button1" 
      Runat="server" 
      Text="Zone Information" 
      OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" />
  </form>
</body>
</html>
<!-- </snippet1> -->