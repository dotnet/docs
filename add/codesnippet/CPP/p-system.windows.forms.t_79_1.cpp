   //Declare a textbox called TextBox1.
internal:
   System::Windows::Forms::TextBox^ TextBox1;

private:

   //Initialize TextBox1.
   void InitializeTextBox()
   {
      this->TextBox1 = gcnew TextBox;
      this->TextBox1->Location = System::Drawing::Point( 32, 24 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 136, 20 );
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Text = "Type and hit enter here...";
      
      //Keep the selection highlighted, even after textbox loses focus.
      TextBox1->HideSelection = false;
      this->Controls->Add( TextBox1 );
   }