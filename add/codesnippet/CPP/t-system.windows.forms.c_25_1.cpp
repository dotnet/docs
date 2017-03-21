private:
   // Set the 'FixedHeight' and 'FixedWidth' styles to false.
   void MyForm_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      this->SetStyle( ControlStyles::FixedHeight, false );
      this->SetStyle( ControlStyles::FixedWidth, false );
   }

   void RegisterEventHandler()
   {
      this->StyleChanged += gcnew EventHandler( this, &MyForm::MyForm_StyleChanged );
   }

   // Handle the 'StyleChanged' event for the 'Form'.
   void MyForm_StyleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "The style releated to the 'Form' has been changed" );
   }