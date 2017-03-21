   Sub Page_Load(Sender As Object, e As EventArgs)
      If Not IsPostBack Then
         Dim myDataSource As New ArrayList()

         myDataSource.Add(New PositionData("Item 1", "$6.00"))
         myDataSource.Add(New PositionData("Item 2", "$7.48"))
         myDataSource.Add(New PositionData("Item 3", "$9.96"))

         ' Initialize the RepeaterItemCollection using the ArrayList as the data source.
         Dim myCollection As New RepeaterItemCollection(myDataSource)
         myRepeater.DataSource = myCollection
         myRepeater.DataBind()
      End If
   End Sub 'Page_Load