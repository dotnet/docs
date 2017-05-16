using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BindToArrayGrid
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(24, 48);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 200);
            this.dataGrid1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.dataGrid1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            BindToArray();
        
        }
        //<snippet1>

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
        //</snippet1>
    }

}



