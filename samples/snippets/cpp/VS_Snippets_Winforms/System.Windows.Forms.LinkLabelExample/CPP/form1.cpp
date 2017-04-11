

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeLinkLabel();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 272, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
   }

   //<snippet1>
   // Declare the LinkLabel object.
internal:
   System::Windows::Forms::LinkLabel^ LinkLabel1;

   // Declare keywords array to identify links
   array<String^>^keywords;

private:
   void InitializeLinkLabel()
   {
      this->LinkLabel1 = gcnew System::Windows::Forms::LinkLabel;
      this->LinkLabel1->Links->Clear();
      // Set the location, name and size.
      this->LinkLabel1->Location = System::Drawing::Point( 10, 20 );
      this->LinkLabel1->Name = "CompanyLinks";
      this->LinkLabel1->Size = System::Drawing::Size( 104, 150 );
      
      // Set the LinkBehavior property to show underline when mouse
      // hovers over the links.
      this->LinkLabel1->LinkBehavior = System::Windows::Forms::LinkBehavior::HoverUnderline;
      String^ textString = "For more information see our"
      " company website or the research page at Contoso Ltd. ";
      
      // Set the text property.
      this->LinkLabel1->Text = textString;
      
      // Set the color of the links to black, unless the mouse
      // is hovering over a link.
      this->LinkLabel1->LinkColor = System::Drawing::Color::Black;
      this->LinkLabel1->ActiveLinkColor = System::Drawing::Color::Blue;
      
      // Associate the event-handling method with the LinkClicked
      // event.
      this->LinkLabel1->LinkClicked += gcnew LinkLabelLinkClickedEventHandler( this, &Form1::LinkLabel1_LinkClicked );
      
      // Add links to the LinkCollection using starting index and
      // length of keywords.
      array<String^>^temp0 = {"company","research"};
      keywords = temp0;
      System::Collections::IEnumerator^ myEnum = keywords->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ keyword = safe_cast<String^>(myEnum->Current);
         this->LinkLabel1->Links->Add( textString->IndexOf( keyword ), keyword->Length );
      }

      
      // Add the label to the form.
      this->Controls->Add( this->LinkLabel1 );
   }

   void LinkLabel1_LinkClicked( Object^ /*sender*/, LinkLabelLinkClickedEventArgs^ e )
   {
      String^ url = "";
      
      // Determine which link was clicked and set the appropriate url.
      switch ( LinkLabel1->Links->IndexOf( e->Link ) )
      {
         case 0:
            url = "www.microsoft.com";
            break;

         case 1:
            url = "www.contoso.com/research";
            break;
      }
      
      // Set the visited property to True. This will change
      // the color of the link.
      e->Link->Visited = true;
      
      // Open Internet Explorer to the correct url.
      System::Diagnostics::Process::Start( "IExplore.exe", url );
   }
   //</snippet1>
};

[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
