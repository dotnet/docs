 private void AddHandler() {
    GridColumnStylesCollection myGridColumns;
    myGridColumns = dataGrid1.TableStyles[0].GridColumnStyles;
    // Add the handler.
    myGridColumns.CollectionChanged += new 
       CollectionChangeEventHandler(GridCollection_Changed);
 }
 
 private void GridCollection_Changed
   (object sender, CollectionChangeEventArgs e) {
    GridColumnStylesCollection myGridColumns;
    myGridColumns = (GridColumnStylesCollection) sender;
    Console.WriteLine(myGridColumns.Count);
 }       