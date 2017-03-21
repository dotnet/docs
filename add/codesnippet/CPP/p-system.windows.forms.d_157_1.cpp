private:
   void CallEventLoader()
   {
      this->Load += gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::DataGridTableStyle_RowHeaderWidth_Load );
   }

public:
   void AttachRowHeaderWidthChanged()
   {
      myDataGridTableStyle->RowHeaderWidthChanged +=
         gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::MyDelegateRowHeaderChanged );
   }

private:
   void MyDelegateRowHeaderChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Row header width is changed" );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->RowHeaderWidth = 30;
   }

   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "Row header width is: ", myDataGridTableStyle->RowHeaderWidth ) );
   }