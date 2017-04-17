#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Drawing;
using namespace System::Globalization;

namespace Sample
{
    public ref class VirtualConnector : public Form
    {
        DataGridView^ dataGridView1;
        const int initialSize;
        int numberOfRows;
        Dictionary<int, int>^ store;
        const int initialValue;
        bool newRowNeeded;

    public:
        VirtualConnector();

    private:
        void dataGridView1_NewRowNeeded(Object^ sender, 
            DataGridViewRowEventArgs^ e);
        void dataGridView1_RowsAdded(Object^ sender, 
            DataGridViewRowsAddedEventArgs^ e);
        void dataGridView1_CellValueNeeded(Object^ sender,
            DataGridViewCellValueEventArgs^ e);
        void dataGridView1_CellValuePushed(Object^ sender,
            DataGridViewCellValueEventArgs^ e);
        void dataGridView1_CellValidating(Object^ sender,
            DataGridViewCellValidatingEventArgs^ e);
    };


    VirtualConnector::VirtualConnector():
    dataGridView1(gcnew DataGridView()),
        initialSize(5000000),
        newRowNeeded(false),
        initialValue(-1),
        numberOfRows(initialSize),
        store(gcnew Dictionary<int, int>()),
        Form()
    {
        this->Text = this->GetType()->Name;

        dataGridView1->NewRowNeeded += 
            gcnew DataGridViewRowEventHandler(this,
            &VirtualConnector::dataGridView1_NewRowNeeded);

        dataGridView1->RowsAdded += 
            gcnew DataGridViewRowsAddedEventHandler(this, 
            &VirtualConnector::dataGridView1_RowsAdded);

        dataGridView1->CellValidating += 
            gcnew DataGridViewCellValidatingEventHandler(this, 
            &VirtualConnector::dataGridView1_CellValidating);

        dataGridView1->CellValueNeeded += 
            gcnew DataGridViewCellValueEventHandler(this, 
            &VirtualConnector::dataGridView1_CellValueNeeded);

        dataGridView1->CellValuePushed += 
            gcnew DataGridViewCellValueEventHandler(this, 
            &VirtualConnector::dataGridView1_CellValuePushed);

        try
        {
            Controls->Add(dataGridView1);
            dataGridView1->VirtualMode = true;
            dataGridView1->AllowUserToDeleteRows = false;
            dataGridView1->Columns->Add("Numbers", 
                "Positive Numbers");
            dataGridView1->Rows->AddCopies(0, initialSize);
        }
        catch (InvalidOperationException^ ex)
        {
            MessageBox::Show(String::Format(
                CultureInfo::CurrentCulture, 
                "Exception occured: {0}", ex));
        }
    }

    //<snippet20>
    void VirtualConnector::dataGridView1_NewRowNeeded
        (Object^ sender, DataGridViewRowEventArgs^ e)
    {
        newRowNeeded = true;
    }

    //<snippet30>
    void VirtualConnector::dataGridView1_RowsAdded
        (Object^ sender, DataGridViewRowsAddedEventArgs^ e)
    {
        if (newRowNeeded)
        {
            newRowNeeded = false;
            numberOfRows = numberOfRows + 1;
        }
    }
    //</snippet30>

    //<snippet10>
#pragma region Data store maintance

    void VirtualConnector::dataGridView1_CellValueNeeded
        (Object^ sender, DataGridViewCellValueEventArgs^ e)
    {
        if (store->ContainsKey(e->RowIndex))
        {
            // Use the store if the e value has been modified 
            // and stored.            
            e->Value = gcnew Int32(store->default[e->RowIndex]); 
        }
        else if (newRowNeeded && e->RowIndex == numberOfRows)
        {
            if (dataGridView1->IsCurrentCellInEditMode)
            {
                e->Value = initialValue;
            }
            else
            {
                // Show a blank e if the cursor is just loitering
                // over(the) last row.
                e->Value = String::Empty;
            }
        }
        else
        {
            e->Value = e->RowIndex;
        }
    }

    void VirtualConnector::dataGridView1_CellValuePushed
        (Object^ sender, DataGridViewCellValueEventArgs^ e)
    {
        String^ value = e->Value->ToString();
        store[e->RowIndex] = Int32::Parse(value, 
            CultureInfo::CurrentCulture);
    }
#pragma endregion
    //</snippet10>
    //</snippet20>    

    //<snippet40>
    void VirtualConnector::dataGridView1_CellValidating
        (Object^ sender, DataGridViewCellValidatingEventArgs^ e)
    {
        int newInteger;

        // Don't try to validate the 'new row' until finished 
        // editing since there
        // is not any point in validating its initial value.
        if (dataGridView1->Rows[e->RowIndex]->IsNewRow) 
        {
            return; 
        }
        if (!Int32::TryParse(e->FormattedValue->ToString(), 
            newInteger) || (newInteger < 0))
        {
            e->Cancel = true;
        }
    }
    //</snippet40>
}
int main()
{
    Application::Run(gcnew Sample::VirtualConnector());
}
