public:
   void CreateMyMenuItem()
   {
      // Create an instance of MenuItem with caption and an event handler
      MenuItem^ menuItem1 = gcnew MenuItem( "&New",gcnew System::EventHandler(
         this, &Form1::MenuItem1_Click ) );
   }

private:
   // This method is an event handler for menuItem1 to use when connecting its event handler.
   void MenuItem1_Click( Object^ sender, System::EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }