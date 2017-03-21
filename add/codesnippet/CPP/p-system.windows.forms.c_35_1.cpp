   public:
      MyForm()
      {
         // Create a 'MyCheckBox' control and
         // display an image on it.
         MyCustomControls::MyCheckBox^ myCheckBox = gcnew MyCustomControls::MyCheckBox;
         myCheckBox->Location = Point(5,5);
         myCheckBox->Image = Image::FromFile( String::Concat( Application::CommonAppDataPath, "\\Preview.jpg" ) );
         
         // Set the AccessibleName property
         // since there is no Text displayed.
         myCheckBox->AccessibleName = "Preview";
         myCheckBox->AccessibleDescription = "A toggle button used to show the document preview.";
         this->Controls->Add( myCheckBox );
      }