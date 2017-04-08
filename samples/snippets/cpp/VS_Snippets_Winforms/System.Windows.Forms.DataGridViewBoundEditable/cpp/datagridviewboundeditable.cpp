//<snippet00>
#using <System.Data.dll>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Data::SqlClient;
using namespace System::Windows::Forms;

public ref class Form1 : public System::Windows::Forms::Form
{
private:
    DataGridView^ dataGridView1;
private:
    BindingSource^ bindingSource1;
private:
    SqlDataAdapter^ dataAdapter;
private:
    Button^ reloadButton;
private:
    Button^ submitButton;

public:
    static void Main()
    {
        Application::Run(gcnew Form1());
    }

    // Initialize the form.
public:
    Form1()
    {
        dataGridView1 = gcnew DataGridView();
        bindingSource1 = gcnew BindingSource();
        dataAdapter = gcnew SqlDataAdapter();
        reloadButton = gcnew Button();
        submitButton = gcnew Button();

        dataGridView1->Dock = DockStyle::Fill;

        reloadButton->Text = "reload";
        submitButton->Text = "submit";
        reloadButton->Click += gcnew System::EventHandler(this,&Form1::reloadButton_Click);
        submitButton->Click += gcnew System::EventHandler(this,&Form1::submitButton_Click);

        FlowLayoutPanel^ panel = gcnew FlowLayoutPanel();
        panel->Dock = DockStyle::Top;
        panel->AutoSize = true;
        panel->Controls->AddRange(gcnew array<Control^> { reloadButton, submitButton });

        this->Controls->AddRange(gcnew array<Control^> { dataGridView1, panel });
        this->Load += gcnew System::EventHandler(this,&Form1::Form1_Load);
    }

    //<snippet10>
    void Form1_Load(Object^ /*sender*/, System::EventArgs^ /*e*/)
    {
        // Bind the DataGridView to the BindingSource
        // and load the data from the database.
        dataGridView1->DataSource = bindingSource1;
        GetData("select * from Customers");
    }
    //</snippet10>

    void reloadButton_Click(Object^ /*sender*/, System::EventArgs^ /*e*/)
    {
        // Reload the data from the database.
        GetData(dataAdapter->SelectCommand->CommandText);
    }

    void submitButton_Click(Object^ /*sender*/, System::EventArgs^ /*e*/)
    {
        // Update the database with the user's changes.
        dataAdapter->Update((DataTable^)bindingSource1->DataSource);
    }

    //<snippet20>
private:
    void GetData(String^ selectCommand)
    {
        try
        {
            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            String^ connectionString = 
                "Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Northwind;Data Source=localhost";

            // Create a new data adapter based on the specified query.
            dataAdapter = gcnew SqlDataAdapter(selectCommand, connectionString);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            gcnew SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable^ table = gcnew DataTable();
            dataAdapter->Fill(table);
            bindingSource1->DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1->AutoResizeColumns( 
                DataGridViewAutoSizeColumnsMode::AllCellsExceptHeader);
        }
        catch (SqlException^)
        {
            MessageBox::Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }
    //</snippet20>
};
//</snippet00>

int main(){
    Form1::Main();
}
