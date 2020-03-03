namespace VbPowerPacksDataRepeaterVirtualModeCS
{
    partial class VbPowerPacksDataRepeaterVirtualMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(75, 25);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(113, 63);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            // 
            // dataRepeater1
            // 
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(lastNameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.lastNameTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(firstNameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtFirstName);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(524, 101);
            this.dataRepeater1.Location = new System.Drawing.Point(11, 32);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(532, 447);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.VirtualMode = true;
            this.dataRepeater1.ItemValueNeeded += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventHandler(this.dataRepeater1_ItemValueNeeded);
            this.dataRepeater1.NewItemNeeded += new System.EventHandler(this.dataRepeater1_NewItemNeeded);
            this.dataRepeater1.ItemValuePushed += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventHandler(this.dataRepeater1_ItemValuePushed);
            this.dataRepeater1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.child_KeyDown);
            this.dataRepeater1.ItemsRemoved += new Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventHandler(this.dataRepeater1_ItemsRemoved);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(180, 60);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(141, 22);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // VbPowerPacksDataRepeaterVirtualMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 511);
            this.Controls.Add(this.dataRepeater1);
            this.Name = "VbPowerPacksDataRepeaterVirtualMode";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.VbPowerPacksDataRepeaterVirtualMode_Load);
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox txtFirstName;
    }
}

