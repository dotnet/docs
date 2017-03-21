<script language="c#" runat="server">
    
  void Page_Load(Object sender, EventArgs e) 
  {
      StringBuilder sb = new StringBuilder();
      sb.Append("Container: " + 
          MyDataList.NamingContainer.ToString() + "<p>");

      ArrayList a = new ArrayList();
      a.Add("A");
      a.Add("B");
      a.Add("C");

      MyDataList.DataSource = a;
      MyDataList.DataBind();

      for (int i = 0; i < MyDataList.Controls.Count; i++)
      {
          Label l = 
              (Label)((RepeaterItem)MyDataList.Controls[i]).FindControl("MyLabel");
          sb.Append("Container: " + 
              ((RepeaterItem)MyDataList.Controls[i]).NamingContainer.ToString() + 
              "<p>");
          sb.Append("<b>" + l.UniqueID + "</b><p>");
      }
      ResultsLabel.Text = sb.ToString();
}
</script>