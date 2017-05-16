

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::LinkLabel^ linkLabel1;

public:
   Form1()
   {
      
      // Create the LinkLabel.
      this->linkLabel1 = gcnew System::Windows::Forms::LinkLabel;
      
      // Configure the LinkLabel's size and location. Specify that the
      // size should be automatically determined by the content.
      this->linkLabel1->Location = System::Drawing::Point( 34, 56 );
      this->linkLabel1->Size = System::Drawing::Size( 224, 16 );
      this->linkLabel1->AutoSize = true;
      
      // Configure the appearance.
      this->linkLabel1->DisabledLinkColor = System::Drawing::Color::Red;
      this->linkLabel1->VisitedLinkColor = System::Drawing::Color::Blue;
      this->linkLabel1->LinkBehavior = System::Windows::Forms::LinkBehavior::HoverUnderline;
      this->linkLabel1->LinkColor = System::Drawing::Color::Navy;
      this->linkLabel1->TabIndex = 0;
      this->linkLabel1->TabStop = true;
      
      // Add an event handler to do something when the links are clicked.
      this->linkLabel1->LinkClicked += gcnew System::Windows::Forms::LinkLabelLinkClickedEventHandler( this, &Form1::linkLabel1_LinkClicked );
      
      // Identify what the first Link is.
      this->linkLabel1->LinkArea = System::Windows::Forms::LinkArea( 0, 8 );
      
      // Identify that the first link is visited already.
      this->linkLabel1->Links[ 0 ]->Visited = true;
      
      // Set the Text property to a String*.
      this->linkLabel1->Text = "Register Online.  Visit Microsoft.  Visit MSN.";
      
      // Create new links using the Add method of the LinkCollection class.
      // Underline the appropriate words in the LinkLabel's Text property.
      // The words 'Register', 'Microsoft', and 'MSN' will
      // all be underlined and behave as hyperlinks.
      // First check that the Text property is long enough to accommodate
      // the desired hyperlinked areas.  If it's not, don't add hyperlinks.
      if ( this->linkLabel1->Text->Length >= 45 )
      {
         this->linkLabel1->Links[ 0 ]->LinkData = "Register";
         this->linkLabel1->Links->Add( 24, 9, "www.microsoft.com" );
         this->linkLabel1->Links->Add( 42, 3, "www.msn.com" );
         this->linkLabel1->Links[ 1 ]->Enabled = false;
      }

      
      // Set up how the form should be displayed and add the controls to the form.
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->linkLabel1};
      this->Controls->AddRange( temp0 );
      this->Text = "Link Label Example";
   }


private:
   void linkLabel1_LinkClicked( Object^ /*sender*/, System::Windows::Forms::LinkLabelLinkClickedEventArgs^ e )
   {
      // Determine which link was clicked within the LinkLabel.
      this->linkLabel1->Links[ linkLabel1->Links->IndexOf( e->Link ) ]->Visited = true;
      
      // Display the appropriate link based on the value of the
      // LinkData property of the Link Object*.
      String^ target = dynamic_cast<String^>(e->Link->LinkData);
      
      // If the value looks like a URL, navigate to it.
      // Otherwise, display it in a message box.
      if ( nullptr != target && target->StartsWith( "www" ) )
      {
         System::Diagnostics::Process::Start( target );
      }
      else
      {
         MessageBox::Show( "Item clicked: {0}", target );
      }
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
