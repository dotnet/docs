   // This method will adjust the size of the form to utilize 
   // the working area of the screen.
private:
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Retrieve the working rectangle from the Screen class
      // using the PrimaryScreen and the WorkingArea properties.
      System::Drawing::Rectangle workingRectangle = Screen::PrimaryScreen->WorkingArea;
      
      // Set the size of the form slightly less than size of 
      // working rectangle.
      this->Size = System::Drawing::Size( workingRectangle.Width - 10, workingRectangle.Height - 10 );
      
      // Set the location so the entire form is visible.
      this->Location = System::Drawing::Point( 5, 5 );
   }