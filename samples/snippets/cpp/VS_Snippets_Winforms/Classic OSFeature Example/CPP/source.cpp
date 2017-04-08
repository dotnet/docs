#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void LayeredWindows()
   {
      // Gets the version of the layered windows feature.
      Version^ myVersion = OSFeature::Feature->GetVersionPresent(
         OSFeature::LayeredWindows );
      
      // Prints whether the feature is available.
      if ( myVersion != nullptr )
      {
         textBox1->Text = "Layered windows feature is installed.\n";
      }
      else
      {
         textBox1->Text = "Layered windows feature is not installed.\n";
      }

      
      // This is an alternate way to check whether a feature is present.
      if ( OSFeature::Feature->IsPresent( OSFeature::LayeredWindows ) )
      {
         textBox1->Text = String::Concat( textBox1->Text,
            "Again, layered windows feature is installed." );
      }
      else
      {
         textBox1->Text = String::Concat( textBox1->Text,
            "Again, layered windows feature is not installed." );
      }
   }
   // </Snippet1>
};
