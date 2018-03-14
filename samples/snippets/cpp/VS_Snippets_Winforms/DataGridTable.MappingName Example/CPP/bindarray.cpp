#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace BindToArrayGrid
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public ref class BindToArrayGridForm : public System::Windows::Forms::Form
    {
    private:
        System::Windows::Forms::DataGrid^ bindedDataGrid;
        /// <summary>
        /// Required designer variable.
        /// </summary>

        System::ComponentModel::Container^ components;

    public:
        BindToArrayGridForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            components = nullptr;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    protected:
        ~BindToArrayGridForm()
		{
			if (components)
			{
				delete components;
			}
		}

#pragma region^ Windows Form^ Designer generated^ code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private:
        void InitializeComponent()
        {
            this->bindedDataGrid = gcnew System::Windows::Forms::DataGrid();
            ((System::ComponentModel::ISupportInitialize^)
                (this->bindedDataGrid))->BeginInit();
            this->SuspendLayout();
            //
            // bindedDataGrid
            //
            this->bindedDataGrid->DataMember = "";
            this->bindedDataGrid->HeaderForeColor = 
                System::Drawing::SystemColors::ControlText;
            this->bindedDataGrid->Location = System::Drawing::Point(24, 48);
            this->bindedDataGrid->Name = "bindedDataGrid";
            this->bindedDataGrid->Size = System::Drawing::Size(240, 200);
            this->bindedDataGrid->TabIndex = 0;
            //
            // BindToArrayGridForm
            //
            this->ClientSize = System::Drawing::Size(292, 266);
            this->Controls->Add(this->bindedDataGrid);
            this->Name = "BindToArrayGridForm";
            this->Text = "Form1";
            this->Load += gcnew System::EventHandler(
                this,&BindToArrayGridForm::Form1_Load);
            ((System::ComponentModel::ISupportInitialize^)
                (this->bindedDataGrid))->EndInit();
            this->ResumeLayout(false);
        }
#pragma endregion

    private:
        void Form1_Load(Object^ sender, System::EventArgs^ e)
        {
            BindToArray();
        }

        //<snippet1>

        void BindToArray()
        {
            // Create an array of Machine objects (defined below).
            array<Machine^>^ Machines = gcnew array<Machine^>(3);
            Machine^ tempMachine;

            tempMachine = gcnew Machine();
            tempMachine->Model = "AAA";
            tempMachine->Id = "A100";
            tempMachine->Price = Convert::ToDecimal(3.80);
            Machines[0] = tempMachine;

            // The first Machine includes an array of Part objects.
            Part^ p1 = gcnew Part();
            p1->PartId = "PartX";
            Part^ p2 = gcnew Part();
            p2->PartId = "PartY";

            // Note that the Machines.Parts property returns an ArrayList.
            // Add the parts to the ArrayList using the AddRange method.
            tempMachine->Parts->AddRange(gcnew array<Part^> {p1, p2}); 

            tempMachine = gcnew Machine();
            tempMachine->Model = "BBB";
            tempMachine->Id = "B100";
            tempMachine->Price = Convert::ToDecimal(1.52);
            Machines[1] = tempMachine;

            tempMachine = gcnew Machine();
            tempMachine->Id = "CCC";
            tempMachine->Model = "B100";
            tempMachine->Price = Convert::ToDecimal(2.14);
            Machines[2] = tempMachine;

            bindedDataGrid->SetDataBinding(Machines, "");
            CreateTableStyle();
        }

        void CreateTableStyle()
        {
            // Creates two DataGridTableStyle objects, one for the Machine
            // array, and one for the Parts ArrayList.

            DataGridTableStyle^ machineTable = gcnew DataGridTableStyle();
            // Sets the MappingName to the class name plus brackets.
            machineTable->MappingName = "Machine[]";

            // Sets the AlternatingBackColor so you can see the difference.
            machineTable->AlternatingBackColor = 
                System::Drawing::Color::LightBlue;

            // Creates three column styles.
            DataGridTextBoxColumn^ modelColumn = gcnew DataGridTextBoxColumn();
            modelColumn->MappingName = "Model";
            modelColumn->HeaderText = "Model";

            DataGridTextBoxColumn^ idColumn = gcnew DataGridTextBoxColumn();
            idColumn->MappingName = "Id";
            idColumn->HeaderText = "Id";

            DataGridTextBoxColumn^ priceColumn = gcnew DataGridTextBoxColumn();
            priceColumn->MappingName = "Price";
            priceColumn->HeaderText = "Price";
            priceColumn->Format = "c";

            // Adds the column styles to the grid table style.
            machineTable->GridColumnStyles->Add(modelColumn);
            machineTable->GridColumnStyles->Add(idColumn);
            machineTable->GridColumnStyles->Add(priceColumn);

            // Add the table style to the collection, but clear the
            // collection first.
            bindedDataGrid->TableStyles->Clear();
            bindedDataGrid->TableStyles->Add(machineTable);

            // Create another table style, one for the related data.
            DataGridTableStyle^ partsTable = gcnew DataGridTableStyle();
            // Set the MappingName to an ArrayList. Note that you need not
            // include brackets.
            partsTable->MappingName = "ArrayList";
            DataGridTextBoxColumn^ partIdColumn = 
                gcnew DataGridTextBoxColumn();
            partIdColumn->MappingName = "PartID";
            partIdColumn->HeaderText = "Part ID";
            partsTable->GridColumnStyles->Add(partIdColumn);
            bindedDataGrid->TableStyles->Add(partsTable);
        }

    private:
        ref class Machine
        {
        private:
            String^ machineModel;
            String^ machineID;
            Decimal machinePrice;

            // Use an ArrayList to create a related collection.
            ArrayList^ machineParts;

        public:
            Machine()
            {
                machineParts = gcnew ArrayList; 
            }   

            property String^ Model
            {
                String^ get()
                {
                    return machineModel;
                }
                void set(String^ value)
                {
                    machineModel = value;
                }
            }

            property String^ Id
            {
                String^ get()
                {
                    return machineID;
                }
                void set(String^ value)
                {
                    machineID = value;
                }
            }

            property ArrayList^ Parts
            {
                ArrayList^ get()
                {
                    return machineParts;
                }
                void set(ArrayList^ value)
                {
                    machineParts = value;
                }
            }

            property Decimal Price
            {
                Decimal get()
                {
                    return machinePrice;
                }
                void set(Decimal value)
                {
                    machinePrice = value;
                }
            }
        };

    private:
        ref class Part
        {
        private:
            String^ partId;

        public:
            property String^ PartId
            {
                String^ get()
                {
                    return partId;
                }
                void set(String^ value)
                {
                    partId = value;
                }
            }
        };
        //</snippet1>
    };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
    Application::Run(gcnew BindToArrayGrid::BindToArrayGridForm());
}

