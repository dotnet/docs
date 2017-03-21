private:
   void MyForm_Layout( Object^ /*sender*/, System::Windows::Forms::LayoutEventArgs^ /*e*/ )
   {
      // Center the Form on the user's screen everytime it requires a Layout.
      this->SetBounds( (Screen::GetBounds( this ).Width / 2) - (this->Width / 2), (Screen::GetBounds( this ).Height / 2) - (this->Height / 2), this->Width, this->Height, BoundsSpecified::Location );
   }