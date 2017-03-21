   // Instantiate the EventHandler.
public:
   void AttachRowHeaderVisibleChanged()
   {
      myDataGridTableStyle->RowHeadersVisibleChanged += gcnew EventHandler( this, &MyDataGridTableStyle_RowHeadersVisibleChanged::MyDelegateRowHeadersVisibleChanged );
   }

   // raise the event when RowHeadersVisible property is changed.
private:
   void MyDelegateRowHeadersVisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myString = "'RowHeadersVisibleChanged' event raised, Row Headers are";
      if ( myDataGridTableStyle->RowHeadersVisible )
            myString = String::Concat( myString, " visible" );
      else
            myString = String::Concat( myString, " not visible" );

      MessageBox::Show( myString, "RowHeader information" );
   }

   // raise the event when a button is clicked.
   void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( myDataGridTableStyle->RowHeadersVisible )
            myDataGridTableStyle->RowHeadersVisible = false;
      else
            myDataGridTableStyle->RowHeadersVisible = true;
   }