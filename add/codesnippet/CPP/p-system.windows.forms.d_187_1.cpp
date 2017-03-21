
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