private:
   // Call this method from the InitializeComponent() method of your form
   void OtherInitialize()
   {
      this->Closing += gcnew CancelEventHandler( this, &Form1::Form1_Cancel );
      this->myDataIsSaved = true;
   }

   void Form1_Cancel( Object^ /*sender*/, CancelEventArgs^ e )
   {
      if ( !myDataIsSaved )
      {
         e->Cancel = true;
         MessageBox::Show( "You must save first." );
      }
      else
      {
         e->Cancel = false;
         MessageBox::Show( "Goodbye." );
      }
   }