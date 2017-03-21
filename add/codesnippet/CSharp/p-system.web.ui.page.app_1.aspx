      // When this page is loaded, the source for the 
      // MyDataGrid control is obtained from Application state.
      void Page_Load(object sender, EventArgs e ) {
      
          DataView Source = (DataView)(Application["Source"]);
          MySpan.Controls.Add(new LiteralControl(Source.Table.TableName));
          MyDataGrid.DataSource = Source;
          MyDataGrid.DataBind(); 
      }