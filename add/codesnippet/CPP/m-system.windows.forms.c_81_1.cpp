private:
   void dataGrid1_KeyUp( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      if ( e->KeyCode == System::Windows::Forms::Keys::Escape )
      {
         
         // Escape key pressed.
         CurrencyManager^ gridCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[dataGrid1->DataSource, dataGrid1->DataMember]);
         gridCurrencyManager->CancelCurrentEdit();
         MessageBox::Show( "Escape!" );
      }
   }
