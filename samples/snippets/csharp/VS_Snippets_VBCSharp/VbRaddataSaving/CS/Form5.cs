using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form5 : Form
    {
        //---------------------------------------------------------------------
        void OtherSnips()
        {
            //---------------------------------------------
            //<Snippet14>
            // Create a new row.
            NorthwindDataSet.RegionRow newRegionRow;
            newRegionRow = northwindDataSet.Region.NewRegionRow();
            newRegionRow.RegionID = 5;
            newRegionRow.RegionDescription = "NorthWestern";

            // Add the row to the Region table
            this.northwindDataSet.Region.Rows.Add(newRegionRow);

            // Save the new row to the database
            this.regionTableAdapter.Update(this.northwindDataSet.Region);
            //</Snippet14>


            //---------------------------------------------
            //<Snippet17>
            // Locate the row you want to update.
            NorthwindDataSet.RegionRow regionRow;
            regionRow = northwindDataSet.Region.FindByRegionID(1);

            // Assign the new value to the desired column.
            regionRow.RegionDescription = "East";

            // Save the updated row to the database.
            this.regionTableAdapter.Update(this.northwindDataSet.Region);
            //</Snippet17>

            //---------------------------------------------
            //<Snippet20>
            // Locate the row to delete.
            NorthwindDataSet.RegionRow oldRegionRow;
            oldRegionRow = northwindDataSet.Region.FindByRegionID(5);

            // Delete the row from the dataset
            oldRegionRow.Delete();

            // Delete the row from the database
            this.regionTableAdapter.Update(this.northwindDataSet.Region);
            //</Snippet20>
        }


        //---------------------------------------------------------------------
        public Form5()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------
        private void regionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.regionBindingSource.EndEdit();
            this.regionTableAdapter.Update(this.northwindDataSet.Region);
        }

 
        //---------------------------------------------------------------------
        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.northwindDataSet.Region);
        }
    }
}