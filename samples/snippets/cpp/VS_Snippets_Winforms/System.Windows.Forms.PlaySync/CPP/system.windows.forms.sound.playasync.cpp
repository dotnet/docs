

#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Media;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>

   ~Form1()
   {


   }


private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>

   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
      
	  Player = gcnew SoundPlayer();
	  this->Player->LoadCompleted += gcnew System::ComponentModel::AsyncCompletedEventHandler( this, &Form1::Player_LoadCompleted );
   }



   /// <summary>
   /// The main entry point for the application.
   /// </summary>
   //<Snippet1>
private:
   SoundPlayer^ Player;

   void loadSoundAsync()
   {
      // Note: You may need to change the location specified based on
      // the location of the sound to be played.
      this->Player->SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav";
      this->Player->LoadAsync();
   }

   void Player_LoadCompleted( Object^ /*sender*/, System::ComponentModel::AsyncCompletedEventArgs^ /*e*/ )
   {
      if (this->Player->IsLoadCompleted == true)
      {
         this->Player->PlaySync();
      }
   }
   //</Snippet1>
};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
