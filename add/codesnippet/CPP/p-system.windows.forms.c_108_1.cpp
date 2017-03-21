private:
   void Grid_Navigate( Object^ /*sender*/, NavigateEventArgs^ e )
   {
      if ( e->Forward )
      {
         DataSet^ ds = dynamic_cast<DataSet^>(grid->DataSource);
         CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(BindingContext[ds, "Customers::CustOrders"]);
         
         // Cast the IList* to a DataView to set the AllowNew property.
         DataView^ dv = dynamic_cast<DataView^>(cm->List);
         dv->AllowNew = false;
      }
   }