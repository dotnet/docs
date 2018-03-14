#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   ImageList^ imageList1;
   System::Windows::Forms::ContextMenu^ contextMenu1;
   MenuItem^ menuItem1;

   // <Snippet1>
public:
   void InitializeMyToolBar()
   {
      // Create the ToolBar, ToolBarButton controls, and menus.
      ToolBarButton^ toolBarButton1 = gcnew ToolBarButton( "Open" );
      ToolBarButton^ toolBarButton2 = gcnew ToolBarButton;
      ToolBarButton^ toolBarButton3 = gcnew ToolBarButton;
      ToolBar^ toolBar1 = gcnew ToolBar;
      MenuItem^ menuItem1 = gcnew MenuItem( "Print" );
      array<MenuItem^>^ temp1 = {menuItem1};
      System::Windows::Forms::ContextMenu^ contextMenu1 =
         gcnew System::Windows::Forms::ContextMenu( temp1 );
      
      // Add the ToolBarButton controls to the ToolBar.
      toolBar1->Buttons->Add( toolBarButton1 );
      toolBar1->Buttons->Add( toolBarButton2 );
      toolBar1->Buttons->Add( toolBarButton3 );
      
      // Assign an ImageList to the ToolBar and show ToolTips.
      toolBar1->ImageList = imageList1;
      toolBar1->ShowToolTips = true;
      
      /* Assign ImageIndex, ContextMenu, Text, ToolTip, and 
         Style properties of the ToolBarButton controls. */
      toolBarButton2->Style = ToolBarButtonStyle::Separator;
      toolBarButton3->Text = "Print";
      toolBarButton3->Style = ToolBarButtonStyle::DropDownButton;
      toolBarButton3->ToolTipText = "Print";
      toolBarButton3->ImageIndex = 0;
      toolBarButton3->DropDownMenu = contextMenu1;
      
      // Add the ToolBar to a form.
      Controls->Add( toolBar1 );
   }
   // </Snippet1>
};
