      // Remove the RadioButton control if it exists.
   private:
      void removeButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( panel1->Controls->Contains( removeButton ) )
         {
            panel1->Controls->Remove( removeButton );
         }
      }