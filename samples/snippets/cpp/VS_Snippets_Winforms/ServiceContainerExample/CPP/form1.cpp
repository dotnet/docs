//<Snippet1>
#using <system.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

/* This sample uses the ServiceContainer class, which implements
    the IServiceContainer interface.  It creates a service container
    and stores services of type Control in it.

    When the application is run, it adds control services at two
    times:  when button2 is clicked and when a radio button is
    clicked.  It adds the controls to the container by calling each
    of two overloaded versions of IServiceContainer.AddService().

    Pressing button1 invokes the button1 handler, which is
    button1_Click().  In turn, this invokes a method based on
    whether or not button2 or a radio button has been selected.
    If one of these two button types has been selected, then its
    service has been added to the service container.  In this case,
    button1_Click() gets the current service, which invokes the
    method that was associated with this service when the service
    was added to the container.  If a radio button is current, the
    system updates the text of that radio button with the given text.
    If button2 is current, the system calls CreateNewControl(), which
    creates a new control with the given text.

    Pressing button2 invokes the button2 handler, which adds a service
    to the container by passing in a service creator callback.  This
    enables this action to invoke the event handler that the developer
    specifies.  In this case, the sample invokes CreateNewControl(),
    which creates and maintains label controls, and displays them in
    the same group box that the buttons are in.

    Clicking a radio button has the effect of adding that radio button
    to the service container.
*/

public ref class Form1: public Form
{
private:
   Button^ button1;
   GroupBox^ groupBox1;
   RadioButton^ radioButton1;
   RadioButton^ radioButton2;
   RadioButton^ radioButton3;
   RadioButton^ radioButton4;
   System::ComponentModel::Container^ components;
   Button^ button2;
   ServiceContainer^ m_MyServiceContainer;
   int m_nLabelCount;
   void InitializeComponent()
   {
      button1 = gcnew Button;
      groupBox1 = gcnew GroupBox;
      button2 = gcnew Button;
      radioButton4 = gcnew RadioButton;
      radioButton3 = gcnew RadioButton;
      radioButton2 = gcnew RadioButton;
      radioButton1 = gcnew RadioButton;
      groupBox1->SuspendLayout();
      SuspendLayout();

      //
      // button1
      //
      button1->Location = System::Drawing::Point( 24, 16 );
      button1->Name = "button1";
      button1->Size = System::Drawing::Size( 112, 32 );
      button1->TabIndex = 0;
      button1->Text = "button1";
      button1->Click += gcnew EventHandler( this, &Form1::button1_Click );

      //
      // groupBox1
      //
      array<Control^>^myArray = {button2,radioButton4,radioButton3,radioButton2,radioButton1};
      groupBox1->Controls->AddRange( myArray );
      groupBox1->Location = System::Drawing::Point( 8, 56 );
      groupBox1->Name = "groupBox1";
      groupBox1->Size = System::Drawing::Size( 272, 200 );
      groupBox1->TabIndex = 1;
      groupBox1->TabStop = false;
      groupBox1->Text = "groupBox1";

      //
      // button2
      //
      button2->Location = System::Drawing::Point( 40, 152 );
      button2->Name = "button2";
      button2->Size = System::Drawing::Size( 90, 26 );
      button2->TabIndex = 4;
      button2->Text = "button2";
      button2->Click += gcnew EventHandler( this, &Form1::button2_Click );

      //
      // radioButton4
      //
      radioButton4->Location = System::Drawing::Point( 32, 112 );
      radioButton4->Name = "radioButton4";
      radioButton4->TabIndex = 3;
      radioButton4->Text = "radioButton4";
      radioButton4->CheckedChanged += gcnew EventHandler( this, &Form1::radioButton1_CheckedChanged );

      //
      // radioButton3
      //
      radioButton3->Location = System::Drawing::Point( 32, 80 );
      radioButton3->Name = "radioButton3";
      radioButton3->TabIndex = 2;
      radioButton3->Text = "radioButton3";
      radioButton3->CheckedChanged += gcnew EventHandler( this, &Form1::radioButton1_CheckedChanged );

      //
      // radioButton2
      //
      radioButton2->Location = System::Drawing::Point( 32, 48 );
      radioButton2->Name = "radioButton2";
      radioButton2->TabIndex = 1;
      radioButton2->Text = "radioButton2";
      radioButton2->CheckedChanged += gcnew EventHandler( this, &Form1::radioButton1_CheckedChanged );

      //
      // radioButton1
      //
      radioButton1->Location = System::Drawing::Point( 32, 16 );
      radioButton1->Name = "radioButton1";
      radioButton1->TabIndex = 0;
      radioButton1->Text = "radioButton1";
      radioButton1->CheckedChanged += gcnew EventHandler( this, &Form1::radioButton1_CheckedChanged );

      //
      // Form1
      //
      ClientSize = System::Drawing::Size( 292, 272 );
      myArray = gcnew array<Control^>(2);
      myArray[ 0 ] = groupBox1;
      myArray[ 1 ] = button1;
      Controls->AddRange( myArray );
      Name = "Form1";
      Text = "Form1";
      groupBox1->ResumeLayout( false );
      ResumeLayout( false );
   }

   void radioButton1_CheckedChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      /* The application never displays this control so a generic
                 type of Control is fine */
      m_MyServiceContainer->RemoveService( Control::typeid );
      
      //<Snippet2>
      m_MyServiceContainer->AddService( Control::typeid, sender );
      //</Snippet2>
   }

   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      /* Get the current control, if one is current.  Here it's either a
                 push button or a radio control */
      Control^ c = dynamic_cast<Control^>(m_MyServiceContainer->GetService( Control::typeid ));
      if ( c != nullptr )
      {
         
         // Update the text of whichever control is currently selected.
         c->Text = "Button1 clicked";
      }
   }

   void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      /* ServiceContainer will throw an excpetion if a duplicate service
                 is added so remove it before we add */
      //<Snippet4>
      m_MyServiceContainer->RemoveService( Control::typeid );
      //</Snippet4>
      /* Whenever button2 is pressed, attach the callback method to the service
                 and add the service to the container.  This causes any update to
                 invoke CreateNewControl() when button1 is pressed */
      //<Snippet3>
      m_MyServiceContainer->AddService( Control::typeid, gcnew ServiceCreatorCallback( this, &Form1::CreateNewControl ) );
      //</Snippet3>
   }

   /* If the application arrives at this method, it means that in button1_Click(),
          GetService() was passed the service that corresponds to button2.  This has
          the effect of invoking the service creator callback for button2, which is
          the method CreateNewControl(), and which was mapped in button2_Click(). */
   Object^ CreateNewControl( IServiceContainer^ /*container*/, Type^ /*serviceType*/ )
   {
      Control^ c = gcnew Label;
      c->Size = radioButton1->Size;
      Point loc = button2->Location;
      loc.X = 160;
      loc.Y = 20 + 25 * m_nLabelCount;
      c->Location = loc;
      groupBox1->Controls->Add( c );
      ++m_nLabelCount;
      return c;
   }

public:
   Form1()
   {
      m_MyServiceContainer = gcnew ServiceContainer;
      InitializeComponent();
   }

public:
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }
};

// The main entry point for the application.

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
