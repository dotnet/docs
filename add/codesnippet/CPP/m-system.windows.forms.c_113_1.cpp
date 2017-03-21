private:
   void dataGrid1_KeyUp( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      if ( e->KeyCode == Keys::Enter )
      {
         
         // Enter key pressed.
         CurrencyManager^ gridCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[dataGrid1->DataSource, dataGrid1->DataMember]);
         gridCurrencyManager->EndCurrentEdit();
         MessageBox::Show( "End Edit" );
      }
   }