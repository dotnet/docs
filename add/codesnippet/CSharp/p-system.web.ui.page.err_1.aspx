   void Page_Load(Object sender, EventArgs e)
   {
      // Note: This property can also be set in <%@ Page ...> tag.
      if(!IsPostBack)
         this.ErrorPage = "Error_Page.aspx";
   }