

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeListViewItems();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::ListView^ ListView1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->ListView1 = gcnew System::Windows::Forms::ListView;
      this->SuspendLayout();
      
      //
      //ListView1
      //
      this->ListView1->Location = System::Drawing::Point( 120, 72 );
      this->ListView1->Name = "ListView1";
      this->ListView1->TabIndex = 0;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->ListView1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void InitializeListViewItems()
   {
      ListView1->View = View::List;
      array<System::Windows::Forms::Cursor^>^favoriteCursors = {Cursors::Help,Cursors::Hand,Cursors::No,Cursors::Cross};
      
      // Populate the ListView control with the array of Cursors.
      System::Collections::IEnumerator^ myEnum = favoriteCursors->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         System::Windows::Forms::Cursor^ aCursor = safe_cast<System::Windows::Forms::Cursor^>(myEnum->Current);
         
         // Construct the ListViewItem object
         ListViewItem^ item = gcnew ListViewItem;
         
         // Set the Text property to the cursor name.
         item->Text = aCursor->ToString();
         
         // Set the Tag property to the cursor.
         item->Tag = aCursor;
         
         // Add the ListViewItem to the ListView.
         ListView1->Items->Add( item );
      }
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
