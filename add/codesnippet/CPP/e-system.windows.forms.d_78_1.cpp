public:
   void AttachSelectionBackColorChanged()
   {
      // Handle the 'SelectionBackColorChanged' event.
      myGridTableStyle->SelectionBackColorChanged += gcnew EventHandler( this, &MyForm::MyDataGrid_SelectedBackColorChanged );
   }

private:
   void MyDataGrid_SelectedBackColorChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "SelectionBackColorChanged event was raised, Color changed to " + myGridTableStyle->SelectionBackColor );
   }