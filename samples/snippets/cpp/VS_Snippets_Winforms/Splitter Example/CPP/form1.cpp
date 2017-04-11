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

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      CreateMySplitControls();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

   //<snippet1>
private:
   void CreateMySplitControls()
   {
      // Create TreeView, ListView, and Splitter controls.
      TreeView^ treeView1 = gcnew TreeView;
      ListView^ listView1 = gcnew ListView;
      Splitter^ splitter1 = gcnew Splitter;

      // Set the TreeView control to dock to the left side of the form.
      treeView1->Dock = DockStyle::Left;

      // Set the Splitter to dock to the left side of the TreeView control.
      splitter1->Dock = DockStyle::Left;

      // Set the minimum size the ListView control can be sized to.
      splitter1->MinExtra = 100;

      // Set the minimum size the TreeView control can be sized to.
      splitter1->MinSize = 75;

      // Set the ListView control to fill the remaining space on the form.
      listView1->Dock = DockStyle::Fill;

      // Add a TreeView and a ListView item to identify the controls on the form.
      treeView1->Nodes->Add( "TreeView Node" );
      listView1->Items->Add( "ListView Item" );

      // Add the controls in reverse order to the form to ensure proper location.
      array<Control^>^temp0 = {listView1,splitter1,treeView1};
      this->Controls->AddRange( temp0 );
   }
   //</snippet1>

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
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 384, 365 );
      this->Name = "Form1";
      this->Text = "Form1";
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
