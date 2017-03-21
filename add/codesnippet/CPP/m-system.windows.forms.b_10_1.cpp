   // This event handler changes the value of the CompanyName
   // property for the first item in the list.
   void changeItemBtn_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Get a reference to the list from the BindingSource.
      List< DemoCustomer^ >^ customerList =
         static_cast<List< DemoCustomer^ >^>(
           this->customersBindingSource->DataSource);
      
      // Change the value of the CompanyName property for the
      // first item in the list.
      customerList->default[ 0 ]->CompanyName = L"Tailspin Toys";
      
      // Call ResetItem to alert the BindingSource that the
      // list has changed.
      this->customersBindingSource->ResetItem( 0 );
   }