//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Snip_CheckedListBox
{
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button WhatIsChecked;
        private System.Windows.Forms.Button CheckEveryOther;
        private bool insideCheckEveryOther;

        public Form1()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        /// Required method for Designer support.
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.WhatIsChecked = new System.Windows.Forms.Button();
            this.CheckEveryOther = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // checkedListBox1
            this.checkedListBox1.Items.AddRange(new object[] {"one", "two", "three", "four", 
                                                              "five", "six", "seven", "eight",
                                                              "nine", "ten"});
            this.checkedListBox1.Location = new System.Drawing.Point(10, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(158, 139);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);

            // WhatIsChecked
            this.WhatIsChecked.Location = new System.Drawing.Point(178, 27);
            this.WhatIsChecked.Name = "WhatIsChecked";
            this.WhatIsChecked.Size = new System.Drawing.Size(106, 23);
            this.WhatIsChecked.TabIndex = 1;
            this.WhatIsChecked.Text = "What is checked?";
            this.WhatIsChecked.Click += new System.EventHandler(this.WhatIsChecked_Click);

            // CheckEveryOther
            this.CheckEveryOther.Location = new System.Drawing.Point(178, 59);
            this.CheckEveryOther.Name = "CheckEveryOther";
            this.CheckEveryOther.Size = new System.Drawing.Size(106, 23);
            this.CheckEveryOther.TabIndex = 2;
            this.CheckEveryOther.Text = "Check every other";
            this.CheckEveryOther.Click += new System.EventHandler(this.CheckEveryOther_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(303, 182);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.CheckEveryOther,
                                                                       this.WhatIsChecked,
                                                                       this.checkedListBox1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        // The main entry point for the application.
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        //<Snippet2>
        private void WhatIsChecked_Click(object sender, System.EventArgs e) {
            // Display in a message box all the items that are checked.

            // First show the index and check state of all selected items.
            foreach(int indexChecked in checkedListBox1.CheckedIndices) {
                // The indexChecked variable contains the index of the item.
                MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
                                checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");
            }

            // Next show the object title and check state for each item selected.
            foreach(object itemChecked in checkedListBox1.CheckedItems) {

                // Use the IndexOf method to get the index of an item.
                MessageBox.Show("Item with title: \"" + itemChecked.ToString() + 
                                "\", is checked. Checked state is: " + 
                                checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");
            }

        }
        //</Snippet2>

        //<Snippet4>
        //<Snippet3>
        private void CheckEveryOther_Click(object sender, System.EventArgs e) {
            // Cycle through every item and check every other.

            // Set flag to true to know when this code is being executed. Used in the ItemCheck
            // event handler.
            insideCheckEveryOther = true;

            for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                // For every other item in the list, set as checked.
                if ((i % 2) == 0) {
                    // But for each other item that is to be checked, set as being in an
                    // indeterminate checked state.
                    if ((i % 4) == 0)
                        checkedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
                    else
                        checkedListBox1.SetItemChecked(i, true);
                }
            }        

            insideCheckEveryOther = false;
        }
        //</Snippet3>
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
            // An item in the CheckedListBox is being checked or unchecked.
            // Set the NewValue based upon the CurrentValue to allow for a tri-state checking.

            // If the ItemCheck event is due to the code in CheckEveryOther, 
            // then exit the function.
            if (insideCheckEveryOther) return;

            if (e.CurrentValue == CheckState.Unchecked)
                e.NewValue = CheckState.Indeterminate;
            else if (e.CurrentValue == CheckState.Indeterminate)
                e.NewValue = CheckState.Checked;
            else if (e.CurrentValue == CheckState.Checked)
                e.NewValue = CheckState.Unchecked;        
        }
        //</Snippet4>
	}
}
//</Snippet1>