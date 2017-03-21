      void AboutDialog_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Display the application information in the label.
         this->labelVersionInfo->Text = String::Format(  "{0} {1} Version: {2}", this->CompanyName, this->ProductName, this->ProductVersion );
      }