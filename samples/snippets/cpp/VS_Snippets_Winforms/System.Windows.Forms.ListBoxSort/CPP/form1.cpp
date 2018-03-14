

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

//<snippet1>
// The following code example demonstrates using the ListBox.Sort method
// by inheriting from the ListBox class and overriding the Sort method.
using namespace System::Drawing;
using namespace System::Windows::Forms;

// This class inherits from ListBox and implements a different 
// sorting method. Sort will be called by setting the class's Sorted
// property to True.
public ref class SortByLengthListBox: public ListBox
{
public:
   SortByLengthListBox()
      : ListBox()
   {}

protected:

   // Overrides the parent class Sort to perform a simple
   // bubble sort on the length of the string contained in each item.
   virtual void Sort() override
   {
      if ( Items->Count > 1 )
      {
         bool swapped;
         do
         {
            int counter = Items->Count - 1;
            swapped = false;
            while ( counter > 0 )
            {
               
               // Compare the items' length. 
               if ( Items[ counter ]->ToString()->Length < Items[ counter - 1 ]->ToString()->Length )
               {
                  
                  // Swap the items.
                  Object^ temp = Items[ counter ];
                  Items[ counter ] = Items[ counter - 1 ];
                  Items[ counter - 1 ] = temp;
                  swapped = true;
               }
               
               // Decrement the counter.
               counter -= 1;
            }
         }
         while ( (swapped == true) );
      }
   }
};

public ref class Form1: public System::Windows::Forms::Form
{
internal:
   System::Windows::Forms::Button^ Button1;
   SortByLengthListBox^ sortingBox;

public:
   Form1()
      : Form()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->sortingBox = gcnew SortByLengthListBox;
      this->SuspendLayout();
      this->Button1->Location = System::Drawing::Point( 64, 16 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 176, 23 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click me for list sorted by length";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      array<Object^>^temp0 = {"System","System.Windows.Forms","System.Xml","System.Net","System.Drawing","System.IO"};
      this->sortingBox->Items->AddRange( temp0 );
      this->sortingBox->Location = System::Drawing::Point( 72, 48 );
      this->sortingBox->Size = System::Drawing::Size( 120, 95 );
      this->sortingBox->TabIndex = 1;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->sortingBox );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Sort Example";
      this->ResumeLayout( false );
   }

private:
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Set the Sorted property to True to raise the overridden Sort
      // method.
      sortingBox->Sorted = true;
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}
//</snippet1>
