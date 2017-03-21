public:
   MyClass()
   {
      // Create a new DateTimePicker.
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      array<Control^>^ myClassControls = {dateTimePicker1};
      Controls->AddRange( myClassControls );
      dateTimePicker1->CalendarFont = gcnew System::Drawing::Font(
         "Courier New", 8.25F, FontStyle::Italic, GraphicsUnit::Point, ((Byte)(0)) );
   }