   void AddToolbarButtons( ToolBar^ toolBar )
   {
      if (  !toolBar->Buttons->IsReadOnly )
      {
         
         // If toolBarButton1 in in the collection, remove it.
         if ( toolBar->Buttons->Contains( toolBarButton1 ) )
         {
            toolBar->Buttons->Remove( toolBarButton1 );
         }
         
         // Create three toolbar buttons.
         ToolBarButton^ tbb1 = gcnew ToolBarButton( "tbb1" );
         ToolBarButton^ tbb2 = gcnew ToolBarButton( "tbb2" );
         ToolBarButton^ tbb3 = gcnew ToolBarButton( "tbb3" );
         
         // Add toolbar buttons to the toolbar.
         array<ToolBarButton^>^buttons = {tbb2,tbb3};
         toolBar->Buttons->AddRange( buttons );
         toolBar->Buttons->Add( "tbb4" );
         
         // Insert tbb1 into the first position in the collection.
         toolBar->Buttons->Insert( 0, tbb1 );
      }
   }