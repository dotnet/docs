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