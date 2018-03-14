//<Snippet1>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

/*
This sample demonstrates how to perform a series of actions in a designer
transaction, how to change values of properties of a component from a
designer, and how to complete transactions without being interrupted
by other activities.

To run this sample, add this code to a class library project and compile.
Create a new Windows Forms project or load a form in the designer. Add a
reference to the class library that was compiled in the first step.
Right-click the Toolbox in design mode and click Customize Toolbox.
Browse to the class library that was compiled in the first step and
select OK until the DTComponent item appears in the Toolbox.  Add an
instance of this component to the form.

When the component is created and added to the component tray for your
design project, the Initialize method of the designer is called.
This method displays a message box informing you that designer transaction
event handlers will be registered unless you click Cancel. When you set
properties in the properties window, each change will be encapsulated in
a designer transaction, allowing the change to be undone later.

When you right-click the component, the shortcut menu for the component
is displayed. The designer constructs this menu according to whether
designer transaction notifications are enabled, and offers the option
of enabling or disabling the notifications, depending on the current
mode. The shortcut menu also presents a Perform Example Transaction
item, which will set the values of the component's StringProperty and
CountProperty properties. You can undo the last designer transaction using
the Undo command provided by the Visual Studio development environment.
*/

private ref class DTDesigner: public ComponentDesigner
{
private:
   bool notification_mode;
   int count;
   void LinkDTNotifications( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if (  !notification_mode )
      {
         IDesignerHost^ host = dynamic_cast<IDesignerHost^>(GetService( IDesignerHost::typeid ));
         if ( host != nullptr )
         {
            notification_mode = true;
            host->TransactionOpened += gcnew EventHandler( this, &DTDesigner::OnDesignerTransactionOpened );
            host->TransactionClosed += gcnew DesignerTransactionCloseEventHandler( this, &DTDesigner::OnDesignerTransactionClosed );
         }
      }
   }

   void UnlinkDTNotifications( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( notification_mode )
      {
         IDesignerHost^ host = dynamic_cast<IDesignerHost^>(GetService( IDesignerHost::typeid ));
         if ( host != nullptr )
         {
            notification_mode = false;
            host->TransactionOpened -= gcnew EventHandler( this, &DTDesigner::OnDesignerTransactionOpened );
            host->TransactionClosed -= gcnew DesignerTransactionCloseEventHandler( this, &DTDesigner::OnDesignerTransactionClosed );
         }
      }
   }

   void OnDesignerTransactionOpened( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "A Designer Transaction was started. (TransactionOpened)" );
   }

   void OnDesignerTransactionClosed( Object^ /*sender*/, DesignerTransactionCloseEventArgs^ /*e*/ )
   {
      MessageBox::Show( "A Designer Transaction was completed. (TransactionClosed)" );
   }

   void DoTransaction( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IDesignerHost^ host = static_cast<IDesignerHost^>(GetService( IDesignerHost::typeid ));
      DesignerTransaction^ t = host->CreateTransaction( "Change Text and Size" );
      
      /* The code within the using statement is considered to be a single transaction.
              When the user selects Undo, the system will undo everything executed in this code block.
              */
      if ( notification_mode )
            MessageBox::Show( "Entering a Designer-Initiated Designer Transaction" );

      // The .NET Framework automatically associates the TypeDescriptor with the correct component
      PropertyDescriptor^ someText = TypeDescriptor::GetProperties( Component )[ "StringProperty" ];
      someText->SetValue( Component, "This text was set by the designer for this component." );
      PropertyDescriptor^ anInteger = TypeDescriptor::GetProperties( Component )[ "CountProperty" ];
      anInteger->SetValue( Component, count );
      count++;

      // Complete the designer transaction.
      t->Commit();
      if ( notification_mode )
            MessageBox::Show( "Designer-Initiated Designer Transaction Completed" );
   }

public:
   property DesignerVerbCollection^ Verbs 
   {
      // The Verbs property is overridden from ComponentDesigner
      virtual DesignerVerbCollection^ get() override
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "Perform Example Transaction",gcnew EventHandler( this, &DTDesigner::DoTransaction ) ) );
         if ( notification_mode )
                  dvc->Add( gcnew DesignerVerb( "End Designer Transaction Notifications",
                     gcnew EventHandler( this, &DTDesigner::UnlinkDTNotifications ) ) );
         else
                  dvc->Add( gcnew DesignerVerb( "Show Designer Transaction Notifications",
                     gcnew EventHandler( this, &DTDesigner::LinkDTNotifications ) ) );

         return dvc;
      }
   }
   virtual void Initialize( IComponent^ component ) override
   {
      ComponentDesigner::Initialize( component );
      notification_mode = false;
      count = 10;
      IDesignerHost^ host = dynamic_cast<IDesignerHost^>(GetService( IDesignerHost::typeid ));
      if ( host == nullptr )
      {
         MessageBox::Show( "The IDesignerHost service interface could not be obtained." );
         return;
      }

      if ( MessageBox::Show( "Press the Yes button to display notification message boxes for the designer transaction opened and closed notifications.", "Link DesignerTransaction Notifications?", MessageBoxButtons::YesNo, MessageBoxIcon::Question, MessageBoxDefaultButton::Button1, MessageBoxOptions::RightAlign ) == DialogResult::Yes )
      {
         host->TransactionOpened += gcnew EventHandler( this, &DTDesigner::OnDesignerTransactionOpened );
         host->TransactionClosed += gcnew DesignerTransactionCloseEventHandler( this, &DTDesigner::OnDesignerTransactionClosed );
         notification_mode = true;
      }
   }

public:
   ~DTDesigner()
   {
      UnlinkDTNotifications( this, gcnew EventArgs );
   }
};

// Associate the DTDesigner with this component

[DesignerAttribute(DTDesigner::typeid)]
public ref class DTComponent: public System::ComponentModel::Component
{
private:
   String^ m_String;
   int m_Count;
   void InitializeComponent()
   {
      m_String = "Initial Value";
      m_Count = 0;
   }

public:
   property String^ StringProperty 
   {
      String^ get()
      {
         return m_String;
      }

      void set( String^ value )
      {
         m_String = value;
      }
   }

   property int CountProperty 
   {
      int get()
      {
         return m_Count;
      }

      void set( int value )
      {
         m_Count = value;
      }
   }
};
//</Snippet1>
