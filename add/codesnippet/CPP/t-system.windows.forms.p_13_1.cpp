public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   Form1()
   {
      // The initial constructor code goes here.

      PropertyGrid^ propertyGrid1 = gcnew PropertyGrid;
      propertyGrid1->CommandsVisibleIfAvailable = true;
      propertyGrid1->Location = Point( 10, 20 );
      propertyGrid1->Size = System::Drawing::Size( 400, 300 );
      propertyGrid1->TabIndex = 1;
      propertyGrid1->Text = "Property Grid";

      this->Controls->Add( propertyGrid1 );

      propertyGrid1->SelectedObject = textBox1;
   }