      void Page_Load(Object sender, EventArgs e) 
      {
         if (!IsPostBack) 
         {  
            DataList1.AlternatingItemTemplate = LoadTemplate("newtemplate.ascx");
            DataList1.DataSource = CreateDataSource();
            DataList1.DataBind();
         }
      }