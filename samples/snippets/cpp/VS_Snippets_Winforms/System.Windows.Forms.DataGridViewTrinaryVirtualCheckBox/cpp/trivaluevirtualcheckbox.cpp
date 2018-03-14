//<snippet0>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>
using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::Windows::Forms;

public enum class LightStatus
{
    Unknown,
    TurnedOn,
    TurnedOff
};

public ref class TriValueVirtualCheckBox: public Form
{
private:
    DataGridView^ dataGridView1;

private:
    const int initialSize;

private:
    Dictionary<int, LightStatus>^ store;

public:
    TriValueVirtualCheckBox() :  Form(), initialSize(500)
    {
        dataGridView1 = gcnew DataGridView();
        store = gcnew Dictionary<int, LightStatus>();
        Text = this->GetType()->Name;

        for(int i = 0; i < initialSize; i++)
        {
            store->Add(i, LightStatus::Unknown);
        }

        Controls->Add(dataGridView1);
        dataGridView1->VirtualMode = true;
        dataGridView1->AllowUserToDeleteRows = false;
        dataGridView1->CellValueNeeded += 
            gcnew DataGridViewCellValueEventHandler(
            this, &TriValueVirtualCheckBox::dataGridView1_CellValueNeeded);
        dataGridView1->CellValuePushed += 
            gcnew DataGridViewCellValueEventHandler(
            this, &TriValueVirtualCheckBox::dataGridView1_CellValuePushed);

        dataGridView1->Columns->Add(CreateCheckBoxColumn());
        dataGridView1->Rows->AddCopies(0, initialSize);
    }

    //<snippet10>
private:
    DataGridViewCheckBoxColumn^ CreateCheckBoxColumn()
    {
        DataGridViewCheckBoxColumn^ dataGridViewCheckBoxColumn1
            = gcnew DataGridViewCheckBoxColumn();
        dataGridViewCheckBoxColumn1->HeaderText = "Lights On";
        dataGridViewCheckBoxColumn1->TrueValue = LightStatus::TurnedOn;
        dataGridViewCheckBoxColumn1->FalseValue =
            LightStatus::TurnedOff;
        dataGridViewCheckBoxColumn1->IndeterminateValue
            = LightStatus::Unknown;
        dataGridViewCheckBoxColumn1->ThreeState = true;
        dataGridViewCheckBoxColumn1->ValueType = LightStatus::typeid;
        return dataGridViewCheckBoxColumn1;
    }
    //</snippet10>

#pragma region "data store maintance"
private:
    void dataGridView1_CellValueNeeded(Object^ sender,
        DataGridViewCellValueEventArgs^ e)
    {
        e->Value = store[e->RowIndex];
    }

private:
    void dataGridView1_CellValuePushed(Object^ sender,
        DataGridViewCellValueEventArgs^ e)
    {
        store[e->RowIndex] = (LightStatus) e->Value;
    }
#pragma endregion

};

[STAThread]
int main()
{
    Application::Run(gcnew TriValueVirtualCheckBox());
}

//</snippet0>
