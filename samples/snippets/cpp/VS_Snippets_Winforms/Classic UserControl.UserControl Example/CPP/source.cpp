

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

namespace UserControls
{
   public ref class MyCustomerInfoUserControl: public System::Windows::Forms::UserControl
   {
   private:

      // Create the controls.
      System::Windows::Forms::ErrorProvider^ errorProvider1;
      System::Windows::Forms::TextBox^ textName;
      System::Windows::Forms::TextBox^ textAddress;
      System::Windows::Forms::TextBox^ textCity;
      System::Windows::Forms::TextBox^ textStateProvince;
      System::Windows::Forms::TextBox^ textPostal;
      System::Windows::Forms::TextBox^ textCountryRegion;
      System::Windows::Forms::TextBox^ textEmail;
      System::Windows::Forms::Label ^ labelName;
      System::Windows::Forms::Label ^ labelAddress;
      System::Windows::Forms::Label ^ labelCityStateProvincePostal;
      System::Windows::Forms::Label ^ labelCountryRegion;
      System::Windows::Forms::Label ^ labelEmail;
      System::ComponentModel::IContainer^ components;

   public:

      // Define the constructor.
      MyCustomerInfoUserControl()
      {
         InitializeComponent();
      }

      // Initialize the control elements.
      void InitializeComponent()
      {
         // Initialize the controls.
         components = gcnew System::ComponentModel::Container;
         errorProvider1 = gcnew System::Windows::Forms::ErrorProvider;
         textName = gcnew System::Windows::Forms::TextBox;
         textAddress = gcnew System::Windows::Forms::TextBox;
         textCity = gcnew System::Windows::Forms::TextBox;
         textStateProvince = gcnew System::Windows::Forms::TextBox;
         textPostal = gcnew System::Windows::Forms::TextBox;
         textCountryRegion = gcnew System::Windows::Forms::TextBox;
         textEmail = gcnew System::Windows::Forms::TextBox;
         labelName = gcnew System::Windows::Forms::Label;
         labelAddress = gcnew System::Windows::Forms::Label;
         labelCityStateProvincePostal = gcnew System::Windows::Forms::Label;
         labelCountryRegion = gcnew System::Windows::Forms::Label;
         labelEmail = gcnew System::Windows::Forms::Label;

         // Set the tab order, text alignment, size, and location of the controls.
         textName->Location = System::Drawing::Point( 120, 8 );
         textName->Size = System::Drawing::Size( 232, 20 );
         textName->TabIndex = 0;
         textAddress->Location = System::Drawing::Point( 120, 32 );
         textAddress->Size = System::Drawing::Size( 232, 20 );
         textAddress->TabIndex = 1;
         textCity->Location = System::Drawing::Point( 120, 56 );
         textCity->Size = System::Drawing::Size( 96, 20 );
         textCity->TabIndex = 2;
         textStateProvince->Location = System::Drawing::Point( 216, 56 );
         textStateProvince->Size = System::Drawing::Size( 56, 20 );
         textStateProvince->TabIndex = 3;
         textPostal->Location = System::Drawing::Point( 272, 56 );
         textPostal->Size = System::Drawing::Size( 80, 20 );
         textPostal->TabIndex = 4;
         textCountryRegion->Location = System::Drawing::Point( 120, 80 );
         textCountryRegion->Size = System::Drawing::Size( 232, 20 );
         textCountryRegion->TabIndex = 5;
         textEmail->Location = System::Drawing::Point( 120, 104 );
         textEmail->Size = System::Drawing::Size( 232, 20 );
         textEmail->TabIndex = 6;
         labelName->Location = System::Drawing::Point( 8, 8 );
         labelName->Size = System::Drawing::Size( 112, 23 );
         labelName->Text = "Name:";
         labelName->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
         labelAddress->Location = System::Drawing::Point( 8, 32 );
         labelAddress->Size = System::Drawing::Size( 112, 23 );
         labelAddress->Text = "Address:";
         labelAddress->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
         labelCityStateProvincePostal->Location = System::Drawing::Point( 8, 56 );
         labelCityStateProvincePostal->Size = System::Drawing::Size( 112, 23 );
         labelCityStateProvincePostal->Text = "City, St/Prov. Postal:";
         labelCityStateProvincePostal->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
         labelCountryRegion->Location = System::Drawing::Point( 8, 80 );
         labelCountryRegion->Size = System::Drawing::Size( 112, 23 );
         labelCountryRegion->Text = "Country/Region:";
         labelCountryRegion->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
         labelEmail->Location = System::Drawing::Point( 8, 104 );
         labelEmail->Size = System::Drawing::Size( 112, 23 );
         labelEmail->Text = "email:";
         labelEmail->TextAlign = System::Drawing::ContentAlignment::MiddleRight;

         // Add the Validating and Validated handlers for textEmail.
         textEmail->Validating += gcnew System::ComponentModel::CancelEventHandler( this, &MyCustomerInfoUserControl::textEmail_Validating );
         textEmail->Validated += gcnew System::EventHandler( this, &MyCustomerInfoUserControl::textEmail_Validated );

         // Add the controls to the user control.
         array<System::Windows::Forms::Control^>^temp0 = {labelName,labelAddress,labelCityStateProvincePostal,labelCountryRegion,labelEmail,textName,textAddress,textCity,textStateProvince,textPostal,textCountryRegion,textEmail};
         Controls->AddRange( temp0 );

         // Size the user control.
         Size = System::Drawing::Size( 375, 150 );
      }

   private:
      void MyValidatingCode()
      {
         // Confirm there is text in the control.
         if ( textEmail->Text->Length == 0 )
         {
            throw gcnew Exception( "Email address is a required field." );
         }
         // Confirm that there is a "." and an "@" in the e-mail address.
         else
         
         // Confirm that there is a "." and an "@" in the e-mail address.
         if ( textEmail->Text->IndexOf( "." ) == -1 || textEmail->Text->IndexOf( "@" ) == -1 )
         {
            throw gcnew Exception( "Email address must be valid e-mail address format.\nFor example: 'someone@example.com'" );
         }
      }

      // Validate the data input by the user into textEmail.
      void textEmail_Validating( Object^ /*sender*/, System::ComponentModel::CancelEventArgs^ e )
      {
         try
         {
            MyValidatingCode();
         }
         catch ( Exception^ ex ) 
         {
            // Cancel the event and select the text to be corrected by the user.
            e->Cancel = true;
            textEmail->Select(0,textEmail->Text->Length);
            
            // Set the ErrorProvider error with the text to display. 
            this->errorProvider1->SetError( textEmail, ex->Message );
         }

      }

      void textEmail_Validated( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         
         //If all conditions have been met, clear the error provider of errors.
         errorProvider1->SetError( textEmail, "" );
      }
   };
}

