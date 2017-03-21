public:
   MyClass()
   {
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      array<Control^>^ myClassControls = {dateTimePicker1};
      Controls->AddRange( myClassControls );
      dateTimePicker1->CalendarMonthBackground = Color::Aqua;
   }