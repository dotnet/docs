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
using namespace System::Diagnostics;

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

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }


protected:

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
      this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      //<snippet1>
      PerformanceCounter^ PC = gcnew PerformanceCounter;
      PC->CategoryName = "Process";
      PC->CounterName = "Private Bytes";
      PC->InstanceName = "Explorer";
      MessageBox::Show( PC->NextValue().ToString() );
      //</snippet1>

      // <snippet2>
      Array^ PerfCat = PerformanceCounterCategory::GetCategories();
      MessageBox::Show( String::Concat( "The number of performance counter categories in the local machine is ", PerfCat->Length ) );
      // </snippet2>
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

//Output:
//11.11 %
//11.11 Percent
