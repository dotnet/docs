   // This example component editor page type provides an example 
   // ComponentEditorPage implementation.
   private ref class ExampleComponentEditorPage: public System::Windows::Forms::Design::ComponentEditorPage
   {
   private:
      Label^ l1;
      Button^ b1;
      PropertyGrid^ pg1;

      // Base64-encoded serialized image data for the required component editor page icon.
      String^ icon;

   public:
      ExampleComponentEditorPage()
      {
         String^ temp = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuNTAwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABNTeXN0ZW0uRHJhd2luZy5JY29uAgAAAAhJY29uRGF0Y"
         "QhJY29uU2l6ZQcEAhNTeXN0ZW0uRHJhd2luZy5TaXplAgAAAAIAAAAJAwAAAAX8////E1N5c3RlbS5EcmF3aW5nLlNpemUCAAAABXdpZHRoBmhlaWdodAAACAgCAAAAAAAAAAAAAAAPAwAAAD4BAAACAAABAAEAEBAQAAAAAAAoAQAAFgAAACgAAAAQAAAAIA"
         "AAAAEABAAAAAAAgAAAAAAAAAAAAAAAEAAAABAAAAAAAAAAAACAAACAAAAAgIAAgAAAAIAAgADExAAAgICAAMDAwAA+iPcAY77gACh9kwD/AAAAndPoADpw6wD///8AAAAAAAAAAAAHd3d3d3d3d8IiIiIiIiLHKIiIiIiIiCco///////4Jyj5mfIvIvgnKPn"
         "p////+Cco+en7u7v4Jyj56f////gnKPmZ8i8i+Cco///////4JyiIiIiIiIgnJmZmZmZmZifCIiIiIiIiwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACw==";
         icon = temp;
         
         // Initialize the page, which inherits from Panel, and its controls.
         this->Size = System::Drawing::Size( 400, 250 );
         this->Icon = DeserializeIconFromBase64Text( icon );
         this->Text = "Example Page";
         b1 = gcnew Button;
         b1->Size = System::Drawing::Size( 200, 20 );
         b1->Location = Point(200,0);
         b1->Text = "Set a random background color";
         b1->Click += gcnew EventHandler( this, &ExampleComponentEditorPage::randomBackColor );
         this->Controls->Add( b1 );
         l1 = gcnew Label;
         l1->Size = System::Drawing::Size( 190, 20 );
         l1->Location = Point(4,2);
         l1->Text = "Example Component Editor Page";
         this->Controls->Add( l1 );
         pg1 = gcnew PropertyGrid;
         pg1->Size = System::Drawing::Size( 400, 280 );
         pg1->Location = Point(0,30);
         this->Controls->Add( pg1 );
      }

      // This method indicates that the Help button should be enabled for this 
      // component editor page.
      virtual bool SupportsHelp() override
      {
         return true;
      }

      // This method is called when the Help button for this component editor page is pressed.
      // This implementation uses the IHelpService to show the Help topic for a sample keyword.
   public:
      virtual void ShowHelp() override
      {
         // The GetSelectedComponent method of a ComponentEditorPage retrieves the
         // IComponent associated with the WindowsFormsComponentEditor.
         IComponent^ selectedComponent = this->GetSelectedComponent();

         // Retrieve the Site of the component, and return if null.
         ISite^ componentSite = selectedComponent->Site;
         if ( componentSite == nullptr )
                  return;

         // Acquire the IHelpService to display a help topic using a indexed keyword lookup.
         IHelpService^ helpService = dynamic_cast<IHelpService^>(componentSite->GetService( IHelpService::typeid ));
         if ( helpService != nullptr )
                  helpService->ShowHelpFromKeyword( "System.Windows.Forms.ComboBox" );
      }

   protected:

      // The LoadComponent method is raised when the ComponentEditorPage is displayed.
      virtual void LoadComponent() override
      {
         this->pg1->SelectedObject = this->Component;
      }

      // The SaveComponent method is raised when the WindowsFormsComponentEditor is closing 
      // or the current ComponentEditorPage is closing.
      virtual void SaveComponent() override {}

   private:

      // If the associated component is a Control, this method sets the BackColor to a random color.
      // This method is invoked by the button on this ComponentEditorPage.
      void randomBackColor( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( System::Windows::Forms::Control::typeid->IsAssignableFrom( this->::Component::GetType() ) )
         {
            // Sets the background color of the Control associated with the
            // WindowsFormsComponentEditor to a random color.
            Random^ rnd = gcnew Random;
            (dynamic_cast<System::Windows::Forms::Control^>(this->Component))->BackColor = Color::FromArgb( rnd->Next( 255 ), rnd->Next( 255 ), rnd->Next( 255 ) );
            pg1->Refresh();
         }
      }

      // This method can be used to retrieve an Icon from a block 
      // of Base64-encoded text.
      System::Drawing::Icon^ DeserializeIconFromBase64Text( String^ text )
      {
         System::Drawing::Icon^ img = nullptr;
         array<Byte>^memBytes = Convert::FromBase64String( text );
         IFormatter^ formatter = gcnew BinaryFormatter;
         MemoryStream^ stream = gcnew MemoryStream( memBytes );
         img = dynamic_cast<System::Drawing::Icon^>(formatter->Deserialize( stream ));
         stream->Close();
         return img;
      }
   };