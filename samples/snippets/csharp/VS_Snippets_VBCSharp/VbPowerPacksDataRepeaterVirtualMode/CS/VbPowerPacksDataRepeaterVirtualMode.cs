using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterVirtualModeCS
{
    public partial class VbPowerPacksDataRepeaterVirtualMode : Form
    {
        public VbPowerPacksDataRepeaterVirtualMode()
        {
            InitializeComponent();
        }

        
        private void VbPowerPacksDataRepeaterVirtualMode_Load(object sender, EventArgs e)
        {
            

        }
        //<Snippet1>
        private void dataRepeater1_ItemValueNeeded(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs e)
        {
            if (e.ItemIndex < Employees.Count)
            {
                switch (e.Control.Name)
                {
                    case "txtFirstName":
                        e.Value = Employees[e.ItemIndex + 1].firstName;
                        break;
                    case "txtLastName":
                        e.Value = Employees[e.ItemIndex + 1].lastName;
                        break;
                }
            }
        }
        //</Snippet1>
        //<Snippet2>
        private void dataRepeater1_ItemValuePushed(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs e)
        {
            Employee emp = Employees[e.ItemIndex];
            switch (e.Control.Name)
            {
                case "txtFirstName":
                    emp.firstName = e.Control.Text;
                    break;
                case "txtLastName":
                    emp.lastName = e.Control.Text;
                    break;
                default:
                    MessageBox.Show("Error during ItemValuePushed unexpected control: " + e.Control.Name);
                    break;
            }
        }
        //</Snippet2>
        //<Snippet3>
        private void child_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.dataRepeater1.CancelEdit();
            }
        }
        //</Snippet3>
        public struct Employee
        {
            public string firstName;
            public string lastName;

        }
        List<Employee> Employees;
        bool blnNewItemNeedEventFired = false;
        //<Snippet4>
        private void dataRepeater1_NewItemNeeded(object sender, System.EventArgs e)
        {
            Employee newEmployee = new Employee();
            Employees.Add(newEmployee);
            blnNewItemNeedEventFired = true;
        }
        //</Snippet4>
        //<Snippet5>
        private void dataRepeater1_ItemsRemoved(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventArgs e)
        {
            Employees.RemoveAt(e.ItemIndex);
        }
        //</Snippet5>
        //<Snippet6>
        private void Text_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter a name.");
                e.Cancel = true;
            }
        }
        //</Snippet6>
    }
}
