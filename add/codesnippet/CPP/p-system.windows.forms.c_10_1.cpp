protected:
   property System::Drawing::Size DefaultSize 
   {
      virtual System::Drawing::Size get() override
      {
         // Set the default size of
         // the form to 500 pixels square.
         return System::Drawing::Size( 500, 500 );
      }
   }