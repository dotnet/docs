public:
   void SetMyCustomFormat()
   {
      // Set the Format type and the CustomFormat string.
      dateTimePicker1->Format = DateTimePickerFormat::Custom;
      dateTimePicker1->CustomFormat = "MMMM dd, yyyy - dddd";
   }