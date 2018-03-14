using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace BindingSourceFind
{
    public class Form1 : Form
    {
        public Form1()
        {
           
           // PopulateDataViewAndFind();
            //PopulateDataViewAndSort();
            PopulateDataViewAndFilter();
            //PopulateBindingSourceWithFonts();
            //PopulateDataViewAndAdvancedSort();
        }

 	[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        //<snippet1>
        private void PopulateDataViewAndFind()
        {
            DataSet set1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new StringReader(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.AutoGenerateColumns = true;
            this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new BindingSource();
            source1.DataSource = view1;

            // Set the data source for the DataGridView.
            datagridview1.DataSource = source1;

            // Set the Position property to the results of the Find method.
            int itemFound = source1.Find("artist", "Natalie Merchant");
            source1.Position = itemFound;
        }
        //</snippet1>
        //<snippet2>
        private void PopulateDataViewAndSort()
        {
            DataSet set1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new StringReader(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.AutoGenerateColumns = true;
            this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new BindingSource();
            source1.DataSource = view1;

            // Set the data source for the DataGridView.
            datagridview1.DataSource = source1;

            source1.Sort = "cd";
        }
        //</snippet2>

        //<snippet3>
        private void PopulateDataViewAndFilter()
        {
            DataSet set1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new StringReader(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.AutoGenerateColumns = true;
            this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new BindingSource();
            source1.DataSource = view1;

            // Set the data source for the DataGridView.
            datagridview1.DataSource = source1;

            //The Filter string can include Boolean expressions.
            source1.Filter = "artist = 'Dave Matthews' OR cd = 'Tigerlily'";
        }
        //</snippet3>

        //<snippet4>
        private void PopulateDataViewAndAdvancedSort()
        {
            DataSet set1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>U2</artist><cd>Joshua Tree</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new StringReader(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.AutoGenerateColumns = true;
            this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new BindingSource();
            source1.DataSource = view1;

            // Set the data source for the DataGridView.
            datagridview1.DataSource = source1;

            source1.Sort = "artist ASC, cd ASC";
        }
        //</snippet4>

	//<snippet6>
        public BindingSource bindingSource1 = new BindingSource();
        TextBox box1 = new TextBox();
      
        private void PopulateBindingSourceWithFonts()
        {
            bindingSource1.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.Add(new Font(FontFamily.Families[2], 8.0F));
            bindingSource1.Add(new Font(FontFamily.Families[4], 9.0F));
            bindingSource1.Add(new Font(FontFamily.Families[6], 10.0F));
            bindingSource1.Add(new Font(FontFamily.Families[8], 11.0F));
            bindingSource1.Add(new Font(FontFamily.Families[10], 12.0F));
            DataGridView view1 = new DataGridView();
            view1.DataSource = bindingSource1;
            view1.AutoGenerateColumns = true;
            view1.Dock = DockStyle.Top;
            this.Controls.Add(view1);
            box1.Dock = DockStyle.Bottom;
            box1.Text = "Sample Text";
            this.Controls.Add(box1);
            box1.DataBindings.Add("Text", bindingSource1, "Name");
            view1.Columns[7].DisplayIndex = 0;
            
        }

        void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            box1.Font = (Font)bindingSource1.Current;
        }
        //</snippet6>
       
    }
        
}