#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;

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
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 344, 360 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 104, 24 );
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 464, 397 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void CreateMyListView()
   {
      // Create a new ListView control.
      ListView^ listView1 = gcnew ListView;
      listView1->Bounds = Rectangle(Point(10,10),System::Drawing::Size( 300, 200 ));

      // Set the view to show details.
      listView1->View = View::Details;

      // Allow the user to edit item text.
      listView1->LabelEdit = true;

      // Allow the user to rearrange columns.
      listView1->AllowColumnReorder = true;

      // Display check boxes.
      listView1->CheckBoxes = true;

      // Select the item and subitems when selection is made.
      listView1->FullRowSelect = true;

      // Display grid lines.
      listView1->GridLines = true;

      // Sort the items in the list in ascending order.
      listView1->Sorting = SortOrder::Ascending;

      // Create three items and three sets of subitems for each item.
      ListViewItem^ item1 = gcnew ListViewItem( "item1",0 );

      // Place a check mark next to the item.
      item1->Checked = true;
      item1->SubItems->Add( "1" );
      item1->SubItems->Add( "2" );
      item1->SubItems->Add( "3" );
      ListViewItem^ item2 = gcnew ListViewItem( "item2",1 );
      item2->SubItems->Add( "4" );
      item2->SubItems->Add( "5" );
      item2->SubItems->Add( "6" );
      ListViewItem^ item3 = gcnew ListViewItem( "item3",0 );

      // Place a check mark next to the item.
      item3->Checked = true;
      item3->SubItems->Add( "7" );
      item3->SubItems->Add( "8" );
      item3->SubItems->Add( "9" );

      // Create columns for the items and subitems.
      // Width of -2 indicates auto-size.
      listView1->Columns->Add( "Item Column", -2, HorizontalAlignment::Left );
      listView1->Columns->Add( "Column 2", -2, HorizontalAlignment::Left );
      listView1->Columns->Add( "Column 3", -2, HorizontalAlignment::Left );
      listView1->Columns->Add( "Column 4", -2, HorizontalAlignment::Center );

      //Add the items to the ListView.
      array<ListViewItem^>^temp1 = {item1,item2,item3};
      listView1->Items->AddRange( temp1 );

      // Create two ImageList objects.
      ImageList^ imageListSmall = gcnew ImageList;
      ImageList^ imageListLarge = gcnew ImageList;

      // Initialize the ImageList objects with bitmaps.
      imageListSmall->Images->Add( Bitmap::FromFile( "C:\\MySmallImage1.bmp" ) );
      imageListSmall->Images->Add( Bitmap::FromFile( "C:\\MySmallImage2.bmp" ) );
      imageListLarge->Images->Add( Bitmap::FromFile( "C:\\MyLargeImage1.bmp" ) );
      imageListLarge->Images->Add( Bitmap::FromFile( "C:\\MyLargeImage2.bmp" ) );

      //Assign the ImageList objects to the ListView.
      listView1->LargeImageList = imageListLarge;
      listView1->SmallImageList = imageListSmall;
      
      // Add the ListView to the control collection.
      this->Controls->Add( listView1 );
   }
   //</snippet1>

   void button1_Click( Object^ sender, System::EventArgs^ e )
   {
      CreateMyListView();
   }
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
