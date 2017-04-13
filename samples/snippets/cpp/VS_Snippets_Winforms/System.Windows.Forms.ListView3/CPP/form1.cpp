// The following code example handles the ListView.BeforeLabelEdit event
// and demonstrates the EditLabelEventArgs.Item and CancelEdit properties. 

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      InitializeComponent();
   }

internal:
   System::Windows::Forms::ListView^ ListView1;
   System::Windows::Forms::Label ^ Label1;

private:
   void InitializeComponent()
   {
      ListViewItem^ ListViewItem1 = gcnew ListViewItem( "VisualBasic.Net",0 );
      ListViewItem^ ListViewItem2 = gcnew ListViewItem( "Advanced VisualBasic.Net",1 );
      ListViewItem^ ListViewItem3 = gcnew ListViewItem( "Object-Oriented Design" );
      ListViewItem^ ListViewItem4 = gcnew ListViewItem( "Design Patterns for VB" );
      ListViewItem^ ListViewItem5 = gcnew ListViewItem( "UI Design" );
      ListViewItem^ ListViewItem6 = gcnew ListViewItem( "E-Commerce" );
      ListViewItem^ ListViewItem7 = gcnew ListViewItem( "Software Testing Techniques" );
      this->ListView1 = gcnew System::Windows::Forms::ListView;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      array<ListViewItem^>^ temp0 = {ListViewItem1,ListViewItem2,ListViewItem3,
         ListViewItem4,ListViewItem5,ListViewItem6,ListViewItem7};
      this->ListView1->Items->AddRange( temp0 );
      this->ListView1->LabelEdit = true;
      this->ListView1->Location = System::Drawing::Point( 16, 48 );
      this->ListView1->Name = "ListView1";
      this->ListView1->Size = System::Drawing::Size( 248, 120 );
      this->ListView1->TabIndex = 0;
      this->ListView1->View = System::Windows::Forms::View::List;
      this->ListView1->BeforeLabelEdit += gcnew LabelEditEventHandler(
         this, &Form1::ListView1_BeforeLabelEdit );
      this->Label1->Location = System::Drawing::Point( 16, 8 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 240, 32 );
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Proposed Class Schedule"
         + " (The first two classes are required):";
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->ListView1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //<snippet1>
   void ListView1_BeforeLabelEdit( Object^ sender,
      System::Windows::Forms::LabelEditEventArgs^ e )
   {
      // Allow all but the first two items of the list to 
      // be modified by the user.
      if ( e->Item < 2 )
      {
         e->CancelEdit = true;
      }
   }
   //</snippet1>
};

[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
