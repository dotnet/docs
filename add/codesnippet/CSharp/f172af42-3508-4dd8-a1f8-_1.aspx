      void Page_Load(Object Sender, EventArgs e)
      {
if (!IsPostBack)
{
   ArrayList myDataSource = new ArrayList();

   myDataSource.Add(new PositionData("Item 1", "$6.00"));
   myDataSource.Add(new PositionData("Item 2", "$7.48"));
   myDataSource.Add(new PositionData("Item 3", "$9.96"));
   
   // Initialize the RepeaterItemCollection using the ArrayList as the data source.
   RepeaterItemCollection myCollection = new RepeaterItemCollection(myDataSource);
   myRepeater.DataSource = myCollection;
   myRepeater.DataBind();
}
      }