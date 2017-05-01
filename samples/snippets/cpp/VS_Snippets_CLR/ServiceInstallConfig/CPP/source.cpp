#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Management.dll>
#using <System.ServiceProcess.dll>
#using <System.Configuration.Install.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Data;
using namespace System::Globalization;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;
using namespace System::ServiceProcess;
using namespace System::ServiceProcess::Design;
using namespace System::Management;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class ServiceChange
{
public:

   // Define the console application entry point.

   [STAThread]
   static void ConsoleTestMain()
   {
      ServiceController^ sc = gcnew ServiceController;
      Console::WriteLine( "Query by service name or display name [S|D]:" );
      String^ inputText = Console::ReadLine()->ToUpper( CultureInfo::InvariantCulture );
      String^ serviceInput = "";
      if ( inputText->Equals( "S" ) )
      {
         Console::WriteLine( "Enter the service name:" );
         serviceInput = Console::ReadLine()->ToLower();
         if ( serviceInput->Length > 0 )
         {
            sc->ServiceName = serviceInput;
         }
      }

      if ( inputText->Equals( "D" ) )
      {
         Console::WriteLine( "Enter the service display name:" );
         serviceInput = Console::ReadLine();
         if ( serviceInput->Length > 0 )
         {
            sc->DisplayName = serviceInput;
         }
      }
      else
      {
         // Quit if input was any other key.
      }

      String^ scInfo;
      if ( QueryService(  &sc,  &scInfo ) )
      {
         Console::WriteLine( scInfo );
         Console::WriteLine( "Would you like to change the service start mode [Y|N]:" );
         inputText = Console::ReadLine()->ToUpper( CultureInfo::InvariantCulture );
         if ( inputText->Equals( "Y" ) )
         {
            Console::WriteLine( "Enter the new start mode [Auto|Manual|Disabled]:" );
            serviceInput = Console::ReadLine()->ToUpper( CultureInfo::InvariantCulture );
            if ( serviceInput->Length > 0 )
            {
               ChangeServiceStartMode(  &sc, serviceInput,  &scInfo );
            }
         }
      }
   }

   static bool QueryService( interior_ptr<ServiceController^> sc, [Out]interior_ptr<String^> scInfo )
   {
      bool serviceValid = false;
       *scInfo = "";
      try
      {
         if ( (( *sc)->ServiceName->Length > 0) || (( *sc)->DisplayName->Length > 0) )
         {
            ( *sc)->Refresh();
            
            // Display information about this service.
             *scInfo = String::Concat( String::Concat(  *scInfo, Environment::NewLine ), String::Concat( "Service name:\t", ( *sc)->ServiceName, Environment::NewLine ), String::Concat( "Display name:\t", ( *sc)->DisplayName, Environment::NewLine ), String::Concat( "Service type:\t", ( *sc)->ServiceType, Environment::NewLine ), String::Concat( "Status:\t\t", ( *sc)->Status, Environment::NewLine ) );
            serviceValid = true;
            
            // Query WMI for additional information about this service.
            ManagementObject^ wmiService;
            wmiService = gcnew ManagementObject( String::Format( "Win32_Service.Name='{0}'", ( *sc)->ServiceName ) );
            wmiService->Get();
             *scInfo = String::Concat(  *scInfo, String::Concat( "Start name:\t", wmiService[ "StartName" ], Environment::NewLine ), String::Concat( "Start mode:\t", wmiService[ "StartMode" ], Environment::NewLine ), String::Concat( "Service path:\t", wmiService[ "PathName" ], Environment::NewLine ), String::Concat( "Description:\t", wmiService[ "Description" ], Environment::NewLine ) );
         }
      }
      catch ( InvalidOperationException^ ) 
      {
         serviceValid = false;
          *scInfo = "";
      }

      return serviceValid;
   }

   static bool ChangeServiceStartMode( interior_ptr<ServiceController^> sc, String^ startMode, [Out]interior_ptr<String^> scInfo )
   {
      bool startModeChanged = false;
      ManagementObject^ wmiService;
      wmiService = gcnew ManagementObject( String::Format( "Win32_Service.Name='{0}'", ( *sc)->ServiceName ) );
      wmiService->Get();
      String^ origStartMode = wmiService[ "StartMode" ]->ToString();
       *scInfo = "";
      startMode = startMode->ToUpper( CultureInfo::InvariantCulture );
      if ( startMode->Equals( "AUTO" ) || startMode->Equals( "MANUAL" ) || startMode->Equals( "DISABLED" ) )
      {
         if ( startMode->Equals( origStartMode->ToUpper( CultureInfo::InvariantCulture ) ) )
         {
             *scInfo = String::Format( "{0}Requested mode is the same as the current mode; no change necessary.{1}",  *scInfo, Environment::NewLine );
         }
         else
         {
            // Change the start mode to requested value.
             *scInfo = String::Format( "{0}Setting service start mode to {1}...{2}",  *scInfo, startMode, Environment::NewLine );

            // See Win32_Service schema for ChangeStartMode input values.
            array<String^>^startArgs = {startMode};
            Object^ retVal;
            retVal = wmiService->InvokeMethod( "ChangeStartMode", startArgs );
            if (  !retVal->ToString()->Equals( "0" ) )
            {
                *scInfo = String::Format( "{0}Warning:  Win32_Service.ChangeStartMode failed with return value {1}{2}",  *scInfo, retVal->ToString(), Environment::NewLine );
            }
            else
            {
                *scInfo = String::Concat( String::Format( "{0}Service {1} start mode changed to {2}{3}",  *scInfo, ( *sc)->ServiceName, startMode ), Environment::NewLine );
            }
         }
      }
      else
      {
          *scInfo = String::Format( "{0}Invalid start mode.{1}",  *scInfo, Environment::NewLine );
      }

      return startModeChanged;
   }

   //<Snippet1>
   // Prompt the user for service installation account values.
public:
   static bool GetServiceAccount( interior_ptr<ServiceProcessInstaller^> svcInst )
   {
      bool accountSet = false;
      ServiceInstallerDialog^ svcDialog = gcnew ServiceInstallerDialog;

      // Query the user for the service account type.
      do
      {
         svcDialog->TopMost = true;
         svcDialog->ShowDialog();
         if ( svcDialog->Result == ServiceInstallerDialogResult::OK )
         {
            // Do a very simple validation on the user
            // input.  Check to see whether the user name
            // or password is blank.
            if ( (svcDialog->Username->Length > 0) && (svcDialog->Password->Length > 0) )
            {
               // Use the account and password.
               accountSet = true;
               ( *svcInst)->Account = ServiceAccount::User;
               ( *svcInst)->Username = svcDialog->Username;
               ( *svcInst)->Password = svcDialog->Password;
            }
         }
         else
         if ( svcDialog->Result == ServiceInstallerDialogResult::UseSystem )
         {
            ( *svcInst)->Account = ServiceAccount::LocalSystem;
            ( *svcInst)->Username = nullptr;
            ( *svcInst)->Password = nullptr;
            accountSet = true;
         }

         if (  !accountSet )
         {
            // Display a message box.  Tell the user to
            // enter a valid user and password, or cancel
            // out to leave the service account alone.
            DialogResult result;
            result = MessageBox::Show( "Invalid user name or password for service installation."
                  "  Press Cancel to leave the service account unchanged.", "Change Service Account", 
                  MessageBoxButtons::OKCancel, MessageBoxIcon::Hand );
            if ( result == DialogResult::Cancel )
            {
               // Break out of loop.
               break;
            }
         }
      }
      while (  !accountSet );

      return accountSet;
   }
   //</Snippet1>
};

