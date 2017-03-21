            ' Create a new ListItemCollection.
            Dim listBoxData As New ListItemCollection()
            ' Add items to the collection.
            listBoxData.Add(New ListItem("apples"))
            listBoxData.Add(New ListItem("bananas"))
            listBoxData.Add(New ListItem("cherries"))
            listBoxData.Add("grapes")
            listBoxData.Add("mangos")
            listBoxData.Add("oranges")
            ' Set the ListItemCollection as the data source for ListBox1.
            ListBox1.DataSource = listBoxData
            ListBox1.DataBind()