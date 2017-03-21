   void ReturnBindingManagerBase()
   {
      
      // Get the BindingManagerBase for a DataView. 
      BindingManagerBase^ bmCustomers = this->BindingContext[ myDataView ];
      
      /* Get the BindingManagerBase for an ArrayList. */
      BindingManagerBase^ bmOrders = this->BindingContext[ myArrayList ];
      
      // Get the BindingManagerBase for a TextBox control.
      BindingManagerBase^ baseArray = this->BindingContext[ textBox1->DataBindings[ nullptr ]->DataSource ];
   }