public ref class ServiceSampleForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ query_button;
   System::Windows::Forms::Button^ startMode_button;
   System::Windows::Forms::Button^ changeMode_button;
   System::Windows::Forms::Button^ startName_button;
   System::Windows::Forms::TextBox^ textBox;
   System::Windows::Forms::Label ^ modeLabel;
   System::Windows::Forms::ComboBox^ modeComboBox;
   ServiceController^ currentService;
   void query_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      textBox->Text = "Querying service configuration...";
      String^ scInfo;
      currentService->DisplayName = "TelNet";
      if ( ServiceChange::QueryService(  &currentService,  &scInfo ) )
      {
         textBox->Text = scInfo;
         this->startName_button->Enabled = true;
         this->startMode_button->Enabled = true;
         this->modeLabel->Visible = true;
         this->modeComboBox->Visible = true;
      }
      else
      {
         textBox->Text = "Could not read configuration information for service.";
      }
   }

   void startMode_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      String^ scInfo;
      String^ wmiStartMode = "";
      if ( this->modeComboBox->SelectedItem->ToString()->Equals( "Automatic" ) )
      {
         wmiStartMode = "Auto";
      }
      else
      if ( this->modeComboBox->SelectedItem->ToString()->Equals( "Manual" ) )
      {
         wmiStartMode = "Manual";
      }
      else
      if ( this->modeComboBox->SelectedItem->ToString()->Equals( "Disabled" ) )
      {
         wmiStartMode = "Disabled";
      }

      if ( ServiceChange::ChangeServiceStartMode(  &currentService, wmiStartMode,  &scInfo ) )
      {
         textBox->Text = "Service start mode updated successfully.";
      }
      else
      {
         textBox->Text = scInfo;
      }
   }

   void startName_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ServiceProcessInstaller^ svcProcInst = gcnew ServiceProcessInstaller;
      textBox->Text = "Displaying service installer dialog...";
      if ( ServiceChange::GetServiceAccount(  &svcProcInst ) )
      {
         textBox->Text = "Changing the service account is not currently implemented in this application.";
      }
      else
      {
         textBox->Text = "No change made to service account.";
      }

      String^ scInfo;
      if ( ServiceChange::QueryService(  &currentService,  &scInfo ) )
      {
         textBox->Text = String::Concat( textBox->Text, Environment::NewLine, scInfo );
      }
   }


