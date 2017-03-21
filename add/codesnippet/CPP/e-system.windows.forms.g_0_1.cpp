private:
   void AddHandler()
   {
      dataGrid1->TableStyles->CollectionChanged +=
         gcnew CollectionChangeEventHandler( this, &Form1::Collection_Changed );
   }

   void Collection_Changed( Object^ sender, CollectionChangeEventArgs^ e )
   {
      GridTableStylesCollection^ gts = (GridTableStylesCollection^)(sender);
      Console::WriteLine( gts->Count );
   }
