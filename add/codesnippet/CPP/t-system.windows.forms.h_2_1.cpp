private:
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Add a text String* to the TextBox.
      textBox1->Text = "Hello World!";

      // Set the size of the TextBox.
      textBox1->AutoSize = false;
      textBox1->Size = System::Drawing::Size( Width, Height / 3 );

      // Align the text in the center of the control element.
      textBox1->TextAlign = HorizontalAlignment::Center;
   }