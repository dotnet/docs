  protected void Button1_Click(object sender, EventArgs e)
  {
    BehaviorEditorPart1.Title = Server.HtmlEncode(TextBox1.Text);
  }