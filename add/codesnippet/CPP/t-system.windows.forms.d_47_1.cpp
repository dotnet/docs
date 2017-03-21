internal:
   // Declare the DateTimePicker.
   System::Windows::Forms::DateTimePicker^ DateTimePicker1;

private:
   void InitializeDateTimePicker()
   {
      // Construct the DateTimePicker.
      this->DateTimePicker1 = gcnew System::Windows::Forms::DateTimePicker;
      
      //Set size and location.
      this->DateTimePicker1->Location = System::Drawing::Point( 40, 88 );
      this->DateTimePicker1->Size = System::Drawing::Size( 160, 21 );
      
      // Set the alignment of the drop-down MonthCalendar to right.
      this->DateTimePicker1->DropDownAlign = LeftRightAlignment::Right;
      
      // Set the Value property to 50 years before today.
      DateTimePicker1->Value = System::DateTime::Now.AddYears(  -50 );
      
      //Set a custom format containing the string "of the year"
      DateTimePicker1->Format = DateTimePickerFormat::Custom;
      DateTimePicker1->CustomFormat = "MMM dd, 'of the year' yyyy ";
      
      // Add the DateTimePicker to the form.
      this->Controls->Add( this->DateTimePicker1 );
   }