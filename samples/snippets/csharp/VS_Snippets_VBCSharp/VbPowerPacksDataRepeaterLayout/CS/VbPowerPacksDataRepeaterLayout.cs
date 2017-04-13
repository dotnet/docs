using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksDataRepeaterLayoutCS
{
    public partial class VbPowerPacksDataRepeaterLayout : Form
    {
        public VbPowerPacksDataRepeaterLayout()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void VbPowerPacksDataRepeaterLayout_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.northwindDataSet.Employees);

        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            // <Snippet1>
            // Switch the orientation.
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Horizontal;
            }
            else
            {
                dataRepeater1.LayoutStyle = DataRepeaterLayoutStyles.Vertical;
            }            
            // </Snippet1>
             
        }
        // <Snippet2>
        private void dataRepeater1_LayoutStyleChanged_1(object sender, EventArgs e)
        {
            // Call a method to re-initialize the template.
            dataRepeater1.BeginResetItemTemplate();
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            // Change the height of the template and rearrange the controls.
            {
                dataRepeater1.ItemTemplate.Height = 150;
                dataRepeater1.ItemTemplate.Controls["TextBox1"].Location = new Point(20, 40);
                dataRepeater1.ItemTemplate.Controls["TextBox2"].Location = new Point(150, 40);
            }
            else
            {
                // Change the width of the template and rearrange the controls.
                dataRepeater1.ItemTemplate.Width = 150;
                dataRepeater1.ItemTemplate.Controls["TextBox1"].Location = new Point(40, 20);
                dataRepeater1.ItemTemplate.Controls["TextBox2"].Location = new Point(40, 150);
            }
            // Apply the changes to the template.
            dataRepeater1.EndResetItemTemplate();
        }
        // </Snippet2>
          }
}
