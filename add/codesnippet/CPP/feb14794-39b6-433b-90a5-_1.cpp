public:
   void CreateMyMenuItem()
   {
      // Create a MenuItem with caption, shortcut key, and an event handler
      // specified.
      MenuItem^ MenuItem1 = gcnew MenuItem( "&New",
         gcnew System::EventHandler( this, &Form1::MenuItem1_Click ), Shortcut::CtrlL );
   }

private:
   // The following method is an event handler for menuItem1 to use when
   // connecting the event handler.
   void MenuItem1_Click( Object^ sender, EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }