
//<Snippet0>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.Xml.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Data::SqlClient;
using namespace System::Drawing;
using namespace System::Windows::Forms;
ref class SharedRows: public Form
{
private:
    DataGridView^ dataGridView1;
    Label^ counterLabel;
    Label^ description;
    FlowLayoutPanel^ leftToRight;
    FlowLayoutPanel^ topToBottom;

public:
    SharedRows()
    {
        dataGridView1 = gcnew DataGridView;
        counterLabel = gcnew Label;
        description = gcnew Label;
        leftToRight = gcnew FlowLayoutPanel;
        topToBottom = gcnew FlowLayoutPanel;
        wholeTable = gcnew ToolStripMenuItem;
        lookUp = gcnew ToolStripMenuItem;
        count = gcnew Label;
        this->Load += gcnew EventHandler( this, &SharedRows::SharedRows_Load );
        this->AutoSize = true;
        this->Controls->Add( topToBottom );
    }

    static void Main()
    {
        Application::Run( gcnew SharedRows );
    }


private:
    void SharedRows_Load( Object^ /*ignored*/, EventArgs^ /*e*/ )
    {
        counterLabel->Text = L"Unshared Rows: ";
        counterLabel->AutoSize = true;
        count->AutoSize = true;
        description->MaximumSize = System::Drawing::Size( 600, 300 );
        description->AutoSize = true;
        description->Text = L"Try out the contextual menu, and hovering over the cells in the 'ReportsTo' column. "
            L"Notice what happens when trying to lookup a picture cell. "
            L"Row unsharing is minimized through the use of events.";
        leftToRight->FlowDirection = FlowDirection::LeftToRight;
        leftToRight->Controls->AddRange( gcnew array<Control^>{
            dataGridView1,counterLabel,count
        } );
        leftToRight->AutoSize = true;
        topToBottom->FlowDirection = FlowDirection::TopDown;
        topToBottom->AutoSize = true;
        topToBottom->Controls->AddRange( gcnew array<Control^>{
            leftToRight,description
        } );
        dataGridView1->MaximumSize = System::Drawing::Size( 500, 300 );
        dataGridView1->AutoSize = true;
        dataGridView1->MultiSelect = false;
        dataGridView1->ReadOnly = true;
        dataGridView1->SelectionMode = DataGridViewSelectionMode::CellSelect;
        dataGridView1->AllowUserToAddRows = false;
        dataGridView1->AllowUserToDeleteRows = false;
        wholeTable->Click += gcnew EventHandler( this, &SharedRows::wholeTable_Click );
        lookUp->Click += gcnew EventHandler( this, &SharedRows::lookUp_Click );
        dataGridView1->RowUnshared += gcnew DataGridViewRowEventHandler( this, &SharedRows::dataGridView1_RowUnshared );
        dataGridView1->CellMouseEnter += gcnew DataGridViewCellEventHandler( this, &SharedRows::dataGridView1_CellMouseEnter );
        dataGridView1->CellErrorTextNeeded += gcnew DataGridViewCellErrorTextNeededEventHandler( this, &SharedRows::dataGridView1_CellErrorTextNeeded );
        dataGridView1->CellContextMenuStripNeeded += gcnew DataGridViewCellContextMenuStripNeededEventHandler( this, &SharedRows::dataGridView1_CellContextMenuStripNeeded );
        dataGridView1->CellToolTipTextNeeded += gcnew DataGridViewCellToolTipTextNeededEventHandler( this, &SharedRows::dataGridView1_CellToolTipTextNeeded );
        dataGridView1->DataSource = Populate( L"Select * from employees", true );
    }


    //<Snippet20>
    //<Snippet22>
    //<Snippet24>
    ToolStripMenuItem^ wholeTable;
    ToolStripMenuItem^ lookUp;
    System::Windows::Forms::ContextMenuStrip^ strip;
    String^ cellErrorText;

    void dataGridView1_CellContextMenuStripNeeded( Object^ /*sender*/,
        DataGridViewCellContextMenuStripNeededEventArgs^ e )
    {
        cellErrorText = String::Empty;
        if ( strip == nullptr )
        {
            strip = gcnew System::Windows::Forms::ContextMenuStrip;
            lookUp->Text = L"Look Up";
            wholeTable->Text = L"See Whole Table";
            strip->Items->Add( lookUp );
            strip->Items->Add( wholeTable );
        }

        e->ContextMenuStrip = strip;
    }

    void wholeTable_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
    {
        dataGridView1->DataSource = Populate( L"Select * from employees", true );
    }

    DataGridViewCellEventArgs^ theCellImHoveringOver;
    void dataGridView1_CellMouseEnter( Object^ /*sender*/, DataGridViewCellEventArgs^ e )
    {
        theCellImHoveringOver = e;
    }

    DataGridViewCellEventArgs^ cellErrorLocation;
    void lookUp_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
    {
        try
        {
            dataGridView1->DataSource = Populate( String::Format( L"Select * from employees where {0} = '{1}'", dataGridView1->Columns[ theCellImHoveringOver->ColumnIndex ]->Name, dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value ), true );
        }
        catch ( ... ) 
        {
            cellErrorText = L"Can't look this cell up";
            cellErrorLocation = theCellImHoveringOver;
        }

    }

    void dataGridView1_CellErrorTextNeeded( Object^ /*sender*/, DataGridViewCellErrorTextNeededEventArgs^ e )
    {
        if ( cellErrorLocation != nullptr )
        {
            if ( e->ColumnIndex == cellErrorLocation->ColumnIndex && e->RowIndex == cellErrorLocation->RowIndex )
            {
                e->ErrorText = cellErrorText;
            }
        }
    }

    //<Snippet30>
    DataTable^ Populate( String^ query, bool resetUnsharedCounter )
    {
        if ( resetUnsharedCounter )
        {
            ResetCounter();
        }


        // Alter the data source as necessary
        SqlDataAdapter^ adapter = gcnew SqlDataAdapter( query,
            gcnew SqlConnection( L"Integrated Security=SSPI;Persist Security Info=False;"
            L"Initial Catalog=Northwind;Data Source= localhost" ) );
        DataTable^ table = gcnew DataTable;
        adapter->Fill( table );
        return table;
    }

    Label^ count;
    int unsharedRowCounter;
    void ResetCounter()
    {
        unsharedRowCounter = 0;
        count->Text = unsharedRowCounter.ToString();
    }
    //</Snippet24>
    //</Snippet22>
    //</Snippet20>

    void dataGridView1_CellToolTipTextNeeded( Object^ /*sender*/,
        DataGridViewCellToolTipTextNeededEventArgs^ e )
    {
        if ( theCellImHoveringOver->ColumnIndex == dataGridView1->Columns[ L"ReportsTo" ]->Index && theCellImHoveringOver->RowIndex > -1 )
        {
            String^ reportsTo = dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value->ToString();
            if ( reportsTo->Equals( L"" ) )
            {
                e->ToolTipText = L"The buck stops here!";
            }
            else
            {
                DataTable^ table = Populate( String::Format( L"select firstname, lastname from employees where employeeid = '{0}'",
                    dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value ), false );
                e->ToolTipText = String::Format( L"Reports to {0} {1}", table->Rows[ 0 ]->ItemArray[ 0 ], table->Rows[ 0 ]->ItemArray[ 1 ] );
            }
        }
    }


    //</Snippet30>
    void dataGridView1_RowUnshared( Object^ /*sender*/, DataGridViewRowEventArgs^ /*row*/ )
    {
        unsharedRowCounter += 1;
        count->Text = unsharedRowCounter.ToString();
    }

};

int main()
{
    SharedRows::Main();
}

//</Snippet0>
