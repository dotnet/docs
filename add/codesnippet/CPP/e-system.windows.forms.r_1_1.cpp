private:
   void Link_Clicked( Object^ sender, System::Windows::Forms::LinkClickedEventArgs^ e )
   {
      System::Diagnostics::Process::Start( e->LinkText );
   }