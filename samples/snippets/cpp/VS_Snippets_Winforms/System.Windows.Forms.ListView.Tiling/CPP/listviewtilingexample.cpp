

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class ListViewTilingExample: public Form
{
private:
   ImageList^ myImageList;

public:
   ListViewTilingExample()
   {
      // Initialize myListView.
      ListView^ myListView = gcnew ListView;
      myListView->Dock = DockStyle::Fill;
      myListView->View = View::Tile;
      
      // Initialize the tile size.
      myListView->TileSize = System::Drawing::Size( 400, 45 );
      
      // Initialize the item icons.
      myImageList = gcnew ImageList;
      System::Drawing::Icon^ myIcon = gcnew System::Drawing::Icon( "book.ico" );
      try
      {
         myImageList->Images->Add( myIcon );
      }
      finally
      {
         if ( myIcon )
                  delete safe_cast<IDisposable^>(myIcon);
      }

      myImageList->ImageSize = System::Drawing::Size( 32, 32 );
      myListView->LargeImageList = myImageList;
      
      // Add column headers so the subitems will appear.
      array<ColumnHeader^>^temp0 = {gcnew ColumnHeader,gcnew ColumnHeader,gcnew ColumnHeader};
      myListView->Columns->AddRange( temp0 );
      
      // Create items and add them to myListView.
      array<String^>^temp1 = {"Programming Windows","Petzold, Charles","1998"};
      ListViewItem^ item0 = gcnew ListViewItem( temp1,0 );
      array<String^>^temp2 = {"Code: The Hidden Language of Computer Hardware and Software","Petzold, Charles","2000"};
      ListViewItem^ item1 = gcnew ListViewItem( temp2,0 );
      array<String^>^temp3 = {"Programming Windows with C#","Petzold, Charles","2001"};
      ListViewItem^ item2 = gcnew ListViewItem( temp3,0 );
      array<String^>^temp4 = {"Coding Techniques for Microsoft Visual Basic .NET","Connell, John","2001"};
      ListViewItem^ item3 = gcnew ListViewItem( temp4,0 );
      array<String^>^temp5 = {"C# for Java Developers","Jones, Allen & Freeman, Adam","2002"};
      ListViewItem^ item4 = gcnew ListViewItem( temp5,0 );
      array<String^>^temp6 = {"Microsoft .NET XML Web Services Step by Step","Jones, Allen & Freeman, Adam","2002"};
      ListViewItem^ item5 = gcnew ListViewItem( temp6,0 );
      array<ListViewItem^>^temp7 = {item0,item1,item2,item3,item4,item5};
      myListView->Items->AddRange( temp7 );
      
      // Initialize the form.
      this->Controls->Add( myListView );
      this->Size = System::Drawing::Size( 430, 330 );
      this->Text = "ListView Tiling Example";
   }

protected:

   // Clean up any resources being used.
   ~ListViewTilingExample()
   {
      if ( myImageList != nullptr )
      {
         delete myImageList;
      }
   }
};

[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew ListViewTilingExample );
}
//</Snippet1>
