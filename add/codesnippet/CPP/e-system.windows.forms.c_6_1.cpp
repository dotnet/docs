   private:
      void AddContextMenuChangedHandler()
      {
         this->myTextBox->ContextMenuChanged += gcnew EventHandler( this, &MyForm::TextBox_ContextMenuChanged );
      }

      void TextBox_ContextMenuChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( L"Shortcut menu of TextBox is changed." );
      }