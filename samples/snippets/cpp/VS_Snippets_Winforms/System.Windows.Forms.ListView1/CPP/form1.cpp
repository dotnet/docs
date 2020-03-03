

// The following Snippet code example demonstrates using the: 
// ListView.MultiSelect, ListView.SelectedItems, 
// ListView.SelectIndices, SelectedIndexCollection, 
// SelectedListViewItemCollection ListView.SelectedIndexChanged event, 
// and ListView.HeaderStyle members and the SelectedIndexCollection and
// SelectedListViewItemCollection classes.
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
      InitializeComponent();
      InitializeListView();
      HookupEvents();
   }

internal:
   System::Windows::Forms::ListView^ ListView1;
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::Label ^ Label1;

private:
   void InitializeComponent()
   {
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      this->TextBox1->Location = System::Drawing::Point( 88, 168 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 120, 20 );
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Text = "";
      this->Label1->Location = System::Drawing::Point( 32, 168 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 48, 23 );
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Total: $";
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->TextBox1 );
      this->Name = "Form1";
      this->Text = "Breakfast Menu";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // This method adds two columns to the ListView, setting the Text 
   // and TextAlign, and Width properties of each ColumnHeader.  The 
   // HeaderStyle property is set to NonClickable since the ColumnClick 
   // event is not handled.  Finally the method adds ListViewItems and 
   // SubItems to each column.
   void InitializeListView()
   {
      this->ListView1 = gcnew System::Windows::Forms::ListView;
      this->ListView1->BackColor = System::Drawing::SystemColors::Control;
      this->ListView1->Dock = System::Windows::Forms::DockStyle::Top;
      this->ListView1->Location = System::Drawing::Point( 0, 0 );
      this->ListView1->Name = "ListView1";
      this->ListView1->Size = System::Drawing::Size( 292, 130 );
      this->ListView1->TabIndex = 0;
      this->ListView1->View = System::Windows::Forms::View::Details;
      this->ListView1->MultiSelect = true;
      this->ListView1->HideSelection = false;
      this->ListView1->HeaderStyle = ColumnHeaderStyle::Nonclickable;
      ColumnHeader^ columnHeader1 = gcnew ColumnHeader;
      columnHeader1->Text = "Breakfast Item";
      columnHeader1->TextAlign = HorizontalAlignment::Left;
      columnHeader1->Width = 146;
      ColumnHeader^ columnHeader2 = gcnew ColumnHeader;
      columnHeader2->Text = "Price Each";
      columnHeader2->TextAlign = HorizontalAlignment::Center;
      columnHeader2->Width = 142;
      this->ListView1->Columns->Add( columnHeader1 );
      this->ListView1->Columns->Add( columnHeader2 );
      array<String^>^foodList = {"Juice","Coffee","Cereal & Milk","Fruit Plate","Toast & Jelly","Bagel & Cream Cheese"};
      array<String^>^foodPrice = {"1.09","1.09","2.19","2.49","1.49","1.49"};
      for ( int count = 0; count < foodList->Length; count++ )
      {
         ListViewItem^ listItem = gcnew ListViewItem( foodList[ count ] );
         listItem->SubItems->Add( foodPrice[ count ] );
         ListView1->Items->Add( listItem );

      }
      this->Controls->Add( ListView1 );
   }
   //</snippet1>

   void HookupEvents()
   {
      this->ListView1->SelectedIndexChanged += gcnew EventHandler( this, &Form1::ListView1_SelectedIndexChanged_UsingItems );
      this->ListView1->SelectedIndexChanged += gcnew EventHandler( this, &Form1::ListView1_SelectedIndexChanged_UsingIndices );
   }

   // You can access the selected items directly with the SelectedItems   
   // property or you can access them through the items' indices,  
   // using the SelectedIndices property.  The following methods show
   // the two approaches.
   //<snippet2>
   // Uses the SelectedItems property to retrieve and tally the price 
   // of the selected menu items.
   void ListView1_SelectedIndexChanged_UsingItems( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ListView::SelectedListViewItemCollection^ breakfast = this->ListView1->SelectedItems;
      double price = 0.0;
      System::Collections::IEnumerator^ myEnum = breakfast->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum->Current);
         price += Double::Parse( item->SubItems[ 1 ]->Text );
      }

      // Output the price to TextBox1.
      TextBox1->Text = price.ToString();
   }
   //</snippet2>

   //<snippet3>
   // Uses the SelectedIndices property to retrieve and tally the  
   // price of the selected menu items.
   void ListView1_SelectedIndexChanged_UsingIndices( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ListView::SelectedIndexCollection^ indexes = this->ListView1->SelectedIndices;
      double price = 0.0;
      System::Collections::IEnumerator^ myEnum1 = indexes->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         int index = safe_cast<int>(myEnum1->Current);
         price += Double::Parse( this->ListView1->Items[ index ]->SubItems[ 1 ]->Text );
      }

      
      // Output the price to TextBox1.
      TextBox1->Text = price.ToString();
   }
   //</snippet3>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
