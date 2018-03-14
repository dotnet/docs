<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // <snippet3>
  protected void Button1_Click(object sender, EventArgs e)
  {
    ImportCatalogPart1.Title = "Import Server Controls";
    ImportCatalogPart1.BrowseHelpText = "Enter the path to a "
      + "description file.";
    ImportCatalogPart1.UploadButtonText = "Upload Description";
    ImportCatalogPart1.UploadHelpText = "Upload a description file.";
    ImportCatalogPart1.ImportedPartLabelText = "Imported Controls";
    ImportCatalogPart1.PartImportErrorLabelText = "An error occured " 
      + "during the import process.";

  }
  // </snippet3>
  
  protected void Page_Load(object sender, EventArgs e)
  {
    Button1.Visible = false;
  }

  protected void ImportCatalogPart1_PreRender(object sender, 
    EventArgs e)
  {
    Button1.Visible = true;
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      ImportCatalogPart Control
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server"  />
      <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server" >
        <PartTitleStyle BorderWidth="1" 
          Font-Names="Verdana, Arial"
          Font-Size="110%"
          BackColor="LightBlue" />
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="TextDisplayWebPart1" 
            title = "Text Display WebPart" /> 
          <aspsample:userinfowebpart id="userinfo1" runat="server" 
            Title="User Information" exportmode="all" />
        </zonetemplate>
      </asp:webpartzone> 
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" 
            runat="server" />
        </ZoneTemplate>
      </asp:EditorZone>
      <!-- <snippet2> -->
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:ImportCatalogPart ID="ImportCatalogPart1" 
            runat="server" 
            Title="My ImportCatalogPart" 
            OnPreRender="ImportCatalogPart1_PreRender"
            BrowseHelpText="Type a path or browse to find a control's 
              description file." 
            UploadButtonText="Upload Description File" 
            UploadHelpText="Click the button to upload the description 
              file."
            ImportedPartLabelText="My User Information WebPart" 
            PartImportErrorLabelText="An error occurred while trying 
              to import a description file."  />
        </ZoneTemplate>
      </asp:CatalogZone>
      <!-- </snippet2> -->
      <hr />
      <asp:Button ID="Button1" runat="server" 
        Text="Update ImportCatalogPart" 
        OnClick="Button1_Click" />
    </form>
  </body>
</html>
<!-- </snippet1> -->