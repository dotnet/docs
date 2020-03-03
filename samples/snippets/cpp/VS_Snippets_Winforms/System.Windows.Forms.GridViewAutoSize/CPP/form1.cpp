

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );

      //Add any initialization after the InitializeComponent() call
   }

protected:

   //Form calls destructor to clean up the component list.
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

internal:
   System::Windows::Forms::DataGridView ^ dataGridView1;

private:
   System::Windows::Forms::Button^ Button1;

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerNonUserCode]
   void InitializeComponent()
   {
      this->dataGridView1 = gcnew System::Windows::Forms::DataGridView;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // 
      // dataGridView1
      // 
      this->dataGridView1->Location = System::Drawing::Point( 75, 67 );
      this->dataGridView1->Name = "dataGridView1";
      this->dataGridView1->Size = System::Drawing::Size( 152, 148 );
      this->dataGridView1->TabIndex = 0;

      // 
      // Button1
      // 
      this->Button1->Location = System::Drawing::Point( 101, 240 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 1;
      this->Button1->Text = "Automatically Resize Cells";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Controls->Add( this->dataGridView1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


internal:

   static property Form1^ GetInstance 
   {
      Form1^ get()
      {
         if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
         {
            System::Threading::Monitor::Enter( m_SyncObject );
            try
            {
               if ( m_DefaultInstance == nullptr || m_DefaultInstance->IsDisposed )
               {
                  m_DefaultInstance = gcnew Form1;
               }
            }
            finally
            {
               System::Threading::Monitor::Exit( m_SyncObject );
            }
         }

         return m_DefaultInstance;
      }
   }

private:
   static Form1^ m_DefaultInstance;
   static Object^ m_SyncObject = gcnew Object;

   //<snippet1>
   //<snippet2>
   void InitializeDataGridView()
   {
      this->Size = System::Drawing::Size( 600, 600 );
      dataGridView1->Size = System::Drawing::Size( 450, 400 );

      // Create an unbound DataGridView by declaring a column count.
      dataGridView1->ColumnCount = 4;
      dataGridView1->ColumnHeadersVisible = true;

      // Set the column header style.
      DataGridViewCellStyle ^ columnHeaderStyle = gcnew DataGridViewCellStyle;
      columnHeaderStyle->BackColor = Color::Aqua;
      columnHeaderStyle->Font = gcnew System::Drawing::Font( "Verdana",10,FontStyle::Bold );
      dataGridView1->ColumnHeadersDefaultCellStyle = columnHeaderStyle;

      // Set the column header names.
      dataGridView1->Columns[ 0 ]->Name = "Recipe";
      dataGridView1->Columns[ 1 ]->Name = "Category";
      dataGridView1->Columns[ 2 ]->Name = "Main Ingredients";
      dataGridView1->Columns[ 3 ]->Name = "Rating";

      // Populate the rows.
      array<String^>^row1 = gcnew array<String^>{
         "Meatloaf","Main Dish","ground beef","**"
      };
      array<String^>^row2 = gcnew array<String^>{
         "Key Lime Pie","Dessert","lime juice, evaporated milk","****"
      };
      array<String^>^row3 = gcnew array<String^>{
         "Orange-Salsa Pork Chops","Main Dish","pork chops, salsa, orange juice","****"
      };
      array<String^>^row4 = gcnew array<String^>{
         "Black Bean and Rice Salad","Salad","black beans, brown rice","****"
      };
      array<String^>^row5 = gcnew array<String^>{
         "Chocolate Cheesecake","Dessert","cream cheese","***"
      };
      array<String^>^row6 = gcnew array<String^>{
         "Black Bean Dip","Appetizer","black beans, sour cream","***"
      };
      array<Object^>^rows = {row1,row2,row3,row4,row5,row6};
      System::Collections::IEnumerator^ myEnum = rows->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         array<String^>^rowArray = safe_cast<array<String^>^>(myEnum->Current);
         dataGridView1->Rows->Add( rowArray );
      }
   }

   //<snippet3>
   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Resize the height of the column headers. 
      dataGridView1->AutoResizeColumnHeadersHeight();

      // Resize all the row heights to fit the contents of all non-header cells.
      dataGridView1->AutoResizeRows(
            DataGridViewAutoSizeRowsMode::AllCellsExceptHeaders);
   }
   //</snippet3>
   //</snippet1>

   void InitializeContextMenu()
   {
      // Create the menu item.
      MenuItem^ getRecipe = gcnew MenuItem( "Search for recipe",gcnew System::EventHandler( this, &Form1::OnMenuClick ) );

      // Add the menu item to the shortcut menu.
      System::Windows::Forms::ContextMenuStrip^ recipeMenu = gcnew System::Windows::Forms::ContextMenuStrip();

      // Set the shortcut menu for the first column.
      dataGridView1->Columns[ 0 ]->ContextMenuStrip = recipeMenu;
   }

   void OnMenuClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( dataGridView1->CurrentCell != nullptr )
      {
         //Retrieve the recipe name.
         String^ recipeName = dynamic_cast<String^>(dataGridView1->CurrentCell->Value);

         //Search for the recipe.
         System::Diagnostics::Process::Start( String::Format( "http://search.msn.com/results.aspx?q={0}", recipeName ), nullptr );
      }
   }

private:

   // </snippet2>
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      InitializeDataGridView();
      InitializeContextMenu();
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}
