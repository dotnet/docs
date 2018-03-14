

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
      InitializeOwnerDrawnListBox();
      
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
      this->SuspendLayout();
      
      //
      //ListBox1
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
internal:
   System::Windows::Forms::ListBox^ ListBox1;

private:
   void InitializeOwnerDrawnListBox()
   {
      this->ListBox1 = gcnew System::Windows::Forms::ListBox;
      
      // Set the location and size.
      ListBox1->Location = Point(20,20);
      ListBox1->Size = System::Drawing::Size( 240, 240 );
      
      // Populate the ListBox.ObjectCollection property 
      // with several strings, using the AddRange method.
      array<Object^>^temp0 = {"System.Windows.Forms","System.Drawing","System.Xml","System.Net","System.Runtime.Remoting","System.Web"};
      this->ListBox1->Items->AddRange( temp0 );
      
      // Turn off the scrollbar.
      ListBox1->ScrollAlwaysVisible = false;
      
      // Set the border style to a single, flat border.
      ListBox1->BorderStyle = BorderStyle::FixedSingle;
      
      // Set the DrawMode property to the OwnerDrawVariable value. 
      // This means the MeasureItem and DrawItem events must be 
      // handled.
      ListBox1->DrawMode = DrawMode::OwnerDrawVariable;
      ListBox1->MeasureItem += gcnew MeasureItemEventHandler( this, &Form1::ListBox1_MeasureItem );
      ListBox1->DrawItem += gcnew DrawItemEventHandler( this, &Form1::ListBox1_DrawItem );
      this->Controls->Add( this->ListBox1 );
   }

   // Handle the DrawItem event for an owner-drawn ListBox.
   void ListBox1_DrawItem( Object^ /*sender*/, DrawItemEventArgs^ e )
   {
      // If the item is the selected item, then draw the rectangle
      // filled in blue. The item is selected when a bitwise And  
      // of the State property and the DrawItemState.Selected 
      // property is true.
      if ( (e->State & DrawItemState::Selected) == DrawItemState::Selected )
      {
         e->Graphics->FillRectangle( Brushes::CornflowerBlue, e->Bounds );
      }
      else
      {
         
         // Otherwise, draw the rectangle filled in beige.
         e->Graphics->FillRectangle( Brushes::Beige, e->Bounds );
      }
      
      // Draw a rectangle in blue around each item.
      e->Graphics->DrawRectangle( Pens::Blue, e->Bounds );
      
      // Draw the text in the item.
      e->Graphics->DrawString( ListBox1->Items[ e->Index ]->ToString(), this->Font, Brushes::Black, (float)e->Bounds.X, (float)e->Bounds.Y );
      
      // Draw the focus rectangle around the selected item.
      e->DrawFocusRectangle();
   }


   // Handle the MeasureItem event for an owner-drawn ListBox.
   void ListBox1_MeasureItem( Object^ sender, MeasureItemEventArgs^ e )
   {
      
      // Cast the sender object back to ListBox type.
      ListBox^ theListBox = dynamic_cast<ListBox^>(sender);
      
      // Get the string contained in each item.
      String^ itemString = dynamic_cast<String^>(theListBox->Items[ e->Index ]);
      
      // Split the string at the " . "  character.
      array<Char>^temp1 = {'.'};
      array<String^>^resultStrings = itemString->Split( temp1 );
      
      // If the string contains more than one period, increase the 
      // height by ten pixels; otherwise, increase the height by 
      // five pixels.
      if ( resultStrings->Length > 2 )
      {
         e->ItemHeight += 10;
      }
      else
      {
         e->ItemHeight += 5;
      }
   }
   //</snippet1>
};

[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
