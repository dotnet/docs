namespace CS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
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
            this.components=new System.ComponentModel.Container();
            this.northwindDataSet1=new CS.NorthwindDataSet();
            this.regionTableAdapter1=new CS.NorthwindDataSetTableAdapters.RegionTableAdapter();
            this.regionBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.regionDataGridView=new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertButton=new System.Windows.Forms.Button();
            this.UpdateButton=new System.Windows.Forms.Button();
            this.DeleteButton=new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // northwindDataSet1
            // 
            this.northwindDataSet1.DataSetName="NorthwindDataSet";
            // 
            // regionTableAdapter1
            // 
            this.regionTableAdapter1.ClearBeforeFill=true;
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember="Region";
            this.regionBindingSource.DataSource=this.northwindDataSet1;
            // 
            // regionDataGridView
            // 
            this.regionDataGridView.AutoGenerateColumns=false;
            this.regionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.regionDataGridView.DataSource=this.regionBindingSource;
            this.regionDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.regionDataGridView.Location=new System.Drawing.Point(12, 22);
            this.regionDataGridView.Name="regionDataGridView";
            this.regionDataGridView.Size=new System.Drawing.Size(300, 220);
            this.regionDataGridView.TabIndex=1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName="RegionID";
            this.dataGridViewTextBoxColumn1.HeaderText="RegionID";
            this.dataGridViewTextBoxColumn1.Name="dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName="RegionDescription";
            this.dataGridViewTextBoxColumn2.HeaderText="RegionDescription";
            this.dataGridViewTextBoxColumn2.Name="dataGridViewTextBoxColumn2";
            // 
            // InsertButton
            // 
            this.InsertButton.Location=new System.Drawing.Point(320, 41);
            this.InsertButton.Name="InsertButton";
            this.InsertButton.Size=new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex=2;
            this.InsertButton.Text="InsertButton";
            this.InsertButton.UseVisualStyleBackColor=true;
            this.InsertButton.Click+=new System.EventHandler(this.InsertButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location=new System.Drawing.Point(320, 71);
            this.UpdateButton.Name="UpdateButton";
            this.UpdateButton.Size=new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex=3;
            this.UpdateButton.Text="UpdateButton";
            this.UpdateButton.UseVisualStyleBackColor=true;
            this.UpdateButton.Click+=new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location=new System.Drawing.Point(320, 101);
            this.DeleteButton.Name="DeleteButton";
            this.DeleteButton.Size=new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex=4;
            this.DeleteButton.Text="DeleteButton";
            this.DeleteButton.UseVisualStyleBackColor=true;
            this.DeleteButton.Click+=new System.EventHandler(this.DeleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(418, 298);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.regionDataGridView);
            this.Name="Form1";
            this.Text="Form1";
            this.Load+=new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NorthwindDataSet northwindDataSet1;
        private CS.NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter1;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private System.Windows.Forms.DataGridView regionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}

