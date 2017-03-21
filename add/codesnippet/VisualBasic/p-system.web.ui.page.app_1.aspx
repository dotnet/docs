      ' When this page is loaded, the source for the 
      ' MyDataGrid control is obtained from Application state.
      Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
      
          Dim Source As DataView = Application("Source")
          MySpan.Controls.Add(New LiteralControl(Source.Table.TableName))
          MyDataGrid.DataSource = Source
          MyDataGrid.DataBind()
      End Sub