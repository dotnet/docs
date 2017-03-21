internal:
   System::Windows::Forms::GroupBox^ GroupBox1;
   System::Windows::Forms::RadioButton^ RadioButton1;
   System::Windows::Forms::RadioButton^ RadioButton2;
   System::Windows::Forms::RadioButton^ RadioButton3;

private:
   void InitializeRadioButtonsAndGroupBox()
   {
      
      // Construct the GroupBox object.
      this->GroupBox1 = gcnew GroupBox;
      
      // Construct the radio buttons.
      this->RadioButton1 = gcnew System::Windows::Forms::RadioButton;
      this->RadioButton2 = gcnew System::Windows::Forms::RadioButton;
      this->RadioButton3 = gcnew System::Windows::Forms::RadioButton;
      
      // Set the location, tab and text for each radio button
      // to a cursor from the Cursors enumeration.
      this->RadioButton1->Location = System::Drawing::Point( 24, 24 );
      this->RadioButton1->TabIndex = 0;
      this->RadioButton1->Text = "Help";
      this->RadioButton1->Tag = Cursors::Help;
      this->RadioButton1->TextAlign = ContentAlignment::MiddleCenter;
      this->RadioButton2->Location = System::Drawing::Point( 24, 56 );
      this->RadioButton2->TabIndex = 1;
      this->RadioButton2->Text = "Up Arrow";
      this->RadioButton2->Tag = Cursors::UpArrow;
      this->RadioButton2->TextAlign = ContentAlignment::MiddleCenter;
      this->RadioButton3->Location = System::Drawing::Point( 24, 80 );
      this->RadioButton3->TabIndex = 3;
      this->RadioButton3->Text = "Cross";
      this->RadioButton3->Tag = Cursors::Cross;
      this->RadioButton3->TextAlign = ContentAlignment::MiddleCenter;
      
      // Add the radio buttons to the GroupBox.  
      this->GroupBox1->Controls->Add( this->RadioButton1 );
      this->GroupBox1->Controls->Add( this->RadioButton2 );
      this->GroupBox1->Controls->Add( this->RadioButton3 );
      
      // Set the location of the GroupBox. 
      this->GroupBox1->Location = System::Drawing::Point( 56, 64 );
      this->GroupBox1->Size = System::Drawing::Size( 200, 150 );
      
      // Set the text that will appear on the GroupBox.
      this->GroupBox1->Text = "Choose a Cursor Style";
      
      //
      // Add the GroupBox to the form.
      this->Controls->Add( this->GroupBox1 );
      
      //
   }