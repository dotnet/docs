
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
ref class Form1: public Form
{
private:
   DataGridView^ dataGridView1;

public:
   static void Main()
   {
      Application::Run( gcnew Form1 );
   }

   Form1()
   {
      this->dataGridView1->Dock = DockStyle::Fill;
      this->Controls->Add( this->dataGridView1 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
      dataGridView1 = gcnew DataGridView;
   }

   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      //<Snippet1>
      DataGridViewRow^ row = this->dataGridView1->RowTemplate;
      row->DefaultCellStyle->BackColor = Color::Bisque;
      row->Height = 35;
      row->MinimumHeight = 20;
      
      //</Snippet1>
      this->dataGridView1->ColumnCount = 5;
      this->dataGridView1->RowCount = 10;
   }

};

int main()
{
   Form1::Main();
}

