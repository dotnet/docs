<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenu" 
  Src="DisplayModecs.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS" %>
  
<!-- <snippet2> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Button1_Click(object sender, EventArgs e)
  {
    ArrayList list = new ArrayList(2);
    list.Add(AppearanceEditorPart1);
    list.Add(PropertyGridEditorPart1);
    // Pass an ICollection object to the constructor.
    EditorPartCollection myParts = new EditorPartCollection(list);
    foreach (EditorPart editor in myParts)
    {
      editor.BackColor = System.Drawing.Color.LightBlue;
      editor.Description = "My " + editor.DisplayTitle + " editor.";
    }

    // Use the IndexOf property to locate an EditorPart control.
    int propertyGridPart = myParts.IndexOf(PropertyGridEditorPart1);
    myParts[propertyGridPart].ChromeType = PartChromeType.TitleOnly;

    // Use the Contains method to see if an EditorPart exists.
    if(!myParts.Contains(LayoutEditorPart1))
      LayoutEditorPart1.BackColor = System.Drawing.Color.LightYellow;
    
    // Use the CopyTo method to create an array of EditorParts.
    EditorPart[] partArray = new EditorPart[3];
    partArray[0] = LayoutEditorPart1;
    myParts.CopyTo(partArray,1);
    Label1.Text = "<h3>EditorParts in Custom Array</h3>";
    foreach (EditorPart ePart in partArray)
    {
      Label1.Text += ePart.Title + "<br />";
    }

  }

</script>
<!-- </snippet2> --> 
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      Text Display WebPart with AppearanceEditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
      <uc1:DisplayModeMenu ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server">
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" />          
        </zonetemplate>
      </asp:webpartzone> 
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
            runat="server" />
          <asp:LayoutEditorPart ID="LayoutEditorPart1" 
            runat="server" />
          <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" 
            runat="server" />
        </ZoneTemplate>      
      </asp:EditorZone>
      <asp:Button ID="Button1" runat="server" 
        Text="Create EditorPartCollection" 
        OnClick="Button1_Click" />
      <asp:Label ID="Label1" runat="server" Text="" />
    </form>
  </body>
</html>
<!-- </snippet1> -->