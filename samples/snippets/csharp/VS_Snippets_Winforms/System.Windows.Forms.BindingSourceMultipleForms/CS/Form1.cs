//<snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace BindingSourceMultipleForms
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Load += new EventHandler(MainForm_Load);
        }

        private BindingSource bindingSource1;
        private Button button1;
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void InitializeData()
        {
            bindingSource1 = new System.Windows.Forms.BindingSource();
            
            // Handle the BindingComplete event to ensure the two forms
            // remain synchronized.
            bindingSource1.BindingComplete +=  
                new BindingCompleteEventHandler(bindingSource1_BindingComplete);
            ClientSize = new System.Drawing.Size(292, 266);
            DataSet dataset1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                 "<recording><artist>Dave Matthews</artist>" +
                 "<cd>Under the Table and Dreaming</cd>" + 
                 "<releaseDate>1994</releaseDate><rating>3.5</rating></recording>" +
                 "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd>" + 
                 "<releaseDate>2005</releaseDate><rating>4</rating></recording>" +
                 "<recording><artist>Dave Matthews</artist>" + 
                 "<cd>Live at Red Rocks</cd>" + 
                 "<releaseDate>1997</releaseDate><rating>4</rating></recording>" +
                 "<recording><artist>U2</artist>" + 
                 "<cd>Joshua Tree</cd><releaseDate>1987</releaseDate>" + 
                 "<rating>5</rating></recording>" +
                 "<recording><artist>U2</artist>" +
                 "<cd>How to Dismantle an Atomic Bomb</cd>" + 
                 "<releaseDate>2004</releaseDate><rating>4.5</rating></recording>" +
                 "<recording><artist>Natalie Merchant</artist>" +
                 "<cd>Tigerlily</cd><releaseDate>1995</releaseDate>" +
                 "<rating>3.5</rating></recording>" +
                 "</music>";

            // Read the xml.
            System.IO.StringReader reader = new System.IO.StringReader(musicXml);
            dataset1.ReadXml(reader); 

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = dataset1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.ReadOnly = true;
            datagridview1.AutoGenerateColumns = true;
            datagridview1.Width = 300;
            this.Controls.Add(datagridview1);
            bindingSource1.DataSource = view1;
            datagridview1.DataSource = bindingSource1;
            datagridview1.Columns.Remove("artist");
            datagridview1.Columns.Remove("releaseDate");
            
            // Create and add a button to the form. 
            button1 = new Button();
            button1.AutoSize = true;
            button1.Text = "Show/Edit Details";
            this.Controls.Add(button1);
            button1.Location = new Point(50, 200);
            button1.Click += new EventHandler(button1_Click);
        }

        // Handle the BindingComplete event to ensure the two forms
        // remain synchronized.
        private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
                && e.Exception == null)
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }

        // The detailed form will be shown when the button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm(bindingSource1);
            detailForm.Show();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }

    // The detail form class. 
    public class DetailForm : Form
    {
        private BindingSource formDataSource;

        // The constructor takes a BindingSource object.
        public DetailForm(BindingSource dataSource)
        {
            formDataSource = dataSource;
            this.ClientSize = new Size(240, 200);
            TextBox textBox1 = new TextBox();
            this.Text = "Selection Details";
            textBox1.Width = 220;
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            textBox4.Width = 30;
            textBox3.Width = 50;

            // Associate each text box with a column from the data source.
            textBox1.DataBindings.Add("Text", formDataSource, "cd", true, DataSourceUpdateMode.OnPropertyChanged);
            
            textBox2.DataBindings.Add("Text", formDataSource, "artist", true);
            textBox3.DataBindings.Add("Text", formDataSource, "releaseDate", true);
            textBox4.DataBindings.Add("Text", formDataSource, "rating", true);
            textBox1.Location = new Point(10, 10);
            textBox2.Location = new Point(10, 40);
            textBox3.Location = new Point(10, 80);
            textBox4.Location = new Point(10, 120);
            this.Controls.AddRange(new Control[] { textBox1, textBox2, textBox3, textBox4 });
        }

    }
}
//</snippet1>