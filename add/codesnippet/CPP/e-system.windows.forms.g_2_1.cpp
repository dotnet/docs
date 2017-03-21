private:
   void AddHandler()
   {
      GridColumnStylesCollection^ myGridColumns;
      myGridColumns = dataGrid1->TableStyles[ 0 ]->GridColumnStyles;
      
      // Add the handler.
      myGridColumns->CollectionChanged += gcnew CollectionChangeEventHandler( this, &Form1::GridCollection_Changed );
   }

   void GridCollection_Changed( Object^ sender, CollectionChangeEventArgs^ /*e*/ )
   {
      GridColumnStylesCollection^ myGridColumns;
      myGridColumns = dynamic_cast<GridColumnStylesCollection^>(sender);
      Console::WriteLine( myGridColumns->Count );
   }