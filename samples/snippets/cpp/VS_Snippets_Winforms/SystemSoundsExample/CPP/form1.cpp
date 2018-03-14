#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Media;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      InitializeComponent();
   }

   void PlayAsterisk()
   {
      //<Snippet1>
      // Plays the sound associated with the Asterisk system event.
      SystemSounds::Asterisk->Play();
      //</Snippet1>                        
   }

   void PlayBeep()
   {
      //<Snippet2>
      // Plays the sound associated with the Beep system event.
      SystemSounds::Beep->Play();
      //</Snippet2>                        
   }

   void PlayExclamation()
   {
      //<Snippet3>
      // Plays the sound associated with the Exclamation system event.
      SystemSounds::Exclamation->Play();
      //</Snippet3>                        
   }

   void PlayHand()
   {
      //<Snippet4>
      // Plays the sound associated with the Hand system event.
      SystemSounds::Hand->Play();
      //</Snippet4>                        
   }

   void PlayQuestion()
   {
      //<Snippet5>
      // Plays the sound associated with the Question system event.
      SystemSounds::Question->Play();
      //</Snippet5>                        
   }

   #pragma region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
private:
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }
   #pragma endregion
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
