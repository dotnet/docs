    //This event handler enables search functionality, and is called
    //for every search request when in Virtual mode.
    void listView1_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
    {
        //We've gotten a search request.
        //In this example, finding the item is easy since it's
        //just the square of its index.  We'll take the square root
        //and round.
        double x = 0;
        if (Double.TryParse(e.Text, out x)) //check if this is a valid search
        {
            x = Math.Sqrt(x);
            x = Math.Round(x);
            e.Index = (int)x;
               
        }
        //If e.Index is not set, the search returns null.
        //Note that this only handles simple searches over the entire
        //list, ignoring any other settings.  Handling Direction, StartIndex,
        //and the other properties of SearchForVirtualItemEventArgs is up
        //to this handler.
    }