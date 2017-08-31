using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        //<Snippet1>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            Int32 newRegionID = 5;
            String newRegionDescription = "NorthEastern";

            try
            {
                regionTableAdapter1.Insert(newRegionID, newRegionDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Failed");
            }
            RefreshDataset();
        }


        private void RefreshDataset()
        {
            this.regionTableAdapter1.Fill(this.northwindDataSet1.Region);
        }
        //</Snippet1>


        //<Snippet2>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Int32 newRegionID = 5;
            
            try
            {
                regionTableAdapter1.Update(newRegionID, "Updated Region Description", 5, "NorthEastern");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed");
            }
            RefreshDataset();
        }
        //</Snippet2>


        //<Snippet3>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                regionTableAdapter1.Delete(5, "Updated Region Description");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Failed");
            }
            RefreshDataset();
        }
        //</Snippet3>


        public Form1()
        {
            InitializeComponent();
        }


        private void regionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.regionBindingSource.EndEdit();
            this.regionTableAdapter1.Update(this.northwindDataSet1.Region);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet1.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter1.Fill(this.northwindDataSet1.Region);
        }
    }
}