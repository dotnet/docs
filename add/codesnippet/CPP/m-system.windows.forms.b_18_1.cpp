private:
   void TryContainsDataMember( DataSet^ myDataSet )
   {
      bool trueorfalse;
      trueorfalse = this->BindingContext->Contains( myDataSet, "Suppliers" );
      Console::WriteLine( trueorfalse );
   }