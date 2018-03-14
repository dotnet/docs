

//<Snippet1>
#using <System.dll>
#using <System.Design.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Data;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

namespace IToolboxServiceExample
{

   // This designer passes window messages to the controls at design time.
   public ref class WindowMessageDesigner: public System::Windows::Forms::Design::ControlDesigner
   {
   public:
      WindowMessageDesigner(){}

   protected:

      // Window procedure  passes events to control.

      [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
      virtual void WndProc( System::Windows::Forms::Message% m ) override
      {
         if ( m.HWnd == this->Control->Handle )
                  ControlDesigner::WndProc( m );
         else
                  ControlDesigner::DefWndProc( m );
      }
   };

   // Provides an example control that functions in design mode to
   // demonstrate use of the IToolboxService to list and select toolbox
   // categories and items, and to add components or controls
   // to the parent form using code.

   [DesignerAttribute(IToolboxServiceExample::WindowMessageDesigner::typeid,IDesigner::typeid)]
   public ref class IToolboxServiceControl: public System::Windows::Forms::UserControl
   {
   private:
      System::Windows::Forms::ListBox^ listBox1;
      System::Windows::Forms::ListBox^ listBox2;
      IToolboxService^ toolboxService;
      ToolboxItemCollection^ tools;
      int controlSpacingMultiplier;

   public:
      IToolboxServiceControl()
      {
         InitializeComponent();
         listBox2->DoubleClick += gcnew EventHandler( this, &IToolboxServiceControl::CreateComponent );
         controlSpacingMultiplier = 0;
      }

      property System::ComponentModel::ISite^ Site 
      {
         // Obtain or reset IToolboxService reference on each siting of control.
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            __super::Site = value;

            // If the component was sited, attempt to obtain
            // an IToolboxService instance.
            if ( __super::Site != nullptr )
            {
               toolboxService = dynamic_cast<IToolboxService^>(this->GetService( IToolboxService::typeid ));

               // If an IToolboxService was located, update the
               // category list.
               if ( toolboxService != nullptr )
                              UpdateLists();
            }
            else
                        toolboxService = nullptr;
         }
      }

   private:

      // Updates the list of categories and the list of items in the
      // selected category.
      [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
      void UpdateLists()
      {
         if ( toolboxService != nullptr )
         {
            this->listBox1->SelectedIndexChanged -= gcnew System::EventHandler( this, &IToolboxServiceControl::UpdateSelectedCategory );
            this->listBox2->SelectedIndexChanged -= gcnew System::EventHandler( this, &IToolboxServiceControl::UpdateSelectedItem );
            listBox1->Items->Clear();
            for ( int i = 0; i < toolboxService->CategoryNames->Count; i++ )
            {
               listBox1->Items->Add( toolboxService->CategoryNames[ i ] );
               if ( toolboxService->CategoryNames[ i ] == toolboxService->SelectedCategory )
               {
                  listBox1->SelectedIndex = i;
                  tools = toolboxService->GetToolboxItems( toolboxService->SelectedCategory );
                  listBox2->Items->Clear();
                  for ( int j = 0; j < tools->Count; j++ )
                     listBox2->Items->Add( tools[ j ]->DisplayName );
               }
            }
            this->listBox1->SelectedIndexChanged += gcnew System::EventHandler( this, &IToolboxServiceControl::UpdateSelectedCategory );
            this->listBox2->SelectedIndexChanged += gcnew System::EventHandler( this, &IToolboxServiceControl::UpdateSelectedItem );
         }
      }


      // Sets the selected category when a category is clicked in the
      // category list.
      void UpdateSelectedCategory( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( toolboxService != nullptr )
         {
            toolboxService->SelectedCategory = dynamic_cast<String^>(listBox1->SelectedItem);
            UpdateLists();
         }
      }

      // Sets the selected item when an item is clicked in the item list.
      void UpdateSelectedItem( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( toolboxService != nullptr )
         {
            if ( listBox1->SelectedIndex != -1 )
            {
               if ( dynamic_cast<String^>(listBox1->SelectedItem) == toolboxService->SelectedCategory )
                              toolboxService->SetSelectedToolboxItem( tools[ listBox2->SelectedIndex ] );
               else
                              UpdateLists();
            }
         }
      }

      // Creates a control from a double-clicked toolbox item and adds
      // it to the parent form.
      void CreateComponent( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Obtains an IDesignerHost service from design environment.
         IDesignerHost^ host = dynamic_cast<IDesignerHost^>(this->GetService( IDesignerHost::typeid ));

         // Get the project components container (Windows Forms control
         // containment depends on controls collections).
         IContainer^ container = host->Container;

         // Identifies the parent Form.
         System::Windows::Forms::Form^ parentForm = this->FindForm();

         // Retrieves the parent Form's designer host.
         IDesignerHost^ parentHost = dynamic_cast<IDesignerHost^>(parentForm->Site->GetService( IDesignerHost::typeid ));

         // Create the components.
         array<IComponent^>^comps = nullptr;
         try
         {
            comps = toolboxService->GetSelectedToolboxItem()->CreateComponents( parentHost );
         }
         catch ( Exception^ ex ) 
         {
            // Catch and show any exceptions to prevent disabling
            // the control's UI.
            MessageBox::Show( ex->ToString(), "Exception message" );
         }

         if ( comps == nullptr )
                  return;

         // Add any created controls to the parent form's controls
         // collection. Note: components are added from the
         // ToolboxItem::CreateComponents(IDesignerHost*) method.
         for ( int i = 0; i < comps->Length; i++ )
         {
            if ( parentForm != nullptr && comps[ i ]->GetType()->IsSubclassOf( System::Windows::Forms::Control::typeid ) )
            {
               (dynamic_cast<System::Windows::Forms::Control^>(comps[ i ]))->Location = Point(20 * controlSpacingMultiplier,20 * controlSpacingMultiplier);
               if ( controlSpacingMultiplier > 10 )
                              controlSpacingMultiplier = 0;
               else
                              controlSpacingMultiplier++;
               parentForm->Controls->Add( dynamic_cast<System::Windows::Forms::Control^>(comps[ i ]) );
            }
         }
      }

   protected:

      // Displays labels.
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         e->Graphics->DrawString( "IToolboxService Control", gcnew System::Drawing::Font( "Arial",14 ), gcnew SolidBrush( Color::Black ), 6, 4 );
         e->Graphics->DrawString( "Category List", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 8, 26 );
         e->Graphics->DrawString( "Items in Category", gcnew System::Drawing::Font( "Arial",8 ), gcnew SolidBrush( Color::Black ), 208, 26 );
         e->Graphics->DrawString( "(Double-click item to add to parent form)", gcnew System::Drawing::Font( "Arial",7 ), gcnew SolidBrush( Color::Black ), 232, 12 );
      }

   private:
      void InitializeComponent()
      {
         this->listBox1 = gcnew System::Windows::Forms::ListBox;
         this->listBox2 = gcnew System::Windows::Forms::ListBox;
         this->SuspendLayout();
         this->listBox1->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left);
         this->listBox1->Location = System::Drawing::Point( 8, 41 );
         this->listBox1->Name = "listBox1";
         this->listBox1->Size = System::Drawing::Size( 192, 368 );
         this->listBox1->TabIndex = 0;
         this->listBox1->SelectedIndexChanged += gcnew System::EventHandler( this, &IToolboxServiceControl::UpdateSelectedCategory );
         this->listBox2->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
         this->listBox2->Location = System::Drawing::Point( 208, 41 );
         this->listBox2->Name = "listBox2";
         this->listBox2->Size = System::Drawing::Size( 228, 368 );
         this->listBox2->TabIndex = 3;
         this->BackColor = System::Drawing::Color::Beige;
         array<System::Windows::Forms::Control^>^temp0 = {this->listBox2,this->listBox1};
         this->Controls->AddRange( temp0 );
         this->Location = System::Drawing::Point( 500, 400 );
         this->Name = "IToolboxServiceControl*";
         this->Size = System::Drawing::Size( 442, 422 );
         this->ResumeLayout( false );
      }
   };
}
//</Snippet1>
