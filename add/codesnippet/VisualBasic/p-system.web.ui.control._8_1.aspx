  <script language="vb" runat="server">
      
      Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
          Dim sb As New StringBuilder()
          sb.Append("Container: " + _
          MyDataList.NamingContainer.ToString() + "<p>")

          Dim a As New ArrayList()
          a.Add("A")
          a.Add("B")
          a.Add("C")

          MyDataList.DataSource = a
          MyDataList.DataBind()
    
          Dim i As Integer
          Dim l As Label
          For i = 0 To MyDataList.Controls.Count - 1
              l = CType(CType(MyDataList.Controls(i), RepeaterItem).FindControl("MyLabel"), Label)
              sb.Append("Container: " & _
                 CType(MyDataList.Controls(i), RepeaterItem).NamingContainer.ToString() & _
                 "<p>")
              sb.Append("<b>" & l.UniqueID.ToString() & "</b><p>")
          Next
          ResultsLabel.Text = sb.ToString()
      End Sub
</script>