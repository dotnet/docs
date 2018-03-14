

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace ControlMembers4
{
   public ref class Form2: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Panel^ panel1;
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::StatusBar^ statusBar1;
      System::Windows::Forms::TreeView^ treeView1;
      System::Windows::Forms::ContextMenu^ contextMenu1;
      System::Windows::Forms::MenuItem^ menuItem1;
      System::Windows::Forms::MenuItem^ menuItem2;
      System::Windows::Forms::MenuItem^ menuItem3;
      System::Windows::Forms::Label ^ label1;
      System::ComponentModel::Container^ components;

   public:
      Form2()
      {
         components = nullptr;
         InitializeComponent();
      }

   protected:
   ~Form2()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

   private:
      void InitializeComponent()
      {
         this->panel1 = gcnew System::Windows::Forms::Panel;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->statusBar1 = gcnew System::Windows::Forms::StatusBar;
         this->treeView1 = gcnew System::Windows::Forms::TreeView;
         this->contextMenu1 = gcnew System::Windows::Forms::ContextMenu;
         this->menuItem1 = gcnew System::Windows::Forms::MenuItem;
         this->menuItem2 = gcnew System::Windows::Forms::MenuItem;
         this->menuItem3 = gcnew System::Windows::Forms::MenuItem;
         this->panel1->SuspendLayout();
         this->SuspendLayout();

         //
         // panel1
         //
         this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
         array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->label1};
         this->panel1->Controls->AddRange( temp0 );
         this->panel1->Location = System::Drawing::Point( 48, 40 );
         this->panel1->Name = "panel1";
         this->panel1->TabIndex = 0;

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 16, 16 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form2::button1_Click );

         //
         // label1
         //
         this->label1->Location = System::Drawing::Point( 16, 16 );
         this->label1->Name = "label1";
         this->label1->TabIndex = 2;
         this->label1->Text = "label1";

         //
         // statusBar1
         //
         this->statusBar1->Location = System::Drawing::Point( 0, 295 );
         this->statusBar1->Name = "statusBar1";
         this->statusBar1->Size = System::Drawing::Size( 320, 22 );
         this->statusBar1->TabIndex = 1;
         this->statusBar1->Text = "statusBar1";

         //
         // treeView1
         //
         this->treeView1->ContextMenu = this->contextMenu1;
         this->treeView1->ImageIndex = -1;
         this->treeView1->Location = System::Drawing::Point( 64, 152 );
         this->treeView1->Name = "treeView1";
         array<System::Windows::Forms::TreeNode^>^temp1 = {gcnew System::Windows::Forms::TreeNode( "Node2" )};
         array<System::Windows::Forms::TreeNode^>^temp2 = {gcnew System::Windows::Forms::TreeNode( "Node1",temp1 )};
         array<System::Windows::Forms::TreeNode^>^temp3 = {gcnew System::Windows::Forms::TreeNode( "Node0",temp2 )};
         this->treeView1->Nodes->AddRange( temp3 );
         this->treeView1->SelectedImageIndex = -1;
         this->treeView1->TabIndex = 2;
         this->treeView1->KeyDown += gcnew System::Windows::Forms::KeyEventHandler( this, &Form2::treeView1_KeyDown );
         this->treeView1->AfterLabelEdit += gcnew System::Windows::Forms::NodeLabelEditEventHandler( this, &Form2::treeView1_AfterLabelEdit );

         //
         // contextMenu1
         //
         array<System::Windows::Forms::MenuItem^>^temp4 = {this->menuItem1,this->menuItem2,this->menuItem3};
         this->contextMenu1->MenuItems->AddRange( temp4 );

         //
         // menuItem1
         //
         this->menuItem1->Index = 0;
         this->menuItem1->Text = "Edit";

         //
         // menuItem2
         //
         this->menuItem2->Index = 1;
         this->menuItem2->Text = "Expand";

         //
         // menuItem3
         //
         this->menuItem3->Index = 2;
         this->menuItem3->Text = "Collapse";

         //
         // Form2
         //
         this->ClientSize = System::Drawing::Size( 320, 317 );
         this->DoubleClick += gcnew System::EventHandler( this, &Form2::Form2_DoubleClick );
         array<System::Windows::Forms::Control^>^temp5 = {this->treeView1,this->statusBar1,this->panel1};
         this->Controls->AddRange( temp5 );
         this->Name = "Form2";
         this->Text = "Form2";
         this->panel1->ResumeLayout( false );
         this->ResumeLayout( false );
      }

      void Form2_DoubleClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->MakeLabelVisible();
      }

      // <snippet1>
   private:
      void MakeLabelVisible()
      {
         
         /* If the panel contains label1, bring it
            * to the front to make sure it is visible. */
         if ( panel1->Contains( label1 ) )
         {
            label1->BringToFront();
         }
      }
      // </snippet1>

      // <snippet2>
   private:
      void button1_Click( Object^ sender, System::EventArgs^ /*e*/ )
      {
         /* If the CTRL key is pressed when the
            * control is clicked, hide the control. */
         if ( Control::ModifierKeys == Keys::Control )
         {
            (dynamic_cast<Control^>(sender))->Hide();
         }
      }
      // </snippet2>

      // <snippet3>
   private:
      void treeView1_KeyDown( Object^ /*sender*/, KeyEventArgs^ e )
      {
         /* If the 'Alt' and 'E' keys are pressed,
            * allow the user to edit the TreeNode label. */
         if ( e->Alt && e->KeyCode == Keys::E )
         {
            treeView1->LabelEdit = true;
            
            // If there is a TreeNode under the mose cursor, begin editing.
            TreeNode^ editNode = treeView1->GetNodeAt( treeView1->PointToClient( Control::MousePosition ) );
            if ( editNode != nullptr )
            {
               editNode->BeginEdit();
            }
         }
      }

      void treeView1_AfterLabelEdit( Object^ /*sender*/, NodeLabelEditEventArgs^ /*e*/ )
      {
         // Disable the ability to edit the TreeNode labels.
         treeView1->LabelEdit = false;
      }
      // </snippet3>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlMembers4::Form2 );
}
