      // The basic Customer class.
      ref class Customer: public System::Object
      {
      private:
         String^ custName;

      protected:
         ArrayList^ custOrders;

      public:
         Customer( String^ customername )
         {
            custName = "";
            custOrders = gcnew ArrayList;
            this->custName = customername;
         }


         property String^ CustomerName 
         {
            String^ get()
            {
               return this->custName;
            }

            void set( String^ value )
            {
               this->custName = value;
            }

         }

         property ArrayList^ CustomerOrders 
         {
            ArrayList^ get()
            {
               return this->custOrders;
            }

         }

      };


      // End Customer class
      // The basic customer Order class.
      ref class Order: public System::Object
      {
      private:
         String^ ordID;

      public:
         Order( String^ orderid )
         {
            ordID = "";
            this->ordID = orderid;
         }


         property String^ OrderID 
         {
            String^ get()
            {
               return this->ordID;
            }

            void set( String^ value )
            {
               this->ordID = value;
            }

         }

      };
      // End Order class



      void FillMyTreeView()
      {
         // Add customers to the ArrayList of Customer objects.
         for ( int x = 0; x < 1000; x++ )
         {
            customerArray->Add( gcnew Customer( "Customer " + x ) );
         }
         
         // Add orders to each Customer object in the ArrayList.
         IEnumerator^ myEnum = customerArray->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Customer^ customer1 = safe_cast<Customer^>(myEnum->Current);
            for ( int y = 0; y < 15; y++ )
            {
               customer1->CustomerOrders->Add( gcnew Order( "Order " + y ) );
            }
         }

         // Display a wait cursor while the TreeNodes are being created.
         ::Cursor::Current = gcnew System::Windows::Forms::Cursor( "MyWait.cur" );
         
         // Suppress repainting the TreeView until all the objects have been created.
         treeView1->BeginUpdate();
         
         // Clear the TreeView each time the method is called.
         treeView1->Nodes->Clear();
         
         // Add a root TreeNode for each Customer object in the ArrayList.
         myEnum = customerArray->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Customer^ customer2 = safe_cast<Customer^>(myEnum->Current);
            treeView1->Nodes->Add( gcnew TreeNode( customer2->CustomerName ) );
            
            // Add a child treenode for each Order object in the current Customer object.
            IEnumerator^ myEnum = customer2->CustomerOrders->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               Order^ order1 = safe_cast<Order^>(myEnum->Current);
               treeView1->Nodes[ customerArray->IndexOf( customer2 ) ]->Nodes->Add( gcnew TreeNode( customer2->CustomerName + "." + order1->OrderID ) );
            }
         }
         
         // Reset the cursor to the default for all controls.
         ::Cursor::Current = Cursors::Default;
         
         // Begin repainting the TreeView.
         treeView1->EndUpdate();
      }