public:
   ServiceSampleForm()
   {
      query_button = gcnew System::Windows::Forms::Button;
      startMode_button = gcnew System::Windows::Forms::Button;
      changeMode_button = gcnew System::Windows::Forms::Button;
      startName_button = gcnew System::Windows::Forms::Button;
      textBox = gcnew System::Windows::Forms::TextBox;
      modeLabel = gcnew System::Windows::Forms::Label;
      modeComboBox = gcnew System::Windows::Forms::ComboBox;
      currentService = gcnew ServiceController;
      this->SuspendLayout();

      // Set properties for query_button. 
      this->query_button->Enabled = true;
      this->query_button->Location = System::Drawing::Point( 8, 16 );
      this->query_button->Name = "query_button";
      this->query_button->Size = System::Drawing::Size( 124, 30 );
      this->query_button->Text = "Query Service";
      this->query_button->Click += gcnew System::EventHandler( this, &ServiceSampleForm::query_button_Click );

      // Set properties for startMode_button.
      this->startMode_button->Enabled = false;
      this->startMode_button->Location = System::Drawing::Point( 264, 16 );
      this->startMode_button->Name = "startMode_button";
      this->startMode_button->Size = System::Drawing::Size( 124, 30 );
      this->startMode_button->Text = "Change Service Start Mode";
      this->startMode_button->Click += gcnew System::EventHandler( this, &ServiceSampleForm::startMode_button_Click );

      // Set properties for modeLabel
      this->modeLabel->Location = System::Drawing::Point( 395, 20 );
      this->modeLabel->Size = System::Drawing::Size( 180, 22 );
      this->modeLabel->Text = "Select a service mode:";
      this->modeLabel->Visible = false;

      // Set properties for modeComboBox
      this->modeComboBox->Location = System::Drawing::Point( 560, 16 );
      this->modeComboBox->Size = System::Drawing::Size( 190, 23 );
      this->modeComboBox->Name = "modeComboBox";
      array<String^>^temp0 = {"Automatic","Manual","Disabled"};
      this->modeComboBox->Items->AddRange( temp0 );
      this->modeComboBox->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right | System::Windows::Forms::AnchorStyles::Top);
      this->modeComboBox->SelectedIndex = 0;
      this->modeComboBox->Visible = false;

      // Set properties for startName_button.
      this->startName_button->Enabled = false;
      this->startName_button->Location = System::Drawing::Point( 136, 16 );
      this->startName_button->Name = "startName_button";
      this->startName_button->Size = System::Drawing::Size( 124, 30 );
      this->startName_button->Text = "Change Service Account";
      this->startName_button->Click += gcnew System::EventHandler( this, &ServiceSampleForm::startName_button_Click );

      // Set properties for textBox.        
      this->textBox->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->textBox->Location = System::Drawing::Point( 8, 48 );
      this->textBox->Multiline = true;
      this->textBox->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
      this->textBox->Name = "textBox";
      this->textBox->Size = System::Drawing::Size( 744, 280 );
      this->textBox->Text = "";

      // Set properties for the ServiceSampleForm.
      this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
      this->ClientSize = System::Drawing::Size( 768, 340 );
      this->MinimumSize = System::Drawing::Size( 750, 340 );
      array<System::Windows::Forms::Control^>^temp1 = {this->textBox,this->query_button,this->startMode_button,this->startName_button,this->modeComboBox,this->modeLabel};
      this->Controls->AddRange( temp1 );
      this->Name = "ServiceSampleForm";
      this->Text = "Query and Change Service Configuration";
      this->ResumeLayout( false );
   }

public:
   ~ServiceSampleForm()
   {
   }
};

// Define the windows application entry point.

[STAThread]
int main()
{
   Application::Run( gcnew ServiceSampleForm );
}
