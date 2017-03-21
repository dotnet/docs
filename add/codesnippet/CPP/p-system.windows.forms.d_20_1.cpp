public:
   void CreateMyDateTimePicker()
   {
      // Create a new DateTimePicker control and initialize it.
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      
      // Set the MinDate and MaxDate.
      dateTimePicker1->MinDate = DateTime(1985,6,20);
      dateTimePicker1->MaxDate = DateTime::Today;
      
      // Set the CustomFormat string.
      dateTimePicker1->CustomFormat = "MMMM dd, yyyy - dddd";
      dateTimePicker1->Format = DateTimePickerFormat::Custom;
      
      // Show the CheckBox and display the control as an up-down control.
      dateTimePicker1->ShowCheckBox = true;
      dateTimePicker1->ShowUpDown = true;
   }