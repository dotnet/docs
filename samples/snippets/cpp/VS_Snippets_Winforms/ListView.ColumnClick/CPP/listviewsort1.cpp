//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections;

// Implements the manual sorting of items by columns.
ref class ListViewItemComparer: public IComparer
{
private:
   int col;

public:
   ListViewItemComparer()
   {
      col = 0;
   }

   ListViewItemComparer( int column )
   {
      col = column;
   }

   virtual int Compare( Object^ x, Object^ y )
   {
      return String::Compare( (dynamic_cast<ListViewItem^>(x))->SubItems[ col ]->Text,
                              (dynamic_cast<ListViewItem^>(y))->SubItems[ col ]->Text );
   }
};

public ref class ListViewSortForm: public Form
{
private:
   ListView^ listView1;

public:
   ListViewSortForm()
   {
      // Create ListView items to add to the control.
      array<String^>^temp0 = {"Banana","a","b","c"};
      ListViewItem^ listViewItem1 = gcnew ListViewItem( temp0,-1,Color::Empty,Color::Yellow,nullptr );
      array<String^>^temp1 = {"Cherry","v","g","t"};
      ListViewItem^ listViewItem2 = gcnew ListViewItem( temp1,-1,Color::Empty,Color::Red,
                 gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,FontStyle::Regular,GraphicsUnit::Point,0 ) );
      array<String^>^temp2 = {"Apple","h","j","n"};
      ListViewItem^ listViewItem3 = gcnew ListViewItem( temp2,-1,Color::Empty,Color::Lime,nullptr );
      array<String^>^temp3 = {"Pear","y","u","i"};
      ListViewItem^ listViewItem4 = gcnew ListViewItem( temp3,-1,Color::Empty,Color::FromArgb( 192, 128, 156 ),nullptr );

      //Initialize the ListView control and add columns to it.
      this->listView1 = gcnew ListView;

      // Set the initial sorting type for the ListView.
      this->listView1->Sorting = SortOrder::None;

      // Disable automatic sorting to enable manual sorting.
      this->listView1->View = View::Details;

      // Add columns and set their text.
      this->listView1->Columns->Add( gcnew ColumnHeader );
      this->listView1->Columns[ 0 ]->Text = "Column 1";
      this->listView1->Columns[ 0 ]->Width = 100;
      listView1->Columns->Add( gcnew ColumnHeader );
      listView1->Columns[ 1 ]->Text = "Column 2";
      listView1->Columns->Add( gcnew ColumnHeader );
      listView1->Columns[ 2 ]->Text = "Column 3";
      listView1->Columns->Add( gcnew ColumnHeader );
      listView1->Columns[ 3 ]->Text = "Column 4";

      // Suspend control logic until form is done configuring form.
      this->SuspendLayout();

      // Add Items to the ListView control.
      array<ListViewItem^>^temp4 = {listViewItem1,listViewItem2,listViewItem3,listViewItem4};
      this->listView1->Items->AddRange( temp4 );

      // Set the location and size of the ListView control.
      this->listView1->Location = Point(10,10);
      this->listView1->Name = "listView1";
      this->listView1->Size = System::Drawing::Size( 300, 100 );
      this->listView1->TabIndex = 0;

      // Enable editing of the items in the ListView.
      this->listView1->LabelEdit = true;

      // Connect the ListView::ColumnClick event to the ColumnClick event handler.
      this->listView1->ColumnClick += gcnew ColumnClickEventHandler( this, &ListViewSortForm::ColumnClick );

      // Initialize the form.
      this->ClientSize = System::Drawing::Size( 400, 400 );
      array<Control^>^temp5 = {this->listView1};
      this->Controls->AddRange( temp5 );
      this->Name = "ListViewSortForm";
      this->Text = "Sorted ListView Control";

      // Resume lay[Out] of* the form.
      this->ResumeLayout( false );
   }

private:

   // ColumnClick event handler.
   void ColumnClick( Object^ /*o*/, ColumnClickEventArgs^ e )
   {
      // Set the ListViewItemSorter property to a new ListViewItemComparer 
      // object. Setting this property immediately sorts the 
      // ListView using the ListViewItemComparer object.
      this->listView1->ListViewItemSorter = gcnew ListViewItemComparer( e->Column );
   }
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew ListViewSortForm );
}
//</Snippet1>
