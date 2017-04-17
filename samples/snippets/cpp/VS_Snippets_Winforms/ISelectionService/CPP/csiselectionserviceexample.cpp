//<snippet1>
#using <system.drawing.dll>
#using <system.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

/*  This sample illustrates how to use the ISelectionService
    interface to handle selection change events.  The ComponentClass
    control attaches event handlers when it is sited in a document
    that displays a message when a component is selected or deselected.

    To run this sample, add the ComponentClass control to a Form and
    then select and deselect the component to see the behavior of the
    component change event handlers. */

public ref class ComponentClass: public UserControl
{
private:
   System::ComponentModel::Container^ components;
   ListBox^ listBox1;
   ISelectionService^ m_selectionService;
   void InitializeComponent()
   {
      listBox1 = gcnew ListBox;
      SuspendLayout();

      // listBox1
      listBox1->Location = Point(24,16);
      listBox1->Name = "listBox1";
      listBox1->Size = System::Drawing::Size( 560, 251 );
      listBox1->TabIndex = 0;
      listBox1->SelectedIndexChanged += gcnew EventHandler( this, &ComponentClass::listBox1_SelectedIndexChanged );

      // ComponentClass
      array<Control^>^myArray = {listBox1};
      Controls->AddRange( myArray );
      Name = "ComponentClass";
      Size = System::Drawing::Size( 608, 296 );
      Load += gcnew EventHandler( this, &ComponentClass::ComponentClass_Load );
      ResumeLayout( false );
   }

   //<snippet3>
   /* This is the OnSelectionChanged handler method.  This method calls
       OnUserChange to display a message that indicates the name of the
       handler that made the call and the type of the event argument. */
   void OnSelectionChanged( Object^ /*sender*/, EventArgs^ args )
   {
      OnUserChange( "OnSelectionChanged", args->ToString() );
   }
   //</snippet3>

   //<snippet5>
   /* This is the OnSelectionChanging handler method.  This method calls
       OnUserChange to display a message that indicates the name of the
       handler that made the call and the type of the event argument. */
   void OnSelectionChanging( Object^ /*sender*/, EventArgs^ args )
   {
      OnUserChange( "OnSelectionChanging", args->ToString() );
   }
   //</snippet5>

   // In this sample, all event handlers call this method
   void OnUserChange( String^ text1, String^ text2 )
   {
      listBox1->Items->Add( String::Concat( "Called ", text1, " using ", text2, "." ) );
   }

   void ComponentClass_Load( Object^, EventArgs^ ){}

   void listBox1_SelectedIndexChanged( Object^ /*sender*/, EventArgs^ /*e*/ ){}

public:
   ComponentClass()
   {
      InitializeComponent();
   }

   property ISite^ Site 
   {
      virtual ISite^ ComponentClass::get() override
      {
         return __super::Site;
      }

      virtual void ComponentClass::set( ISite^ value ) override
      {
         // This value will always be null when not in design mode
         m_selectionService = static_cast<ISelectionService^>(GetService( ISelectionService::typeid ));

         /* The Selection Service works in design mode only, and only after the component is sited.
                 So add our services at this time */
         if ( m_selectionService != nullptr )
         {
            // We are about to be re-sited.  Clear our old selection change events.
            m_selectionService->SelectionChanged -= gcnew EventHandler( this, &ComponentClass::OnSelectionChanged );
            m_selectionService->SelectionChanging -= gcnew EventHandler( this, &ComponentClass::OnSelectionChanging );
         }

         __super::Site = value;

         // This value will always be null when not in design mode
         m_selectionService = static_cast<ISelectionService^>(GetService( ISelectionService::typeid ));
         
         /* The Selection Service works in design mode only, and only after the component is sited.
                 So add our services at this time */
         if ( m_selectionService != nullptr )
         {
            //<snippet2>
            // Add SelectionChanged event handler to event
            m_selectionService->SelectionChanged += gcnew EventHandler( this, &ComponentClass::OnSelectionChanged );
            //</snippet2>

            //<snippet4>
            // Add SelectionChanging event handler to event
            m_selectionService->SelectionChanging += gcnew EventHandler( this, &ComponentClass::OnSelectionChanging );
            //</snippet4>
         }
      }
   }

public:

   // Clean up any resources being used.
   ~ComponentClass()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }
};
//</snippet1>
