//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.ImplicitExplicitCorrelation.Client
{
    partial class Form1
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
            this.cmdRequest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBaseCost = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtDrug = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInsurancePayPercentage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GetInsuranceCoverage = new System.Windows.Forms.Button();
            this.cmdGetAdjustedCost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRequest
            // 
            this.cmdRequest.Location = new System.Drawing.Point(21, 206);
            this.cmdRequest.Name = "cmdRequest";
            this.cmdRequest.Size = new System.Drawing.Size(75, 23);
            this.cmdRequest.TabIndex = 0;
            this.cmdRequest.Text = "Request ";
            this.cmdRequest.UseVisualStyleBackColor = true;
            this.cmdRequest.Click += new System.EventHandler(this.cmdRequest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblBaseCost);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCustomerID);
            this.groupBox1.Controls.Add(this.txtDrug);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.cmdRequest);
            this.groupBox1.Location = new System.Drawing.Point(21, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 248);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perscription Request";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Drug:";
            // 
            // lblBaseCost
            // 
            this.lblBaseCost.AutoSize = true;
            this.lblBaseCost.Location = new System.Drawing.Point(73, 167);
            this.lblBaseCost.Name = "lblBaseCost";
            this.lblBaseCost.Size = new System.Drawing.Size(19, 13);
            this.lblBaseCost.TabIndex = 2;
            this.lblBaseCost.Text = "$0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "CustomerID:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(9, 49);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(62, 13);
            this.lblCustomerID.TabIndex = 7;
            this.lblCustomerID.Text = "CustomerID";
            // 
            // txtDrug
            // 
            this.txtDrug.Location = new System.Drawing.Point(73, 139);
            this.txtDrug.Name = "txtDrug";
            this.txtDrug.Size = new System.Drawing.Size(100, 20);
            this.txtDrug.TabIndex = 5;
            this.txtDrug.Text = "Aspirin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Base Cost:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(73, 99);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Text = "Erikson";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(73, 73);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Text = "Luke";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(263, 207);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(0, 13);
            this.lblOrderID.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInsurancePayPercentage);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.GetInsuranceCoverage);
            this.groupBox2.Location = new System.Drawing.Point(263, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insurance";
            // 
            // lblInsurancePayPercentage
            // 
            this.lblInsurancePayPercentage.AutoSize = true;
            this.lblInsurancePayPercentage.Location = new System.Drawing.Point(12, 89);
            this.lblInsurancePayPercentage.Name = "lblInsurancePayPercentage";
            this.lblInsurancePayPercentage.Size = new System.Drawing.Size(21, 13);
            this.lblInsurancePayPercentage.TabIndex = 8;
            this.lblInsurancePayPercentage.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Percentage Paid By Insurance:";
            // 
            // GetInsuranceCoverage
            // 
            this.GetInsuranceCoverage.Location = new System.Drawing.Point(15, 26);
            this.GetInsuranceCoverage.Name = "GetInsuranceCoverage";
            this.GetInsuranceCoverage.Size = new System.Drawing.Size(151, 23);
            this.GetInsuranceCoverage.TabIndex = 5;
            this.GetInsuranceCoverage.Text = "Get Insurance Percentage";
            this.GetInsuranceCoverage.UseVisualStyleBackColor = true;
            this.GetInsuranceCoverage.Click += new System.EventHandler(this.GetInsuranceCoverage_Click);
            // 
            // cmdGetAdjustedCost
            // 
            this.cmdGetAdjustedCost.Location = new System.Drawing.Point(266, 252);
            this.cmdGetAdjustedCost.Name = "cmdGetAdjustedCost";
            this.cmdGetAdjustedCost.Size = new System.Drawing.Size(133, 23);
            this.cmdGetAdjustedCost.TabIndex = 10;
            this.cmdGetAdjustedCost.Text = "Get Adjusted Cost";
            this.cmdGetAdjustedCost.UseVisualStyleBackColor = true;
            this.cmdGetAdjustedCost.Click += new System.EventHandler(this.cmdGetAdjustedCost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Order ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGetAdjustedCost);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOrderID);
            this.Name = "Form1";
            this.Text = "Pharmacy Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRequest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDrug;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblInsurancePayPercentage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GetInsuranceCoverage;
        private System.Windows.Forms.Label lblBaseCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdGetAdjustedCost;
        private System.Windows.Forms.Label label1;
    }
}

