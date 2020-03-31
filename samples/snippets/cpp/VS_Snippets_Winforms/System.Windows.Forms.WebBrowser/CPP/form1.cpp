

//<Snippet0>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Security::Permissions;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }


private:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::MainMenu^ MainMenu1;
   System::Windows::Forms::MenuItem^ MenuItemFile;
   System::Windows::Forms::MenuItem^ MenuItemFileSaveAs;
   System::Windows::Forms::MenuItem^ MenuItemFilePageSetup;
   System::Windows::Forms::MenuItem^ MenuItemFilePrint;
   System::Windows::Forms::MenuItem^ MenuItemFilePrintPreview;
   System::Windows::Forms::MenuItem^ MenuItemFileProperties;
   System::Windows::Forms::TextBox^ TextBoxAddress;
   System::Windows::Forms::Button^ ButtonGo;
   System::Windows::Forms::Button^ backButton;
   System::Windows::Forms::Button^ ButtonForward;
   System::Windows::Forms::Button^ ButtonStop;
   System::Windows::Forms::Button^ ButtonRefresh;
   System::Windows::Forms::Button^ ButtonHome;
   System::Windows::Forms::Button^ ButtonSearch;
   System::Windows::Forms::Panel^ Panel1;
   System::Windows::Forms::WebBrowser ^ WebBrowser1;
   System::Windows::Forms::StatusBar^ StatusBar1;
   System::Windows::Forms::MenuItem^ MenuItem1;
   System::Windows::Forms::MenuItem^ MenuItem2;
   System::Windows::Forms::Button^ ButtonPrint;

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   void InitializeComponent()
   {
      this->MainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->MenuItemFile = gcnew System::Windows::Forms::MenuItem;
      this->MenuItemFileSaveAs = gcnew System::Windows::Forms::MenuItem;
      this->MenuItem1 = gcnew System::Windows::Forms::MenuItem;
      this->MenuItemFilePageSetup = gcnew System::Windows::Forms::MenuItem;
      this->MenuItemFilePrint = gcnew System::Windows::Forms::MenuItem;
      this->MenuItemFilePrintPreview = gcnew System::Windows::Forms::MenuItem;
      this->MenuItem2 = gcnew System::Windows::Forms::MenuItem;
      this->MenuItemFileProperties = gcnew System::Windows::Forms::MenuItem;
      this->TextBoxAddress = gcnew System::Windows::Forms::TextBox;
      this->ButtonGo = gcnew System::Windows::Forms::Button;
      this->backButton = gcnew System::Windows::Forms::Button;
      this->ButtonForward = gcnew System::Windows::Forms::Button;
      this->ButtonStop = gcnew System::Windows::Forms::Button;
      this->ButtonRefresh = gcnew System::Windows::Forms::Button;
      this->ButtonHome = gcnew System::Windows::Forms::Button;
      this->ButtonSearch = gcnew System::Windows::Forms::Button;
      this->ButtonPrint = gcnew System::Windows::Forms::Button;
      this->Panel1 = gcnew System::Windows::Forms::Panel;
      this->WebBrowser1 = gcnew System::Windows::Forms::WebBrowser;
      this->StatusBar1 = gcnew System::Windows::Forms::StatusBar;
      this->Panel1->SuspendLayout();
      this->SuspendLayout();

      // 
      // MainMenu1
      // 
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->MenuItemFile};
      this->MainMenu1->MenuItems->AddRange( temp0 );
      this->MainMenu1->Name = "MainMenu1";

      // 
      // MenuItemFile
      // 
      this->MenuItemFile->Index = 0;
      array<System::Windows::Forms::MenuItem^>^temp1 = {this->MenuItemFileSaveAs,this->MenuItem1,this->MenuItemFilePageSetup,this->MenuItemFilePrint,this->MenuItemFilePrintPreview,this->MenuItem2,this->MenuItemFileProperties};
      this->MenuItemFile->MenuItems->AddRange( temp1 );
      this->MenuItemFile->Name = "MenuItemFile";
      this->MenuItemFile->Text = "&File";

      // 
      // MenuItemFileSaveAs
      // 
      this->MenuItemFileSaveAs->Index = 0;
      this->MenuItemFileSaveAs->Name = "MenuItemFileSaveAs";
      this->MenuItemFileSaveAs->Text = " Save &As";
      this->MenuItemFileSaveAs->Click += gcnew System::EventHandler( this, &Form1::MenuItemFileSaveAs_Click );

      // 
      // MenuItem1
      // 
      this->MenuItem1->Index = 1;
      this->MenuItem1->Name = "MenuItem1";
      this->MenuItem1->Text = "-";

      // 
      // MenuItemFilePageSetup
      // 
      this->MenuItemFilePageSetup->Index = 2;
      this->MenuItemFilePageSetup->Name = "MenuItemFilePageSetup";
      this->MenuItemFilePageSetup->Text = "Page Set&up...";
      this->MenuItemFilePageSetup->Click += gcnew System::EventHandler( this, &Form1::MenuItemFilePageSetup_Click );

      // 
      // MenuItemFilePrint
      // 
      this->MenuItemFilePrint->Index = 3;
      this->MenuItemFilePrint->Name = "MenuItemFilePrint";
      this->MenuItemFilePrint->Text = "&Print...";
      this->MenuItemFilePrint->Click += gcnew System::EventHandler( this, &Form1::MenuItemFilePrint_Click );

      // 
      // MenuItemFilePrintPreview
      // 
      this->MenuItemFilePrintPreview->Index = 4;
      this->MenuItemFilePrintPreview->Name = "MenuItemFilePrintPreview";
      this->MenuItemFilePrintPreview->Text = "Print Pre&view...";
      this->MenuItemFilePrintPreview->Click += gcnew System::EventHandler( this, &Form1::MenuItemFilePrintPreview_Click );

      // 
      // MenuItem2
      // 
      this->MenuItem2->Index = 5;
      this->MenuItem2->Name = "MenuItem2";
      this->MenuItem2->Text = "-";

      // 
      // MenuItemFileProperties
      // 
      this->MenuItemFileProperties->Index = 6;
      this->MenuItemFileProperties->Name = "MenuItemFileProperties";
      this->MenuItemFileProperties->Text = "P&roperties";
      this->MenuItemFileProperties->Click += gcnew System::EventHandler( this, &Form1::MenuItemFileProperties_Click );

      // 
      // TextBoxAddress
      // 
      this->TextBoxAddress->Location = System::Drawing::Point( 0, 0 );
      this->TextBoxAddress->Name = "TextBoxAddress";
      this->TextBoxAddress->Size = System::Drawing::Size( 240, 20 );
      this->TextBoxAddress->TabIndex = 1;
      this->TextBoxAddress->Text = "";
      this->TextBoxAddress->KeyDown += gcnew System::Windows::Forms::KeyEventHandler( this, &Form1::TextBoxAddress_KeyDown );

      // 
      // ButtonGo
      // 
      this->ButtonGo->Location = System::Drawing::Point( 240, 0 );
      this->ButtonGo->Name = "ButtonGo";
      this->ButtonGo->Size = System::Drawing::Size( 48, 24 );
      this->ButtonGo->TabIndex = 2;
      this->ButtonGo->Text = "Go";
      this->ButtonGo->Click += gcnew System::EventHandler( this, &Form1::ButtonGo_Click );

      // 
      // backButton
      // 
      this->backButton->Location = System::Drawing::Point( 288, 0 );
      this->backButton->Name = "backButton";
      this->backButton->Size = System::Drawing::Size( 48, 24 );
      this->backButton->TabIndex = 3;
      this->backButton->Text = "Back";
      this->backButton->Click += gcnew System::EventHandler( this, &Form1::backButton_Click );

      // 
      // ButtonForward
      // 
      this->ButtonForward->Location = System::Drawing::Point( 336, 0 );
      this->ButtonForward->Name = "ButtonForward";
      this->ButtonForward->Size = System::Drawing::Size( 48, 24 );
      this->ButtonForward->TabIndex = 4;
      this->ButtonForward->Text = "Forward";
      this->ButtonForward->Click += gcnew System::EventHandler( this, &Form1::ButtonForward_Click );

      // 
      // ButtonStop
      // 
      this->ButtonStop->Location = System::Drawing::Point( 384, 0 );
      this->ButtonStop->Name = "ButtonStop";
      this->ButtonStop->Size = System::Drawing::Size( 48, 24 );
      this->ButtonStop->TabIndex = 5;
      this->ButtonStop->Text = "Stop";
      this->ButtonStop->Click += gcnew System::EventHandler( this, &Form1::ButtonStop_Click );

      // 
      // ButtonRefresh
      // 
      this->ButtonRefresh->Location = System::Drawing::Point( 432, 0 );
      this->ButtonRefresh->Name = "ButtonRefresh";
      this->ButtonRefresh->Size = System::Drawing::Size( 48, 24 );
      this->ButtonRefresh->TabIndex = 6;
      this->ButtonRefresh->Text = "Refresh";
      this->ButtonRefresh->Click += gcnew System::EventHandler( this, &Form1::ButtonRefresh_Click );

      // 
      // ButtonHome
      // 
      this->ButtonHome->Location = System::Drawing::Point( 480, 0 );
      this->ButtonHome->Name = "ButtonHome";
      this->ButtonHome->Size = System::Drawing::Size( 48, 24 );
      this->ButtonHome->TabIndex = 7;
      this->ButtonHome->Text = "Home";
      this->ButtonHome->Click += gcnew System::EventHandler( this, &Form1::ButtonHome_Click );

      // 
      // ButtonSearch
      // 
      this->ButtonSearch->Location = System::Drawing::Point( 528, 0 );
      this->ButtonSearch->Name = "ButtonSearch";
      this->ButtonSearch->Size = System::Drawing::Size( 48, 24 );
      this->ButtonSearch->TabIndex = 8;
      this->ButtonSearch->Text = "Search";
      this->ButtonSearch->Click += gcnew System::EventHandler( this, &Form1::ButtonSearch_Click );

      // 
      // ButtonPrint
      // 
      this->ButtonPrint->Location = System::Drawing::Point( 576, 0 );
      this->ButtonPrint->Name = "ButtonPrint";
      this->ButtonPrint->Size = System::Drawing::Size( 48, 24 );
      this->ButtonPrint->TabIndex = 9;
      this->ButtonPrint->Text = "Print";
      this->ButtonPrint->Click += gcnew System::EventHandler( this, &Form1::ButtonPrint_Click );

      // 
      // Panel1
      // 
      this->Panel1->Controls->Add( this->ButtonPrint );
      this->Panel1->Controls->Add( this->TextBoxAddress );
      this->Panel1->Controls->Add( this->ButtonGo );
      this->Panel1->Controls->Add( this->backButton );
      this->Panel1->Controls->Add( this->ButtonForward );
      this->Panel1->Controls->Add( this->ButtonStop );
      this->Panel1->Controls->Add( this->ButtonRefresh );
      this->Panel1->Controls->Add( this->ButtonHome );
      this->Panel1->Controls->Add( this->ButtonSearch );
      this->Panel1->Dock = System::Windows::Forms::DockStyle::Top;
      this->Panel1->Location = System::Drawing::Point( 0, 0 );
      this->Panel1->Name = "Panel1";
      this->Panel1->Size = System::Drawing::Size( 624, 24 );
      this->Panel1->TabIndex = 11;

      // 
      // WebBrowser1
      // 
      //<Snippet17>
      this->WebBrowser1->AllowWebBrowserDrop = false;
      this->WebBrowser1->ScriptErrorsSuppressed = true;
      this->WebBrowser1->WebBrowserShortcutsEnabled = false;
      this->WebBrowser1->Dock = System::Windows::Forms::DockStyle::Fill;
      this->WebBrowser1->IsWebBrowserContextMenuEnabled = false;

      //</Snippet17>
      this->WebBrowser1->Location = System::Drawing::Point( 0, 24 );
      this->WebBrowser1->Name = "WebBrowser1";
      this->WebBrowser1->Size = System::Drawing::Size( 624, 389 );
      this->WebBrowser1->TabIndex = 10;
      this->WebBrowser1->StatusTextChanged += gcnew System::EventHandler( this, &Form1::WebBrowser1_StatusTextChanged );
      this->WebBrowser1->CanGoBackChanged += gcnew System::EventHandler( this, &Form1::WebBrowser1_CanGoBackChanged );
      this->WebBrowser1->Navigated += gcnew System::Windows::Forms::WebBrowserNavigatedEventHandler( this, &Form1::WebBrowser1_Navigated );
      this->WebBrowser1->CanGoForwardChanged += gcnew System::EventHandler( this, &Form1::WebBrowser1_CanGoForwardChanged );
      this->WebBrowser1->DocumentTitleChanged += gcnew System::EventHandler( this, &Form1::WebBrowser1_DocumentTitleChanged );

      // 
      // StatusBar1
      // 
      this->StatusBar1->Location = System::Drawing::Point( 0, 413 );
      this->StatusBar1->Name = "StatusBar1";
      this->StatusBar1->Size = System::Drawing::Size( 624, 16 );
      this->StatusBar1->TabIndex = 12;

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 624, 429 );
      this->Controls->Add( this->WebBrowser1 );
      this->Controls->Add( this->Panel1 );
      this->Controls->Add( this->StatusBar1 );
      this->Menu = this->MainMenu1;
      this->Name = "Form1";
      this->Text = "WebBrowser Example";
      this->Panel1->ResumeLayout( false );
      this->ResumeLayout( false );
   }


