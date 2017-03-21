   void GetBindingManagerBase()
   {
      
      /* CustomersToOrders is the RelationName of a DataRelation. 
         Therefore, the list maintained by the BindingManagerBase is the
         list of orders that belong to a specific customer in the 
         DataTable named Customers, found in DataSet1. */
      myBindingManagerBase = this->BindingContext[DataSet1, "Customers.CustomersToOrders"];
      
      // Adds delegates to the CurrentChanged and PositionChanged events.
      myBindingManagerBase->PositionChanged += gcnew EventHandler( this, &Form1::BindingManagerBase_PositionChanged );
      myBindingManagerBase->CurrentChanged += gcnew EventHandler( this, &Form1::BindingManagerBase_CurrentChanged );
   }

   void BindingManagerBase_PositionChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      
      // Prints the new Position of the BindingManagerBase.
      Console::Write( "Position Changed: " );
      Console::WriteLine( (dynamic_cast<BindingManagerBase^>(sender))->Position );
   }

   void BindingManagerBase_CurrentChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      
      // Prints the new value of the current object.
      Console::Write( "Current Changed: " );
      Console::WriteLine( (dynamic_cast<BindingManagerBase^>(sender))->Current );
   }

   void MoveNext()
   {
      
      // Increments the Position property value by one.
      myBindingManagerBase->Position = myBindingManagerBase->Position + 1;
   }

   void MovePrevious()
   {
      
      // Decrements the Position property value by one.
      myBindingManagerBase->Position = myBindingManagerBase->Position - 1;
   }

   void MoveFirst()
   {
      
      // Goes to the first row in the list.
      myBindingManagerBase->Position = 0;
   }

   void MoveLast()
   {
      
      // Goes to the last row in the list.
      myBindingManagerBase->Position = myBindingManagerBase->Count - 1;
   }
