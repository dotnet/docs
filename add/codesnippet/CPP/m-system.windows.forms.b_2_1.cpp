      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         try
         {
            // Get the 'BindingManagerBase' Object*.
            BindingManagerBase^ myBindingManagerBase = BindingContext[ myDataTable ];

            // Remove the selected row from the grid.
            myBindingManagerBase->RemoveAt( myBindingManagerBase->Position );
         }
         catch ( Exception^ ex ) 
         {
            MessageBox::Show( ex->Source );
            MessageBox::Show( ex->Message );
         }
      }