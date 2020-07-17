#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
using namespace System;
using namespace System::Windows::Forms;

ref class Form1 : public Form
{
private:
    DataGridView^ dataGridView1;

public:
    static void Main()
    {
        Application::Run(gcnew Form1());
    }

public:
    Form1()
    {
        dataGridView1 = gcnew DataGridView();

        this->dataGridView1->Dock = DockStyle::Fill;
        // Set the column header names.
        this->dataGridView1->ColumnCount = 5;
        this->dataGridView1->Columns[0]->Name = "Recipe";
        this->dataGridView1->Columns[1]->Name = "Category";
        this->dataGridView1->Columns[2]->Name = "Main Ingredients";
        this->dataGridView1->Columns[3]->Name = "Last Fixed";
        this->dataGridView1->Columns[4]->Name = "Rating";

        // Populate the rows.
        array<Object^>^ row1 = gcnew array<Object^>{"Meatloaf", 
            "Main Dish", "ground beef", gcnew DateTime(2000, 3, 23), "*"};
        array<Object^>^ row2 = gcnew array<Object^>{"Key Lime Pie", 
            "Dessert", "lime juice, evaporated milk", gcnew DateTime(2002, 4, 12), "****"};
        array<Object^>^ row3 = gcnew array<Object^>{"Orange-Salsa Pork Chops", 
            "Main Dish", "pork chops, salsa, orange juice", gcnew DateTime(2000, 8, 9), "****"};
        array<Object^>^ row4 = gcnew array<Object^>{"Black Bean and Rice Salad", 
            "Salad", "black beans, brown rice", gcnew DateTime(1999, 5, 7), "****"};
        array<Object^>^ row5 = gcnew array<Object^>{"Chocolate Cheesecake", 
            "Dessert", "cream cheese", gcnew DateTime(2003, 3, 12), "***"};
        array<Object^>^ row6 = gcnew array<Object^>{"Black Bean Dip", "Appetizer",
            "black beans, sour cream", gcnew DateTime(2003, 12, 23), "***"};
        array<Object^>^ rows = gcnew array<Object^> { row1, row2, row3, row4, row5, row6 };

        for each (array<Object^>^ rowArray in rows)
        {
            this->dataGridView1->Rows->Add(rowArray);
        }
        this->Controls->Add(this->dataGridView1);
        this->dataGridView1->CellFormatting += gcnew DataGridViewCellFormattingEventHandler(this, &Form1::dataGridView1_CellFormatting);
    }


    //<Snippet1>
    // Sets the ToolTip text for cells in the Rating column.
    void dataGridView1_CellFormatting(Object^ /*sender*/, 
        DataGridViewCellFormattingEventArgs^ e)
    {
        if ( (e->ColumnIndex == this->dataGridView1->Columns["Rating"]->Index)
            && e->Value != nullptr )
        {
            DataGridViewCell^ cell = 
                this->dataGridView1->Rows[e->RowIndex]->Cells[e->ColumnIndex];
            if (e->Value->Equals("*"))
            {                
                cell->ToolTipText = "very bad";
            }
            else if (e->Value->Equals("**"))
            {
                cell->ToolTipText = "bad";
            }
            else if (e->Value->Equals("***"))
            {
                cell->ToolTipText = "good";
            }
            else if (e->Value->Equals("****"))
            {
                cell->ToolTipText = "very good";
            }
        }
    }
    //</Snippet1>
};

int main(){
    Form1::Main();
}
