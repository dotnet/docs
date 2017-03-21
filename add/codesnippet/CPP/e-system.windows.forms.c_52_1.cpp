   private:
      void Button_HideLabel( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myLabel->Visible = false;
      }

      void AddVisibleChangedEventHandler()
      {
         myLabel->VisibleChanged += gcnew EventHandler( this, &MyForm::Label_VisibleChanged );
      }

      void Label_VisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "Visible change event raised!!!" );
      }