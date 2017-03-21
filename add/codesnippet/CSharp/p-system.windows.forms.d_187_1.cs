
        private void BindToArray()
        {
            // Create an array of Machine objects (defined below).
            Machine[] Machines = new Machine[3];
            Machine tempMachine;

            tempMachine= new Machine();
            tempMachine.Model = "AAA";
            tempMachine.Id= "A100";
            tempMachine.Price= Convert.ToDecimal(3.80);
            Machines[0]=tempMachine;

            // The first Machine includes an array of Part objects.
            Part p1 = new Part();
            p1.PartId= "PartX";
            Part p2 = new Part();
            p2.PartId= "PartY";

            // Note that the Machines.Parts property returns an ArrayList.
            // Add the parts to the ArrayList using the AddRange method.
            tempMachine.Parts.AddRange (new Part[]{p1, p2});;

            tempMachine= new Machine();
            tempMachine.Model = "BBB";
            tempMachine.Id= "B100";
            tempMachine.Price= Convert.ToDecimal(1.52);
            Machines[1]=tempMachine;

            tempMachine= new Machine();
            tempMachine.Id= "CCC";
            tempMachine.Model = "B100";
            tempMachine.Price= Convert.ToDecimal(2.14);
            Machines[2]=tempMachine;
    
            dataGrid1.SetDataBinding(Machines, "");
            CreateTableStyle();
        }

        private void CreateTableStyle()
        {
            // Creates two DataGridTableStyle objects, one for the Machine
            // array, and one for the Parts ArrayList.

            DataGridTableStyle MachineTable = new DataGridTableStyle();
            // Sets the MappingName to the class name plus brackets.    
            MachineTable.MappingName= "Machine[]";

            // Sets the AlternatingBackColor so you can see the difference.
            MachineTable.AlternatingBackColor= System.Drawing.Color.LightBlue;

            // Creates three column styles.
            DataGridTextBoxColumn modelColumn = new DataGridTextBoxColumn();
            modelColumn.MappingName= "Model";
            modelColumn.HeaderText= "Model";

            DataGridTextBoxColumn IdColumn = new DataGridTextBoxColumn();
            IdColumn.MappingName= "Id";
            IdColumn.HeaderText= "Id";

            DataGridTextBoxColumn priceColumn = new DataGridTextBoxColumn();
            priceColumn.MappingName= "Price";
            priceColumn.HeaderText= "Price";
            priceColumn.Format = "c";

            // Adds the column styles to the grid table style.
            MachineTable.GridColumnStyles.Add(modelColumn);
            MachineTable.GridColumnStyles.Add(IdColumn);
            MachineTable.GridColumnStyles.Add(priceColumn);

            // Add the table style to the collection, but clear the 
            // collection first.
            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(MachineTable);

            // Create another table style, one for the related data.
            DataGridTableStyle partsTable = new DataGridTableStyle();
            // Set the MappingName to an ArrayList. Note that you need not 
            // include brackets.
            partsTable.MappingName= "ArrayList";
            DataGridTextBoxColumn partIdColumn = new DataGridTextBoxColumn();
            partIdColumn.MappingName= "PartID";
            partIdColumn.HeaderText = "Part ID";
            partsTable.GridColumnStyles.Add(partIdColumn);

            dataGrid1.TableStyles.Add(partsTable);

        }
        public class Machine
        {
            private string model;
            private string id;
            private decimal price;

            // Use an ArrayList to create a related collection.
            private ArrayList parts = new ArrayList();
        
            public string Model
            {
                get{return model;}
                set{model=value;}
            }
            public string Id
            {
                get{return id;}
                set{id = value;}
            }
            public ArrayList Parts
            {
                get{return parts;}
                set{parts = value;}
            }

            public decimal Price
            {
                get{return price;}
                set{price = value;}
            }
        }

        public class Part
        {
            private string partId;
        
            public string PartId
            {
                get{return partId;}
                set{partId = value;}
            }
        }