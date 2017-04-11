//<Snippet000>
//<Snippet001>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

//<Snippet200>
public ref class Customer
{
private:
   String^ companyNameValue;
   String^ contactNameValue;

public:
   Customer()
   {
      
      // Leave fields empty.
   }

   Customer( String^ companyName, String^ contactName )
   {
      companyNameValue = companyName;
      contactNameValue = contactName;
   }


   property String^ CompanyName 
   {
      String^ get()
      {
         return companyNameValue;
      }

      void set( String^ value )
      {
         companyNameValue = value;
      }

   }

   property String^ ContactName 
   {
      String^ get()
      {
         return contactNameValue;
      }

      void set( String^ value )
      {
         contactNameValue = value;
      }

   }

};
//</Snippet200>

//<Snippet100>
public ref class Form1: public Form
{
private:
   DataGridView^ dataGridView1;

   // Declare an ArrayList to serve as the data store. 
   System::Collections::ArrayList^ customers;

   // Declare a Customer object to store data for a row being edited.
   Customer^ customerInEdit;

   // Declare a variable to store the index of a row being edited. 
   // A value of -1 indicates that there is no row currently in edit. 
   int rowInEdit;

   // Declare a variable to indicate the commit scope. 
   // Set this value to false to use cell-level commit scope. 
   bool rowScopeCommit;

public:
   static void Main()
   {
      Application::Run( gcnew Form1 );
   }

   Form1()
   {
      dataGridView1 = gcnew DataGridView;
      customers = gcnew System::Collections::ArrayList;
      rowInEdit = -1;
      rowScopeCommit = true;
      
      // Initialize the form.
      this->dataGridView1->Dock = DockStyle::Fill;
      this->Controls->Add( this->dataGridView1 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
   }

private:
   //</Snippet001>
   //<Snippet110>
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Enable virtual mode.
      this->dataGridView1->VirtualMode = true;
      
      // Connect the virtual-mode events to event handlers. 
      this->dataGridView1->CellValueNeeded += gcnew
          DataGridViewCellValueEventHandler( this, &Form1::dataGridView1_CellValueNeeded );
      this->dataGridView1->CellValuePushed += gcnew
          DataGridViewCellValueEventHandler( this, &Form1::dataGridView1_CellValuePushed );
      this->dataGridView1->NewRowNeeded += gcnew
          DataGridViewRowEventHandler( this, &Form1::dataGridView1_NewRowNeeded );
      this->dataGridView1->RowValidated += gcnew
          DataGridViewCellEventHandler( this, &Form1::dataGridView1_RowValidated );
      this->dataGridView1->RowDirtyStateNeeded += gcnew
          QuestionEventHandler( this, &Form1::dataGridView1_RowDirtyStateNeeded );
      this->dataGridView1->CancelRowEdit += gcnew
          QuestionEventHandler( this, &Form1::dataGridView1_CancelRowEdit );
      this->dataGridView1->UserDeletingRow += gcnew
          DataGridViewRowCancelEventHandler( this, &Form1::dataGridView1_UserDeletingRow );
      
      // Add columns to the DataGridView.
      DataGridViewTextBoxColumn^ companyNameColumn = gcnew DataGridViewTextBoxColumn;
      companyNameColumn->HeaderText = L"Company Name";
      companyNameColumn->Name = L"Company Name";
      DataGridViewTextBoxColumn^ contactNameColumn = gcnew DataGridViewTextBoxColumn;
      contactNameColumn->HeaderText = L"Contact Name";
      contactNameColumn->Name = L"Contact Name";
      this->dataGridView1->Columns->Add( companyNameColumn );
      this->dataGridView1->Columns->Add( contactNameColumn );
	  this->dataGridView1->AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode::AllCells;
      
      // Add some sample entries to the data store. 
      this->customers->Add( gcnew Customer( L"Bon app'",L"Laurence Lebihan" ) );
      this->customers->Add( gcnew Customer( L"Bottom-Dollar Markets",L"Elizabeth Lincoln" ) );
      this->customers->Add( gcnew Customer( L"B's Beverages",L"Victoria Ashworth" ) );
      
      // Set the row count, including the row for new records.
      this->dataGridView1->RowCount = 4;
   }
   //</Snippet110>

   //<Snippet120>
   void dataGridView1_CellValueNeeded( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewCellValueEventArgs^ e )
   {
      Customer^ customerTmp = nullptr;
      
      // Store a reference to the Customer object for the row being painted.
      if ( e->RowIndex == rowInEdit )
      {
         customerTmp = this->customerInEdit;
      }
      else
      {
         customerTmp = dynamic_cast<Customer^>(this->customers[ e->RowIndex ]);
      }
      
      // Set the cell value to paint using the Customer object retrieved.
      int switchcase = 0;
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Company Name" ) )
            switchcase = 1;
      else
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Contact Name" ) )
            switchcase = 2;


      switch ( switchcase )
      {
         case 1:
            e->Value = customerTmp->CompanyName;
            break;

         case 2:
            e->Value = customerTmp->ContactName;
            break;
      }
   }


   //</Snippet120>
   //<Snippet130>
   void dataGridView1_CellValuePushed( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewCellValueEventArgs^ e )
   {
      Customer^ customerTmp = nullptr;
      
      // Store a reference to the Customer object for the row being edited.
      if ( e->RowIndex < this->customers->Count )
      {
         
         // If the user is editing a new row, create a new Customer object.
         if ( this->customerInEdit == nullptr )
         {
            this->customerInEdit = gcnew Customer(
                (dynamic_cast<Customer^>(this->customers[ e->RowIndex ]))->CompanyName,
                (dynamic_cast<Customer^>(this->customers[ e->RowIndex ])->ContactName) );
         }

         customerTmp = this->customerInEdit;
         this->rowInEdit = e->RowIndex;
      }
      else
      {
         customerTmp = this->customerInEdit;
      }

      
      // Set the appropriate Customer property to the cell value entered.
      int switchcase = 0;
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Company Name" ) )
            switchcase = 1;
      else
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Contact Name" ) )
            switchcase = 2;


      switch ( switchcase )
      {
         case 1:
            customerTmp->CompanyName = dynamic_cast<String^>(e->Value);
            break;

         case 2:
            customerTmp->ContactName = dynamic_cast<String^>(e->Value);
            break;
      }
   }


   //</Snippet130>
   //<Snippet140>
   void dataGridView1_NewRowNeeded( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewRowEventArgs^ /*e*/ )
   {
      
      // Create a new Customer object when the user edits
      // the row for new records.
      this->customerInEdit = gcnew Customer;
      this->rowInEdit = this->dataGridView1->Rows->Count - 1;
   }


   //</Snippet140>
   //<Snippet150>
   void dataGridView1_RowValidated( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewCellEventArgs^ e )
   {
      
      // Save row changes if any were made and release the edited 
      // Customer object if there is one.
      if ( e->RowIndex >= this->customers->Count && e->RowIndex != this->dataGridView1->Rows->Count - 1 )
      {
         
         // Add the new Customer object to the data store.
         this->customers->Add( this->customerInEdit );
         this->customerInEdit = nullptr;
         this->rowInEdit = -1;
      }
      else
      if ( this->customerInEdit != nullptr && e->RowIndex < this->customers->Count )
      {
         
         // Save the modified Customer object in the data store.
         this->customers[ e->RowIndex ] = this->customerInEdit;
         this->customerInEdit = nullptr;
         this->rowInEdit = -1;
      }
      else
      if ( this->dataGridView1->ContainsFocus )
      {
         this->customerInEdit = nullptr;
         this->rowInEdit = -1;
      }
   }


   //</Snippet150>
   //<Snippet160>
   void dataGridView1_RowDirtyStateNeeded( Object^ /*sender*/,
       System::Windows::Forms::QuestionEventArgs^ e )
   {
      if (  !rowScopeCommit )
      {
         
         // In cell-level commit scope, indicate whether the value
         // of the current cell has been modified.
         e->Response = this->dataGridView1->IsCurrentCellDirty;
      }
   }


   //</Snippet160>
   //<Snippet170>
   void dataGridView1_CancelRowEdit( Object^ /*sender*/,
       System::Windows::Forms::QuestionEventArgs^ /*e*/ )
   {
      if ( this->rowInEdit == this->dataGridView1->Rows->Count - 2 &&
           this->rowInEdit == this->customers->Count )
      {
         
         // If the user has canceled the edit of a newly created row, 
         // replace the corresponding Customer object with a new, empty one.
         this->customerInEdit = gcnew Customer;
      }
      else
      {
         
         // If the user has canceled the edit of an existing row, 
         // release the corresponding Customer object.
         this->customerInEdit = nullptr;
         this->rowInEdit = -1;
      }
   }


   //</Snippet170>
   //<Snippet180>
   void dataGridView1_UserDeletingRow( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewRowCancelEventArgs^ e )
   {
      if ( e->Row->Index < this->customers->Count )
      {
         
         // If the user has deleted an existing row, remove the 
         // corresponding Customer object from the data store.
         this->customers->RemoveAt( e->Row->Index );
      }

      if ( e->Row->Index == this->rowInEdit )
      {
         
         // If the user has deleted a newly created row, release
         // the corresponding Customer object. 
         this->rowInEdit = -1;
         this->customerInEdit = nullptr;
      }
   }
   //</Snippet180>
   //<Snippet002>
};
//</Snippet100>

int main()
{
   Form1::Main();
}
//</Snippet002>


//</Snippet000>
