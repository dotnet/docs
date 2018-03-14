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
   void Menu_Copy( System::Object^ sender, System::EventArgs^ e )
   {
      // Ensure that text is selected in the text box.   
      if ( textBox1->SelectionLength > 0 )
      {
         // Copy the selected text to the Clipboard.
         textBox1->Copy();
      }
   }

   void Menu_Cut( System::Object^ sender, System::EventArgs^ e )
   {
      // Ensure that text is currently selected in the text box.   
      if (  !textBox1->SelectedText->Equals( "" ) )
      {
         // Cut the selected text in the control and paste it into the Clipboard.
         textBox1->Cut();
      }
   }

   void Menu_Paste( System::Object^ sender, System::EventArgs^ e )
   {
      // Determine if there is any text in the Clipboard to paste into the text box.
      if ( Clipboard::GetDataObject()->GetDataPresent( DataFormats::Text ) == true )
      {
         // Determine if any text is selected in the text box.
         if ( textBox1->SelectionLength > 0 )
         {
            // Ask user if they want to paste over currently selected text.
            if ( MessageBox::Show( "Do you want to paste over current selection?",
               "Cut Example", MessageBoxButtons::YesNo ) == ::DialogResult::No )
            {
               // Move selection to the point after the current selection and paste.
               textBox1->SelectionStart = textBox1->SelectionStart +
                  textBox1->SelectionLength;
            }
         }
         // Paste current text in Clipboard into text box.
         textBox1->Paste();
      }
   }

   void Menu_Undo( System::Object^ sender, System::EventArgs^ e )
   {
      // Determine if last operation can be undone in text box.   
      if ( textBox1->CanUndo == true )
      {
         // Undo the last operation.
         textBox1->Undo();
         // Clear the undo buffer to prevent last action from being redone.
         textBox1->ClearUndo();
      }
   }
   // </Snippet1>
};
