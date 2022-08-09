namespace WinForms.Xml
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._settingLabel = new System.Windows.Forms.Label();
            this._settingsDataGridView = new System.Windows.Forms.DataGridView();
            this._keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._settingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _settingLabel
            // 
            this._settingLabel.AutoSize = true;
            this._settingLabel.Location = new System.Drawing.Point(25, 25);
            this._settingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._settingLabel.Name = "_settingLabel";
            this._settingLabel.Size = new System.Drawing.Size(527, 23);
            this._settingLabel.TabIndex = 0;
            this._settingLabel.Text = "Settings from winforms-xml.dll.config XML file:";
            // 
            // _settingsDataGridView
            // 
            this._settingsDataGridView.AllowUserToAddRows = false;
            this._settingsDataGridView.AllowUserToDeleteRows = false;
            this._settingsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._settingsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._settingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._settingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._keyColumn,
            this._typeColumn,
            this._valueColumn});
            this._settingsDataGridView.Location = new System.Drawing.Point(25, 69);
            this._settingsDataGridView.Name = "_settingsDataGridView";
            this._settingsDataGridView.ReadOnly = true;
            this._settingsDataGridView.RowHeadersWidth = 51;
            this._settingsDataGridView.RowTemplate.Height = 29;
            this._settingsDataGridView.Size = new System.Drawing.Size(1088, 424);
            this._settingsDataGridView.TabIndex = 2;
            // 
            // _keyColumn
            // 
            this._keyColumn.HeaderText = "Key";
            this._keyColumn.MinimumWidth = 6;
            this._keyColumn.Name = "_keyColumn";
            this._keyColumn.ReadOnly = true;
            this._keyColumn.Width = 125;
            // 
            // _typeColumn
            // 
            this._typeColumn.HeaderText = "Type";
            this._typeColumn.MinimumWidth = 6;
            this._typeColumn.Name = "_typeColumn";
            this._typeColumn.ReadOnly = true;
            this._typeColumn.Width = 125;
            // 
            // _valueColumn
            // 
            this._valueColumn.HeaderText = "Value";
            this._valueColumn.MinimumWidth = 6;
            this._valueColumn.Name = "_valueColumn";
            this._valueColumn.ReadOnly = true;
            this._valueColumn.Width = 125;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 518);
            this.Controls.Add(this._settingsDataGridView);
            this.Controls.Add(this._settingLabel);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Config Example (XML)";
            ((System.ComponentModel.ISupportInitialize)(this._settingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _settingLabel;
        private DataGridView _settingsDataGridView;
        private DataGridViewTextBoxColumn _keyColumn;
        private DataGridViewTextBoxColumn _typeColumn;
        private DataGridViewTextBoxColumn _valueColumn;
    }
}
