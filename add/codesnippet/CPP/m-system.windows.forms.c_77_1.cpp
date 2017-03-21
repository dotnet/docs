   // The following example displays the location of the form in screen coordinates
   // on the caption bar of the form.
private:
   void Form1_Move( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->Text = String::Format( "Form screen position = {0}", this->Location );
   }