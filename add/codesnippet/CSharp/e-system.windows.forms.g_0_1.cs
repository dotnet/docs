private void AddHandler()
{
   dataGrid1.TableStyles.CollectionChanged += 
   new CollectionChangeEventHandler(Collection_Changed);
}

private void Collection_Changed
(object sender, CollectionChangeEventArgs e)
{
   GridTableStylesCollection gts = (GridTableStylesCollection)
   sender;
   Console.WriteLine(gts.Count);
}