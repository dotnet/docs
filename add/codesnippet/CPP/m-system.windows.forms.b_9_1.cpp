private:
   void TryContains( DataSet^ myDataSet )
   {
      // Test each DataTable in a DataSet to see if it is bound to a BindingManagerBase.
      for each ( DataTable^ thisTable in myDataSet->Tables )
      {
         Console::WriteLine( "{0}: {1}", thisTable->TableName, this->BindingContext->Contains( thisTable ) );
      }
   }