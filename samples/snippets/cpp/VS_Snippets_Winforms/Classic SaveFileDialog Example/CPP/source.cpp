#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;
   DataSet^ dataSet1;

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Stream^ myStream;
      SaveFileDialog^ saveFileDialog1 = gcnew SaveFileDialog;
      saveFileDialog1->Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1->FilterIndex = 2;
      saveFileDialog1->RestoreDirectory = true;
      if ( saveFileDialog1->ShowDialog() == ::DialogResult::OK )
      {
         if ( (myStream = saveFileDialog1->OpenFile()) != nullptr )
         {
            
            // Code to write the stream goes here.
            myStream->Close();
         }
      }
   }

   // </Snippet1>
};
