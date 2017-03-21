private void AddToolbarButtons(ToolBar toolBar)
{
   if(!toolBar.Buttons.IsReadOnly)
   {
      // If toolBarButton1 in in the collection, remove it.
      if(toolBar.Buttons.Contains(toolBarButton1))
      {
         toolBar.Buttons.Remove(toolBarButton1);
      }
	
      // Create three toolbar buttons.
      ToolBarButton tbb1 = new ToolBarButton("tbb1");
      ToolBarButton tbb2 = new ToolBarButton("tbb2");
      ToolBarButton tbb3 = new ToolBarButton("tbb3");
      
      // Add toolbar buttons to the toolbar.		
      toolBar.Buttons.AddRange(new ToolBarButton[] {tbb2, tbb3});
      toolBar.Buttons.Add("tbb4");
	
      // Insert tbb1 into the first position in the collection.
      toolBar.Buttons.Insert(0, tbb1);
   }
}