internal:

   static property Form1^ GetInstance 
   {
      Form1^ get()
      {
         if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
         {
            System::Threading::Monitor::Enter( Form1::typeid );
            try
            {
               if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
               {
                  m_DefaultInstance = gcnew Form1;
               }
            }
            finally
            {
               System::Threading::Monitor::Exit( Form1::typeid );
            }
         }

         return m_DefaultInstance;
      }
   }

private:
   static Form1^ m_DefaultInstance;

   //<Snippet1>
   // Displays the Save dialog box.
   void MenuItemFileSaveAs_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->ShowSaveAsDialog();
   }

   //</Snippet1>
   //<Snippet2>
   // Displays the Page Setup dialog box.
   void MenuItemFilePageSetup_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->ShowPageSetupDialog();
   }
   //</Snippet2>

   //<Snippet3>
   // Displays the Print dialog box.
   void MenuItemFilePrint_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->ShowPrintDialog();
   }
   //</Snippet3>

   //<Snippet4>
   // Displays the Print Preview dialog box.
   void MenuItemFilePrintPreview_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->ShowPrintPreviewDialog();
   }
   //</Snippet4>

   //<Snippet5>
   // Displays the Properties dialog box.
   void MenuItemFileProperties_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->ShowPropertiesDialog();
   }
   //</Snippet5>

   //<Snippet6>
   // Navigates to the URL in the address text box when 
   // the ENTER key is pressed while the text box has focus.
   void TextBoxAddress_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      if ( e->KeyCode == System::Windows::Forms::Keys::Enter &&  !this->TextBoxAddress->Text->Equals( "" ) )
      {
         this->WebBrowser1->Navigate( this->TextBoxAddress->Text );
      }
   }

   // Navigates to the URL in the address text box when 
   // the Go button is clicked.
   void ButtonGo_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if (  !this->TextBoxAddress->Text->Equals( "" ) )
      {
         this->WebBrowser1->Navigate( this->TextBoxAddress->Text );
      }
   }

   // Updates the URL in TextBoxAddress upon navigation.
   void WebBrowser1_Navigated( Object^ /*sender*/, System::Windows::Forms::WebBrowserNavigatedEventArgs^ /*e*/ )
   {
      this->TextBoxAddress->Text = this->WebBrowser1->Url->ToString();
   }

   //</Snippet6>

   //<Snippet7>
   // Navigates WebBrowser1 to the previous page in the history.
   void backButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoBack();
   }

   // Disables the Back button at the beginning of the navigation history.
   void WebBrowser1_CanGoBackChanged( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->backButton->Enabled = this->WebBrowser1->CanGoBack;
   }
   //</Snippet7>

   //<Snippet8>
   // Navigates WebBrowser1 to the next page in history.
   void ButtonForward_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoForward();
   }

   // Disables the Forward button at the end of navigation history.
   void WebBrowser1_CanGoForwardChanged( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->ButtonForward->Enabled = this->WebBrowser1->CanGoForward;
   }
   //</Snippet8>

   //<Snippet9>
   // Halts the current navigation and any sounds or animations on 
   // the page.
   void ButtonStop_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->Stop();
   }
   //</Snippet9>

   //<Snippet10>
   // Reloads the current page.
   void ButtonRefresh_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Skip refresh if about:blank is loaded to avoid removing
      // content specified by the DocumentText property.
      if (  !this->WebBrowser1->Url->Equals( "about:blank" ) )
      {
         this->WebBrowser1->Refresh();
      }
   }
   //</Snippet10>

   //<Snippet11>
   // Navigates WebBrowser1 to the home page of the current user.
   void ButtonHome_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoHome();
   }
   //</Snippet11>

   //<Snippet12>
   // Navigates WebBrowser1 to the search page of the current user.
   void ButtonSearch_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoSearch();
   }
   //</Snippet12>

   //<Snippet13>
   // Prints the current document using the current print settings.
   void ButtonPrint_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->Print();
   }
   //</Snippet13>

   //<Snippet14>
   // Updates StatusBar1 with the current browser status text.
   void WebBrowser1_StatusTextChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->StatusBar1->Text = WebBrowser1->StatusText;
   }
   //</Snippet14>

   //<Snippet15>
   // Updates the title bar with the current document title.
   void WebBrowser1_DocumentTitleChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->Text = WebBrowser1->DocumentTitle;
   }
   //</Snippet15>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   System::Windows::Forms::Application::Run( gcnew Form1 );
}
//</Snippet0>
