

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
public ref class MyToolBar: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::ToolBar^ toolBar1;
   System::Windows::Forms::ImageList^ imageList1;
   System::Windows::Forms::ToolBarButton^ toolBarButton1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::TextBox^ textBox1;
   System::ComponentModel::IContainer^ components;
   System::Windows::Forms::ContextMenu^ contextMenu1;
   MenuItem^ menuItem1;
   MenuItem^ menuItem2;

public:
   MyToolBar()
   {
      InitializeComponent();
      this->AddToolBar();
   }


public:
   ~MyToolBar()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->imageList1 = gcnew System::Windows::Forms::ImageList( this->components );
      this->imageList1->Images->Add( Image::FromFile( "c:\\copy.bmp" ) );
      this->imageList1->Images->Add( Image::FromFile( "c:\\button.bmp" ) );
      this->imageList1->Images->Add( Image::FromFile( "c:\\camera.bmp" ) );
      
      // System::Resources::ResourceManager* resources = new System::Resources::ResourceManager(__typeof(MyToolBar));
      // this->imageList1 = new System::Windows::Forms::ImageList(this->components);
      this->toolBarButton1 = gcnew System::Windows::Forms::ToolBarButton;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->menuItem1 = gcnew MenuItem( "Clear" );
      this->menuItem2 = gcnew MenuItem( "Test" );
      array<MenuItem^>^menuItems = {menuItem1,menuItem2};
      this->contextMenu1 = gcnew System::Windows::Forms::ContextMenu( menuItems );
      this->SuspendLayout();
      
      // 
      // imageList1
      // 
      this->imageList1->ColorDepth = System::Windows::Forms::ColorDepth::Depth8Bit;
      this->imageList1->ImageSize = System::Drawing::Size( 16, 16 );
      
      //this->imageList1.ImageStream = ((System::Windows::Forms::ImageListStreamer)(resources.GetObject(S"imageList1.ImageStream")));
      this->imageList1->TransparentColor = System::Drawing::Color::Transparent;
      
      // 
      // toolBarButton1
      // 
      this->toolBarButton1->ImageIndex = 0;
      this->toolBarButton1->Style = System::Windows::Forms::ToolBarButtonStyle::DropDownButton;
      this->toolBarButton1->DropDownMenu = this->contextMenu1;
      
      // 
      // button1
      //
      this->button1->Location = System::Drawing::Point( 24, 192 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &MyToolBar::button1_Click );
      
      // 
      // button2
      //
      this->button2->Location = System::Drawing::Point( 136, 200 );
      this->button2->Name = "button2";
      this->button2->TabIndex = 2;
      this->button2->Text = "button2";
      this->button2->Click += gcnew System::EventHandler( this, &MyToolBar::button2_Click );
      
      // 
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 96, 144 );
      this->textBox1->Name = "textBox1";
      this->textBox1->TabIndex = 3;
      this->textBox1->Text = "textBox1";
      
      // 
      // MyToolBar
      //
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^formControls = {this->textBox1,this->button2,this->button1};
      this->Controls->AddRange( formControls );
      this->Name = "MyToolBar";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   // <snippet1>
   void AddToolBar()
   {
      
      // Add a toolbar and set some of its properties.
      toolBar1 = gcnew ToolBar;
      toolBar1->Appearance = System::Windows::Forms::ToolBarAppearance::Flat;
      toolBar1->BorderStyle = System::Windows::Forms::BorderStyle::None;
      toolBar1->Buttons->Add( this->toolBarButton1 );
      toolBar1->ButtonSize = System::Drawing::Size( 24, 24 );
      toolBar1->Divider = true;
      toolBar1->DropDownArrows = true;
      toolBar1->ImageList = this->imageList1;
      toolBar1->ShowToolTips = true;
      toolBar1->Size = System::Drawing::Size( 292, 25 );
      toolBar1->TabIndex = 0;
      toolBar1->TextAlign = System::Windows::Forms::ToolBarTextAlign::Right;
      toolBar1->Wrappable = false;
      
      // Add handlers for the ButtonClick and ButtonDropDown events.
      toolBar1->ButtonDropDown += gcnew ToolBarButtonClickEventHandler( this, &MyToolBar::toolBar1_ButtonDropDown );
      toolBar1->ButtonClick += gcnew ToolBarButtonClickEventHandler( this, &MyToolBar::toolBar1_ButtonClicked );
      
      // Add the toolbar to the form.
      this->Controls->Add( toolBar1 );
   }
   // </snippet1>

   // <snippet2>
   void AddToolbarButtons( ToolBar^ toolBar )
   {
      if (  !toolBar->Buttons->IsReadOnly )
      {
         
         // If toolBarButton1 in in the collection, remove it.
         if ( toolBar->Buttons->Contains( toolBarButton1 ) )
         {
            toolBar->Buttons->Remove( toolBarButton1 );
         }
         
         // Create three toolbar buttons.
         ToolBarButton^ tbb1 = gcnew ToolBarButton( "tbb1" );
         ToolBarButton^ tbb2 = gcnew ToolBarButton( "tbb2" );
         ToolBarButton^ tbb3 = gcnew ToolBarButton( "tbb3" );
         
         // Add toolbar buttons to the toolbar.
         array<ToolBarButton^>^buttons = {tbb2,tbb3};
         toolBar->Buttons->AddRange( buttons );
         toolBar->Buttons->Add( "tbb4" );
         
         // Insert tbb1 into the first position in the collection.
         toolBar->Buttons->Insert( 0, tbb1 );
      }
   }
   // </snippet2>

   // <snippet3>
   String^ GetButtonList( ToolBar^ toolBar )
   {
      String^ buttonList = "ToolBarButtons: ";
      IEnumerator^ x = toolBar->Buttons->GetEnumerator();
      
      // Enumerate through the collection of toolbar buttons.
      while ( x->MoveNext() )
      {
         buttonList = String::Concat( buttonList, (dynamic_cast<ToolBarButton^>(x->Current))->Text, " " );
      }

      return buttonList;
   }
   // </snippet3>

   //<snippet4>
   void toolBar1_ButtonDropDown( Object^ /*sender*/, System::Windows::Forms::ToolBarButtonClickEventArgs^ /*e*/ )
   {
      
      // If the text box is disabled, disable the menu item.
      if (  !textBox1->Enabled )
      {
         contextMenu1->MenuItems[ this->contextMenu1->MenuItems->IndexOf( menuItem1 ) ]->Enabled = false;
      }
   }

   void toolBar1_ButtonClicked( Object^ /*sender*/, System::Windows::Forms::ToolBarButtonClickEventArgs^ /*e*/ )
   {
      
      // Disable the text box.
      textBox1->Enabled = false;
   }
   // </snippet4>

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      AddToolbarButtons( this->toolBar1 );
   }

   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( this->GetButtonList( toolBar1 ) );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyToolBar );
}
