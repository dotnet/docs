  private static String editControlTitle;
  
  protected void Button1_Click(object sender, EventArgs e)
  {
    editControlTitle = Server.HtmlEncode(TextBox1.Text);
    PropertyGridEditorPart1.Title = editControlTitle;
  }

  protected void PropertyGridEditorPart1_Init(object sender, EventArgs e)
  {
    if (editControlTitle != null)
      PropertyGridEditorPart1.Title = editControlTitle;
  }  