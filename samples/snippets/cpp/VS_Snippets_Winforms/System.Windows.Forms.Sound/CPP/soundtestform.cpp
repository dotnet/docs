

// <snippet1>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::Media;
using namespace System::Windows::Forms;

public ref class SoundTestForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::TextBox^ filepathTextbox;
   System::Windows::Forms::Button^ playOnceSyncButton;
   System::Windows::Forms::Button^ playOnceAsyncButton;
   System::Windows::Forms::Button^ playLoopAsyncButton;
   System::Windows::Forms::Button^ selectFileButton;
   System::Windows::Forms::Button^ stopButton;
   System::Windows::Forms::StatusBar^ statusBar;
   System::Windows::Forms::Button^ loadSyncButton;
   System::Windows::Forms::Button^ loadAsyncButton;
   SoundPlayer^ player;

public:
   SoundTestForm()
   {
      
      // Initialize Forms Designer generated code.
      InitializeComponent();
      
      // Disable playback controls until a valid .wav file 
      // is selected.
      EnablePlaybackControls( false );
      
      // Set up the status bar and other controls.
      InitializeControls();
      
      // Set up the SoundPlayer object.
      InitializeSound();
   }


private:

   // Sets up the status bar and other controls.
   void InitializeControls()
   {
      
      // Set up the status bar.
      StatusBarPanel^ panel = gcnew StatusBarPanel;
      panel->BorderStyle = StatusBarPanelBorderStyle::Sunken;
      panel->Text = "Ready.";
      panel->AutoSize = StatusBarPanelAutoSize::Spring;
      this->statusBar->ShowPanels = true;
      this->statusBar->Panels->Add( panel );
   }


   // Sets up the SoundPlayer object.
   void InitializeSound()
   {
      
      // Create an instance of the SoundPlayer class.
      player = gcnew SoundPlayer;
      
      // Listen for the LoadCompleted event.
      player->LoadCompleted += gcnew AsyncCompletedEventHandler( this, &SoundTestForm::player_LoadCompleted );
      
      // Listen for the SoundLocationChanged event.
      player->SoundLocationChanged += gcnew EventHandler( this, &SoundTestForm::player_LocationChanged );
   }

   void selectFileButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Create a new OpenFileDialog.
      OpenFileDialog^ dlg = gcnew OpenFileDialog;
      
      // Make sure the dialog checks for existence of the 
      // selected file.
      dlg->CheckFileExists = true;
      
      // Allow selection of .wav files only.
      dlg->Filter = "WAV files (*.wav)|*.wav";
      dlg->DefaultExt = ".wav";
      
      // Activate the file selection dialog.
      if ( dlg->ShowDialog() == ::DialogResult::OK )
      {
         
         // Get the selected file's path from the dialog.
         this->filepathTextbox->Text = dlg->FileName;
         
         // Assign the selected file's path to 
         // the SoundPlayer object.  
         player->SoundLocation = filepathTextbox->Text;
      }
   }


   // Convenience method for setting message text in 
   // the status bar.
   void ReportStatus( String^ statusMessage )
   {
      
      // If the caller passed in a message...
      if ( (statusMessage != nullptr) && (statusMessage != String::Empty) )
      {
         
         // ...post the caller's message to the status bar.
         this->statusBar->Panels[ 0 ]->Text = statusMessage;
      }
   }


   // Enables and disables play controls.
   void EnablePlaybackControls( bool enabled )
   {
      this->playOnceSyncButton->Enabled = enabled;
      this->playOnceAsyncButton->Enabled = enabled;
      this->playLoopAsyncButton->Enabled = enabled;
      this->stopButton->Enabled = enabled;
   }

   void filepathTextbox_TextChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Disable playback controls until the new .wav is loaded.
      EnablePlaybackControls( false );
   }

   void loadSyncButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Disable playback controls until the .wav is 
      // successfully loaded. The LoadCompleted event 
      // handler will enable them.
      EnablePlaybackControls( false );
      
      // <snippet2>
      try
      {
         
         // Assign the selected file's path to 
         // the SoundPlayer object.  
         player->SoundLocation = filepathTextbox->Text;
         
         // Load the .wav file.
         player->Load();
      }
      catch ( Exception^ ex ) 
      {
         ReportStatus( ex->Message );
      }

      
      // </snippet2>
   }

   void loadAsyncButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Disable playback controls until the .wav is 
      // successfully loaded. The LoadCompleted event 
      // handler will enable them.
      EnablePlaybackControls( false );
      
      // <snippet3>
      try
      {
         
         // Assign the selected file's path to 
         // the SoundPlayer object.  
         player->SoundLocation = this->filepathTextbox->Text;
         
         // Load the .wav file.
         player->LoadAsync();
      }
      catch ( Exception^ ex ) 
      {
         ReportStatus( ex->Message );
      }

      
      // </snippet3>
   }


   // Synchronously plays the selected .wav file once.
   // If the file is large, UI response will be visibly 
   // affected.
   void playOnceSyncButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // <snippet4>
      ReportStatus( "Playing .wav file synchronously." );
      player->PlaySync();
      ReportStatus( "Finished playing .wav file synchronously." );
      
      // </snippet4>
   }


   // Asynchronously plays the selected .wav file once.
   void playOnceAsyncButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // <snippet5>
      ReportStatus( "Playing .wav file asynchronously." );
      player->Play();
      
      // </snippet5>
   }


   // Asynchronously plays the selected .wav file until the user
   // clicks the Stop button.
   void playLoopAsyncButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // <snippet6>
      ReportStatus( "Looping .wav file asynchronously." );
      player->PlayLooping();
      
      // </snippet6>
   }


   // Stops the currently playing .wav file, if any.
   void stopButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // <snippet7>
      player->Stop();
      ReportStatus( "Stopped by user." );
      
      // </snippet7>
   }


   // <snippet8>
   // Handler for the LoadCompleted event.
   void player_LoadCompleted( Object^ /*sender*/, AsyncCompletedEventArgs^ /*e*/ )
   {
      String^ message = String::Format( "LoadCompleted: {0}", this->filepathTextbox->Text );
      ReportStatus( message );
      EnablePlaybackControls( true );
   }


   // </snippet8>
   // <snippet9>
   // Handler for the SoundLocationChanged event.
   void player_LocationChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ message = String::Format( "SoundLocationChanged: {0}", player->SoundLocation );
      ReportStatus( message );
   }


   // </snippet9>
   void InitializeComponent()
   {
      this->filepathTextbox = gcnew System::Windows::Forms::TextBox;
      this->selectFileButton = gcnew System::Windows::Forms::Button;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->loadSyncButton = gcnew System::Windows::Forms::Button;
      this->playOnceSyncButton = gcnew System::Windows::Forms::Button;
      this->playOnceAsyncButton = gcnew System::Windows::Forms::Button;
      this->stopButton = gcnew System::Windows::Forms::Button;
      this->playLoopAsyncButton = gcnew System::Windows::Forms::Button;
      this->statusBar = gcnew System::Windows::Forms::StatusBar;
      this->loadAsyncButton = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // 
      // filepathTextbox
      // 
      this->filepathTextbox->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->filepathTextbox->Location = System::Drawing::Point( 7, 25 );
      this->filepathTextbox->Name = "filepathTextbox";
      this->filepathTextbox->Size = System::Drawing::Size( 263, 20 );
      this->filepathTextbox->TabIndex = 1;
      this->filepathTextbox->Text = "";
      this->filepathTextbox->TextChanged += gcnew System::EventHandler( this, &SoundTestForm::filepathTextbox_TextChanged );
      
      // 
      // selectFileButton
      // 
      this->selectFileButton->Anchor = static_cast<AnchorStyles>(AnchorStyles::Top | AnchorStyles::Right);
      this->selectFileButton->Location = System::Drawing::Point( 276, 25 );
      this->selectFileButton->Name = "selectFileButton";
      this->selectFileButton->Size = System::Drawing::Size( 23, 21 );
      this->selectFileButton->TabIndex = 2;
      this->selectFileButton->Text = "...";
      this->selectFileButton->Click += gcnew System::EventHandler( this, &SoundTestForm::selectFileButton_Click );
      
      // 
      // label1
      // 
      this->label1->Location = System::Drawing::Point( 7, 7 );
      this->label1->Name = "label1";
      this->label1->Size = System::Drawing::Size( 145, 17 );
      this->label1->TabIndex = 3;
      this->label1->Text = ".wav path or URL:";
      
      // 
      // loadSyncButton
      // 
      this->loadSyncButton->Location = System::Drawing::Point( 7, 53 );
      this->loadSyncButton->Name = "loadSyncButton";
      this->loadSyncButton->Size = System::Drawing::Size( 142, 23 );
      this->loadSyncButton->TabIndex = 4;
      this->loadSyncButton->Text = "Load Synchronously";
      this->loadSyncButton->Click += gcnew System::EventHandler( this, &SoundTestForm::loadSyncButton_Click );
      
      // 
      // playOnceSyncButton
      // 
      this->playOnceSyncButton->Location = System::Drawing::Point( 7, 86 );
      this->playOnceSyncButton->Name = "playOnceSyncButton";
      this->playOnceSyncButton->Size = System::Drawing::Size( 142, 23 );
      this->playOnceSyncButton->TabIndex = 5;
      this->playOnceSyncButton->Text = "Play Once Synchronously";
      this->playOnceSyncButton->Click += gcnew System::EventHandler( this, &SoundTestForm::playOnceSyncButton_Click );
      
      // 
      // playOnceAsyncButton
      // 
      this->playOnceAsyncButton->Location = System::Drawing::Point( 149, 86 );
      this->playOnceAsyncButton->Name = "playOnceAsyncButton";
      this->playOnceAsyncButton->Size = System::Drawing::Size( 147, 23 );
      this->playOnceAsyncButton->TabIndex = 6;
      this->playOnceAsyncButton->Text = "Play Once Asynchronously";
      this->playOnceAsyncButton->Click += gcnew System::EventHandler( this, &SoundTestForm::playOnceAsyncButton_Click );
      
      // 
      // stopButton
      // 
      this->stopButton->Location = System::Drawing::Point( 149, 109 );
      this->stopButton->Name = "stopButton";
      this->stopButton->Size = System::Drawing::Size( 147, 23 );
      this->stopButton->TabIndex = 7;
      this->stopButton->Text = "Stop";
      this->stopButton->Click += gcnew System::EventHandler( this, &SoundTestForm::stopButton_Click );
      
      // 
      // playLoopAsyncButton
      // 
      this->playLoopAsyncButton->Location = System::Drawing::Point( 7, 109 );
      this->playLoopAsyncButton->Name = "playLoopAsyncButton";
      this->playLoopAsyncButton->Size = System::Drawing::Size( 142, 23 );
      this->playLoopAsyncButton->TabIndex = 8;
      this->playLoopAsyncButton->Text = "Loop Asynchronously";
      this->playLoopAsyncButton->Click += gcnew System::EventHandler( this, &SoundTestForm::playLoopAsyncButton_Click );
      
      // 
      // statusBar
      // 
      this->statusBar->Location = System::Drawing::Point( 0, 146 );
      this->statusBar->Name = "statusBar";
      this->statusBar->Size = System::Drawing::Size( 306, 22 );
      this->statusBar->SizingGrip = false;
      this->statusBar->TabIndex = 9;
      this->statusBar->Text = "(no status)";
      
      // 
      // loadAsyncButton
      // 
      this->loadAsyncButton->Location = System::Drawing::Point( 149, 53 );
      this->loadAsyncButton->Name = "loadAsyncButton";
      this->loadAsyncButton->Size = System::Drawing::Size( 147, 23 );
      this->loadAsyncButton->TabIndex = 10;
      this->loadAsyncButton->Text = "Load Asynchronously";
      this->loadAsyncButton->Click += gcnew System::EventHandler( this, &SoundTestForm::loadAsyncButton_Click );
      
      // 
      // SoundTestForm
      // 
      this->ClientSize = System::Drawing::Size( 306, 168 );
      this->Controls->Add( this->loadAsyncButton );
      this->Controls->Add( this->statusBar );
      this->Controls->Add( this->playLoopAsyncButton );
      this->Controls->Add( this->stopButton );
      this->Controls->Add( this->playOnceAsyncButton );
      this->Controls->Add( this->playOnceSyncButton );
      this->Controls->Add( this->loadSyncButton );
      this->Controls->Add( this->label1 );
      this->Controls->Add( this->selectFileButton );
      this->Controls->Add( this->filepathTextbox );
      this->MinimumSize = System::Drawing::Size( 310, 165 );
      this->Name = "SoundTestForm";
      this->SizeGripStyle = System::Windows::Forms::SizeGripStyle::Show;
      this->Text = "Sound API Test Form";
      this->ResumeLayout( false );
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew SoundTestForm );
}

// </snippet1>
