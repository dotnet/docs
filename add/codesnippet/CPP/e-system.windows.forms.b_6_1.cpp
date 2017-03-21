   void BindControl()
   {
      
      /* Create a Binding object for the TextBox control. 
         The data-bound property for the control is the Text 
         property. */
      Binding^ myBinding = gcnew Binding( "Text",ds,"customers.custName" );
      text1->DataBindings->Add( myBinding );
      
      // Get the BindingManagerBase for the Customers table. 
      BindingManagerBase^ bmCustomers = this->BindingContext[ ds,"Customers" ];
      
      // Add the delegate for the PositionChanged event.
      bmCustomers->PositionChanged += gcnew EventHandler( this, &Form1::Position_Changed );
   }


private:
   void Position_Changed( Object^ sender, EventArgs^ /*e*/ )
   {
      
      // Print the Position property value when it changes.
      Console::WriteLine( (dynamic_cast<BindingManagerBase^>(sender))->Position );
   }
