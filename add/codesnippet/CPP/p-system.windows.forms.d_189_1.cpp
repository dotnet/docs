public:
   MyClass()
   {
      // Create a new DateTimePicker
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      array<Control^>^ myClassControls = {dateTimePicker1};
      Controls->AddRange( myClassControls );
      MessageBox::Show( dateTimePicker1->Value.ToString() );

      dateTimePicker1->Value = DateTime::Now.AddDays( 1 );
      MessageBox::Show( dateTimePicker1->Value.ToString() );
   }