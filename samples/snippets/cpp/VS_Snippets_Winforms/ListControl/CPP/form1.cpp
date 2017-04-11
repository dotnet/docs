//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections;
public ref class USState
{
private:
   String^ myShortName;
   String^ myLongName;

public:
   USState( String^ strLongName, String^ strShortName )
   {
      this->myShortName = strShortName;
      this->myLongName = strLongName;
   }

   property String^ ShortName 
   {
      String^ get()
      {
         return myShortName;
      }
   }

   property String^ LongName 
   {
      String^ get()
      {
         return myLongName;
      }

   }
};

public ref class ListBoxSample3: public Form
{
private:
   ListBox^ ListBox1;
   Label^ label1;
   TextBox^ textBox1;

public:
   ListBoxSample3()
   {
      ListBox1 = gcnew ListBox;
      label1 = gcnew Label;
      textBox1 = gcnew TextBox;
      this->ClientSize = System::Drawing::Size(307, 206 );
      this->Text = "ListBox Sample3";
      ListBox1->Location = Point(54,16);
      ListBox1->Name = "ListBox1";
      ListBox1->Size = System::Drawing::Size( 240, 130 );
      label1->Location = Point(14,150);
      label1->Name = "label1";
      label1->Size = System::Drawing::Size(40, 24);
      label1->Text = "Value";
      textBox1->Location = Point(54,150);
      textBox1->Name = "textBox1";
      textBox1->Size = System::Drawing::Size( 240, 24 );
      array<Control^>^temp2 = {ListBox1,label1, textBox1};
      this->Controls->AddRange( temp2 );

      //<Snippet2>
      // Populate the list box using an array as DataSource. 
      // DisplayMember is used to display just the long name of each state.
      ArrayList^ USStates = gcnew ArrayList;
      USStates->Add( gcnew USState( "Alabama","AL" ) );
      USStates->Add( gcnew USState( "Washington","WA" ) );
      USStates->Add( gcnew USState( "West Virginia","WV" ) );
      USStates->Add( gcnew USState( "Wisconsin","WI" ) );
      USStates->Add( gcnew USState( "Wyoming","WY" ) );
      ListBox1->DataSource = USStates;
      ListBox1->DisplayMember = "LongName";
      ListBox1->ValueMember = "ShortName";
      //</Snippet2>
      ListBox1->SelectedValueChanged += gcnew EventHandler( this, &ListBoxSample3::ListBox1_SelectedValueChanged );
      ListBox1->SetSelected(0, false);
   }

   void InitializeComponent(){}

private:
   //<Snippet3>
   void ListBox1_SelectedValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      textBox1->Text="";
      if ( ListBox1->SelectedIndex != -1 )
            textBox1->Text = ListBox1->SelectedValue->ToString();
   }
   //</Snippet3>
};

[STAThread]
int main()
{
   Application::Run( gcnew ListBoxSample3 );
}
//</Snippet1>