  protected void Button1_Click(object sender, EventArgs e)
  {
    LayoutEditorPart1.Title = Server.HtmlEncode(TextBox1.Text);
  }