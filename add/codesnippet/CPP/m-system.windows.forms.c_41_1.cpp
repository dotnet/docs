      // Remove the first control in the collection.
   private:
      void removeAtButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( panel1->Controls->Count > 0 )
         {
            panel1->Controls->RemoveAt( 0 );
         }
      }