// End Class   
// End Namespace
//////////////////////////////////////////////////////////////////////////////////////
// <Snippet1>
public ref class MyUserControlHost: public System::Windows::Forms::Form
{
private:

   // Create the controls.
   System::ComponentModel::IContainer^ components;
   System::Windows::Forms::Panel^ panel1;
   UserControls::MyCustomerInfoUserControl^ myUserControl;

public:

   // Define the constructor.
   MyUserControlHost()
   {
      this->InitializeComponent();
   }


private:

   // Add a Panel control to a Form and host the UserControl in the Panel.
   void InitializeComponent()
   {
      components = gcnew System::ComponentModel::Container;
      panel1 = gcnew System::Windows::Forms::Panel;
      myUserControl = gcnew UserControls::MyCustomerInfoUserControl;
      
      // Set the DockStyle of the UserControl to Fill.
      myUserControl->Dock = System::Windows::Forms::DockStyle::Fill;
      
      // Make the Panel the same size as the UserControl and give it a border.
      panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      panel1->Size = myUserControl->Size;
      panel1->Location = System::Drawing::Point( 5, 5 );
      
      // Add the user control to the Panel.
      panel1->Controls->Add( myUserControl );
      
      // Size the Form to accommodate the Panel.
      this->ClientSize = System::Drawing::Size( panel1->Size.Width + 10, panel1->Size.Height + 10 );
      this->Text = "Please enter the information below...";
      
      // Add the Panel to the Form.
      this->Controls->Add( panel1 );
   }
};
// End Class

[System::STAThreadAttribute]
int main()
{
   System::Windows::Forms::Application::Run( gcnew MyUserControlHost );
}
// </Snippet1>
