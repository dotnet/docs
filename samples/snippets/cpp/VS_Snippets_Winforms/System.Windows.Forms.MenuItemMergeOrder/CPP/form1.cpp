

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

//<snippet1>
// The following code example demonstrates using the MenuItem 
// Merge-Order property to control the way a merged menu is displayed.
using namespace System::Windows::Forms;

//Declare a MainMenu object and its items.
public ref class Form1: public System::Windows::Forms::Form
{
public private:
   System::Windows::Forms::MainMenu^ mainMenu1;
   System::Windows::Forms::MenuItem^ fileItem;
   System::Windows::Forms::MenuItem^ newItem;
   System::Windows::Forms::MenuItem^ openItem;
   System::Windows::Forms::MenuItem^ saveItem;
   System::Windows::Forms::MenuItem^ optionsMenu;
   System::Windows::Forms::MenuItem^ viewItem;
   System::Windows::Forms::MenuItem^ toolsItem;

   // Declare a ContextMenu object and its items.
   System::Windows::Forms::ContextMenu^ contextMenu1;
   System::Windows::Forms::MenuItem^ cutItem;
   System::Windows::Forms::MenuItem^ copyItem;
   System::Windows::Forms::MenuItem^ pasteItem;

public:
   Form1()
      : Form()
   {
      this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->fileItem = gcnew System::Windows::Forms::MenuItem;
      this->newItem = gcnew System::Windows::Forms::MenuItem;
      this->openItem = gcnew System::Windows::Forms::MenuItem;
      this->saveItem = gcnew System::Windows::Forms::MenuItem;
      this->viewItem = gcnew System::Windows::Forms::MenuItem;
      this->toolsItem = gcnew System::Windows::Forms::MenuItem;
      this->optionsMenu = gcnew System::Windows::Forms::MenuItem;
      this->toolsItem = gcnew System::Windows::Forms::MenuItem;
      this->viewItem = gcnew System::Windows::Forms::MenuItem;
      this->contextMenu1 = gcnew System::Windows::Forms::ContextMenu;
      this->cutItem = gcnew System::Windows::Forms::MenuItem;
      this->copyItem = gcnew System::Windows::Forms::MenuItem;
      this->pasteItem = gcnew System::Windows::Forms::MenuItem;
      
      //Add file menu item and options menu item to the MainMenu.
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->fileItem,this->optionsMenu};
      this->mainMenu1->MenuItems->AddRange( temp0 );
      
      // Initialize the file menu and its contents.
      this->fileItem->Index = 0;
      this->fileItem->Text = "File";
      this->newItem->Index = 0;
      this->newItem->Text = "New";
      this->openItem->Index = 1;
      this->openItem->Text = "Open";
      this->saveItem->Index = 2;
      this->saveItem->Text = "Save";
      
      // Set the merge order of fileItem to 2 so it has a lower priority 
      // on the merged menu.
      this->fileItem->MergeOrder = 2;
      
      //Add the new items to the fileItem menu item collection.
      array<MenuItem^>^temp1 = {this->newItem,this->openItem,this->saveItem};
      this->fileItem->MenuItems->AddRange( temp1 );
      
      // Initalize the optionsMenu item and its contents.
      this->optionsMenu->Index = 1;
      this->optionsMenu->Text = "Options";
      this->viewItem->Index = 0;
      this->viewItem->Text = "View";
      this->toolsItem->Index = 1;
      this->toolsItem->Text = "Tools";
      
      // Set mergeOrder property to 1, so it has a higher priority than
      // the fileItem on the merged menu.
      this->optionsMenu->MergeOrder = 1;
      
      //Add view and tool items to the optionsItem menu item.
      array<MenuItem^>^temp2 = {this->viewItem,this->toolsItem};
      this->optionsMenu->MenuItems->AddRange( temp2 );
      
      // Initialize the menu items for the shortcut menu.
      this->cutItem->Index = 0;
      this->cutItem->Text = "Cut";
      this->cutItem->MergeOrder = 0;
      this->copyItem->Index = 1;
      this->copyItem->Text = "Copy";
      this->copyItem->MergeOrder = 0;
      this->pasteItem->Index = 2;
      this->pasteItem->Text = "Paste";
      this->pasteItem->MergeOrder = 0;
      
      // Add menu items to the shortcut menu.
      array<MenuItem^>^temp3 = {cutItem,copyItem,pasteItem};
      this->contextMenu1->MenuItems->AddRange( temp3 );
      
      // Add the mainMenu1 items to the shortcut menu as well, by
      // calling the MergeMenu method.
      contextMenu1->MergeMenu( mainMenu1 );
      
      //Initialize the form.
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Right click on form for merged menu.";
      
      // Associate the event-handling method with the
      // MouseDown event.
      this->MouseDown += gcnew MouseEventHandler( this, &Form1::Form1_MouseDown );
      
      // Add mainMenu1 to the form.
      this->Menu = mainMenu1;
   }


private:
   void Form1_MouseDown( Object^ /*sender*/, MouseEventArgs^ e )
   {
      
      // Check for a right mouse click.
      if ( e->Button == ::MouseButtons::Right )
      {
         contextMenu1->Show( this, System::Drawing::Point( 30, 30 ) );
      }
   }

};


[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}

//</snippet1>
