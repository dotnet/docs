namespace XMLProcessingApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TreeViewGroupBox = new System.Windows.Forms.GroupBox();
            this.xmlTreeView = new System.Windows.Forms.TreeView();
            this.TextGroupBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.refreshTreeButton = new System.Windows.Forms.Button();
            this.positionDownButton = new System.Windows.Forms.Button();
            this.positionUpButton = new System.Windows.Forms.Button();
            this.XmlTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loadTab = new System.Windows.Forms.TabPage();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.generateSchemaCheckBox = new System.Windows.Forms.CheckBox();
            this.generateCheckBox = new System.Windows.Forms.CheckBox();
            this.validateCheckBox = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.addTab = new System.Windows.Forms.TabPage();
            this.addElementGroupBox = new System.Windows.Forms.GroupBox();
            this.newPositionLabel = new System.Windows.Forms.Label();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.newTitleTextBox = new System.Windows.Forms.TextBox();
            this.newTitleLabel = new System.Windows.Forms.Label();
            this.newISBNLabel = new System.Windows.Forms.Label();
            this.newPriceLabel = new System.Windows.Forms.Label();
            this.newISBNTextBox = new System.Windows.Forms.TextBox();
            this.newPriceTextBox = new System.Windows.Forms.TextBox();
            this.newPubDateLabel = new System.Windows.Forms.Label();
            this.newGenreLabel = new System.Windows.Forms.Label();
            this.newPubDateTextBox = new System.Windows.Forms.TextBox();
            this.addNewBookButton = new System.Windows.Forms.Button();
            this.newGenreTextBox = new System.Windows.Forms.TextBox();
            this.editTab = new System.Windows.Forms.TabPage();
            this.EditElementGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editTitleTextBox = new System.Windows.Forms.TextBox();
            this.editTitleLabel = new System.Windows.Forms.Label();
            this.editISBNLabel = new System.Windows.Forms.Label();
            this.editPriceLabel = new System.Windows.Forms.Label();
            this.editISBNTextBox = new System.Windows.Forms.TextBox();
            this.editPriceTextBox = new System.Windows.Forms.TextBox();
            this.editPubDateLabel = new System.Windows.Forms.Label();
            this.editGenreLabel = new System.Windows.Forms.Label();
            this.editPubDateTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.editGenreTextBox = new System.Windows.Forms.TextBox();
            this.filterTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.matchesComboBox = new System.Windows.Forms.ComboBox();
            this.matchesLabel = new System.Windows.Forms.Label();
            this.applyLabel = new System.Windows.Forms.Label();
            this.condition4Panel = new System.Windows.Forms.Panel();
            this.condition4CheckBox = new System.Windows.Forms.CheckBox();
            this.operator4ComboBox = new System.Windows.Forms.ComboBox();
            this.condition4ComboBox = new System.Windows.Forms.ComboBox();
            this.condition4TextBox = new System.Windows.Forms.TextBox();
            this.condition3Panel = new System.Windows.Forms.Panel();
            this.condition3CheckBox = new System.Windows.Forms.CheckBox();
            this.operator3ComboBox = new System.Windows.Forms.ComboBox();
            this.condition3ComboBox = new System.Windows.Forms.ComboBox();
            this.condition3TextBox = new System.Windows.Forms.TextBox();
            this.condition2Panel = new System.Windows.Forms.Panel();
            this.condition2CheckBox = new System.Windows.Forms.CheckBox();
            this.operator2ComboBox = new System.Windows.Forms.ComboBox();
            this.condition2ComboBox = new System.Windows.Forms.ComboBox();
            this.condition2TextBox = new System.Windows.Forms.TextBox();
            this.condition1Panel = new System.Windows.Forms.Panel();
            this.condition1CheckBox = new System.Windows.Forms.CheckBox();
            this.operator1ComboBox = new System.Windows.Forms.ComboBox();
            this.condition1ComboBox = new System.Windows.Forms.ComboBox();
            this.condition1TextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.filterTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewGroupBox.SuspendLayout();
            this.TextGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.loadTab.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.addTab.SuspendLayout();
            this.addElementGroupBox.SuspendLayout();
            this.editTab.SuspendLayout();
            this.EditElementGroupBox.SuspendLayout();
            this.filterTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.condition4Panel.SuspendLayout();
            this.condition3Panel.SuspendLayout();
            this.condition2Panel.SuspendLayout();
            this.condition1Panel.SuspendLayout();
            this.filterBox.SuspendLayout();
            this.SuspendLayout();
            //
            // TreeViewGroupBox
            //
            this.TreeViewGroupBox.Controls.Add(this.xmlTreeView);
            this.TreeViewGroupBox.ForeColor = System.Drawing.Color.White;
            this.TreeViewGroupBox.Location = new System.Drawing.Point(373, 12);
            this.TreeViewGroupBox.Name = "TreeViewGroupBox";
            this.TreeViewGroupBox.Size = new System.Drawing.Size(286, 688);
            this.TreeViewGroupBox.TabIndex = 4;
            this.TreeViewGroupBox.TabStop = false;
            this.TreeViewGroupBox.Text = "Book List";
            //
            // xmlTreeView
            //
            this.xmlTreeView.BackColor = System.Drawing.Color.Black;
            this.xmlTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlTreeView.ForeColor = System.Drawing.Color.White;
            this.xmlTreeView.Location = new System.Drawing.Point(16, 19);
            this.xmlTreeView.Name = "xmlTreeView";
            this.xmlTreeView.Size = new System.Drawing.Size(258, 656);
            this.xmlTreeView.TabIndex = 3;
            this.xmlTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.xmlTreeView_AfterSelect);
            //
            // TextGroupBox
            //
            this.TextGroupBox.Controls.Add(this.saveButton);
            this.TextGroupBox.Controls.Add(this.refreshTreeButton);
            this.TextGroupBox.Controls.Add(this.positionDownButton);
            this.TextGroupBox.Controls.Add(this.positionUpButton);
            this.TextGroupBox.Controls.Add(this.XmlTextBox);
            this.TextGroupBox.ForeColor = System.Drawing.Color.White;
            this.TextGroupBox.Location = new System.Drawing.Point(665, 12);
            this.TextGroupBox.Name = "TextGroupBox";
            this.TextGroupBox.Size = new System.Drawing.Size(526, 688);
            this.TextGroupBox.TabIndex = 5;
            this.TextGroupBox.TabStop = false;
            this.TextGroupBox.Text = "Xml View";
            //
            // saveButton
            //
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(6, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(31, 34);
            this.saveButton.TabIndex = 38;
            this.toolTip1.SetToolTip(this.saveButton, "Save XML with new element positions");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            //
            // refreshTreeButton
            //
            this.refreshTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.refreshTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshTreeButton.Image")));
            this.refreshTreeButton.Location = new System.Drawing.Point(6, 150);
            this.refreshTreeButton.Name = "refreshTreeButton";
            this.refreshTreeButton.Size = new System.Drawing.Size(31, 34);
            this.refreshTreeButton.TabIndex = 37;
            this.toolTip1.SetToolTip(this.refreshTreeButton, "Refresh tree view to reflect new order of elements");
            this.refreshTreeButton.UseVisualStyleBackColor = true;
            //
            // positionDownButton
            //
            this.positionDownButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.positionDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionDownButton.Image = ((System.Drawing.Image)(resources.GetObject("positionDownButton.Image")));
            this.positionDownButton.Location = new System.Drawing.Point(6, 105);
            this.positionDownButton.Name = "positionDownButton";
            this.positionDownButton.Size = new System.Drawing.Size(31, 34);
            this.positionDownButton.TabIndex = 36;
            this.toolTip1.SetToolTip(this.positionDownButton, "Move selected item down in the list");
            this.positionDownButton.UseVisualStyleBackColor = true;
            this.positionDownButton.Click += new System.EventHandler(this.positionDownButton_Click);
            //
            // positionUpButton
            //
            this.positionUpButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.positionUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionUpButton.Image = ((System.Drawing.Image)(resources.GetObject("positionUpButton.Image")));
            this.positionUpButton.Location = new System.Drawing.Point(6, 59);
            this.positionUpButton.Name = "positionUpButton";
            this.positionUpButton.Size = new System.Drawing.Size(31, 34);
            this.positionUpButton.TabIndex = 35;
            this.toolTip1.SetToolTip(this.positionUpButton, "Move selected item up in the list");
            this.positionUpButton.UseVisualStyleBackColor = true;
            this.positionUpButton.Click += new System.EventHandler(this.positionUpButton_Click);
            //
            // XmlTextBox
            //
            this.XmlTextBox.BackColor = System.Drawing.Color.Black;
            this.XmlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XmlTextBox.ForeColor = System.Drawing.Color.White;
            this.XmlTextBox.Location = new System.Drawing.Point(43, 19);
            this.XmlTextBox.Name = "XmlTextBox";
            this.XmlTextBox.Size = new System.Drawing.Size(477, 656);
            this.XmlTextBox.TabIndex = 6;
            this.XmlTextBox.Text = "";
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.loadTab);
            this.tabControl1.Controls.Add(this.addTab);
            this.tabControl1.Controls.Add(this.editTab);
            this.tabControl1.Controls.Add(this.filterTab);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 247);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            //
            // loadTab
            //
            this.loadTab.BackColor = System.Drawing.Color.Black;
            this.loadTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadTab.Controls.Add(this.optionsGroupBox);
            this.loadTab.Controls.Add(this.loadButton);
            this.loadTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTab.ForeColor = System.Drawing.Color.White;
            this.loadTab.Location = new System.Drawing.Point(4, 25);
            this.loadTab.Name = "loadTab";
            this.loadTab.Padding = new System.Windows.Forms.Padding(3);
            this.loadTab.Size = new System.Drawing.Size(346, 218);
            this.loadTab.TabIndex = 1;
            this.loadTab.Text = "Load XML";
            //
            // optionsGroupBox
            //
            this.optionsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optionsGroupBox.Controls.Add(this.generateSchemaCheckBox);
            this.optionsGroupBox.Controls.Add(this.generateCheckBox);
            this.optionsGroupBox.Controls.Add(this.validateCheckBox);
            this.optionsGroupBox.ForeColor = System.Drawing.Color.White;
            this.optionsGroupBox.Location = new System.Drawing.Point(16, 56);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(324, 104);
            this.optionsGroupBox.TabIndex = 8;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            //
            // generateSchemaCheckBox
            //
            this.generateSchemaCheckBox.AutoSize = true;
            this.generateSchemaCheckBox.Enabled = false;
            this.generateSchemaCheckBox.Location = new System.Drawing.Point(14, 77);
            this.generateSchemaCheckBox.Name = "generateSchemaCheckBox";
            this.generateSchemaCheckBox.Size = new System.Drawing.Size(295, 20);
            this.generateSchemaCheckBox.TabIndex = 10;
            this.generateSchemaCheckBox.Text = "If the schema file is not found, then generate it.";
            this.generateSchemaCheckBox.UseVisualStyleBackColor = true;
            this.generateSchemaCheckBox.Visible = false;
            //
            // generateCheckBox
            //
            this.generateCheckBox.AutoSize = true;
            this.generateCheckBox.ForeColor = System.Drawing.Color.White;
            this.generateCheckBox.Location = new System.Drawing.Point(13, 24);
            this.generateCheckBox.Name = "generateCheckBox";
            this.generateCheckBox.Size = new System.Drawing.Size(257, 20);
            this.generateCheckBox.TabIndex = 9;
            this.generateCheckBox.Text = "If the file is not found, generate the XML.";
            this.generateCheckBox.UseVisualStyleBackColor = true;
            //
            // validateCheckBox
            //
            this.validateCheckBox.AutoSize = true;
            this.validateCheckBox.ForeColor = System.Drawing.Color.White;
            this.validateCheckBox.Location = new System.Drawing.Point(13, 51);
            this.validateCheckBox.Name = "validateCheckBox";
            this.validateCheckBox.Size = new System.Drawing.Size(239, 20);
            this.validateCheckBox.TabIndex = 8;
            this.validateCheckBox.Text = "Validate the XML against a schema.";
            this.validateCheckBox.UseVisualStyleBackColor = true;
            this.validateCheckBox.CheckedChanged += new System.EventHandler(this.validateCheckBox_CheckedChanged);
            //
            // loadButton
            //
            this.loadButton.BackColor = System.Drawing.Color.Black;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point(16, 16);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(136, 27);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load XML from file";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            //
            // addTab
            //
            this.addTab.BackColor = System.Drawing.Color.Black;
            this.addTab.Controls.Add(this.addElementGroupBox);
            this.addTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTab.ForeColor = System.Drawing.Color.White;
            this.addTab.Location = new System.Drawing.Point(4, 25);
            this.addTab.Name = "addTab";
            this.addTab.Padding = new System.Windows.Forms.Padding(3);
            this.addTab.Size = new System.Drawing.Size(346, 218);
            this.addTab.TabIndex = 0;
            this.addTab.Text = "Add Book";
            //
            // addElementGroupBox
            //
            this.addElementGroupBox.Controls.Add(this.newPositionLabel);
            this.addElementGroupBox.Controls.Add(this.positionComboBox);
            this.addElementGroupBox.Controls.Add(this.newTitleTextBox);
            this.addElementGroupBox.Controls.Add(this.newTitleLabel);
            this.addElementGroupBox.Controls.Add(this.newISBNLabel);
            this.addElementGroupBox.Controls.Add(this.newPriceLabel);
            this.addElementGroupBox.Controls.Add(this.newISBNTextBox);
            this.addElementGroupBox.Controls.Add(this.newPriceTextBox);
            this.addElementGroupBox.Controls.Add(this.newPubDateLabel);
            this.addElementGroupBox.Controls.Add(this.newGenreLabel);
            this.addElementGroupBox.Controls.Add(this.newPubDateTextBox);
            this.addElementGroupBox.Controls.Add(this.addNewBookButton);
            this.addElementGroupBox.Controls.Add(this.newGenreTextBox);
            this.addElementGroupBox.Location = new System.Drawing.Point(6, 6);
            this.addElementGroupBox.Name = "addElementGroupBox";
            this.addElementGroupBox.Size = new System.Drawing.Size(334, 201);
            this.addElementGroupBox.TabIndex = 0;
            this.addElementGroupBox.TabStop = false;
            //
            // newPositionLabel
            //
            this.newPositionLabel.AutoSize = true;
            this.newPositionLabel.Location = new System.Drawing.Point(18, 164);
            this.newPositionLabel.Name = "newPositionLabel";
            this.newPositionLabel.Size = new System.Drawing.Size(59, 16);
            this.newPositionLabel.TabIndex = 28;
            this.newPositionLabel.Text = "Position:";
            //
            // positionComboBox
            //
            this.positionComboBox.BackColor = System.Drawing.Color.Black;
            this.positionComboBox.ForeColor = System.Drawing.Color.White;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Items.AddRange(new object[] {
            "Top",
            "Bottom",
            "Above selected item",
            "Below selected item"});
            this.positionComboBox.Location = new System.Drawing.Point(111, 157);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(128, 24);
            this.positionComboBox.TabIndex = 27;
            this.positionComboBox.Text = "Top";
            //
            // newTitleTextBox
            //
            this.newTitleTextBox.BackColor = System.Drawing.Color.Black;
            this.newTitleTextBox.ForeColor = System.Drawing.Color.White;
            this.newTitleTextBox.Location = new System.Drawing.Point(111, 21);
            this.newTitleTextBox.Name = "newTitleTextBox";
            this.newTitleTextBox.Size = new System.Drawing.Size(192, 22);
            this.newTitleTextBox.TabIndex = 16;
            //
            // newTitleLabel
            //
            this.newTitleLabel.AutoSize = true;
            this.newTitleLabel.Location = new System.Drawing.Point(18, 21);
            this.newTitleLabel.Name = "newTitleLabel";
            this.newTitleLabel.Size = new System.Drawing.Size(37, 16);
            this.newTitleLabel.TabIndex = 18;
            this.newTitleLabel.Text = "Title:";
            //
            // newISBNLabel
            //
            this.newISBNLabel.AutoSize = true;
            this.newISBNLabel.Location = new System.Drawing.Point(18, 48);
            this.newISBNLabel.Name = "newISBNLabel";
            this.newISBNLabel.Size = new System.Drawing.Size(42, 16);
            this.newISBNLabel.TabIndex = 19;
            this.newISBNLabel.Text = "ISBN:";
            //
            // newPriceLabel
            //
            this.newPriceLabel.AutoSize = true;
            this.newPriceLabel.Location = new System.Drawing.Point(18, 107);
            this.newPriceLabel.Name = "newPriceLabel";
            this.newPriceLabel.Size = new System.Drawing.Size(42, 16);
            this.newPriceLabel.TabIndex = 26;
            this.newPriceLabel.Text = "Price:";
            //
            // newISBNTextBox
            //
            this.newISBNTextBox.BackColor = System.Drawing.Color.Black;
            this.newISBNTextBox.ForeColor = System.Drawing.Color.White;
            this.newISBNTextBox.Location = new System.Drawing.Point(111, 48);
            this.newISBNTextBox.Name = "newISBNTextBox";
            this.newISBNTextBox.Size = new System.Drawing.Size(192, 22);
            this.newISBNTextBox.TabIndex = 20;
            //
            // newPriceTextBox
            //
            this.newPriceTextBox.BackColor = System.Drawing.Color.Black;
            this.newPriceTextBox.ForeColor = System.Drawing.Color.White;
            this.newPriceTextBox.Location = new System.Drawing.Point(111, 100);
            this.newPriceTextBox.Name = "newPriceTextBox";
            this.newPriceTextBox.Size = new System.Drawing.Size(75, 22);
            this.newPriceTextBox.TabIndex = 25;
            //
            // newPubDateLabel
            //
            this.newPubDateLabel.AutoSize = true;
            this.newPubDateLabel.Location = new System.Drawing.Point(18, 74);
            this.newPubDateLabel.Name = "newPubDateLabel";
            this.newPubDateLabel.Size = new System.Drawing.Size(87, 16);
            this.newPubDateLabel.TabIndex = 21;
            this.newPubDateLabel.Text = "Publish Date:";
            //
            // newGenreLabel
            //
            this.newGenreLabel.AutoSize = true;
            this.newGenreLabel.Location = new System.Drawing.Point(18, 135);
            this.newGenreLabel.Name = "newGenreLabel";
            this.newGenreLabel.Size = new System.Drawing.Size(48, 16);
            this.newGenreLabel.TabIndex = 24;
            this.newGenreLabel.Text = "Genre:";
            //
            // newPubDateTextBox
            //
            this.newPubDateTextBox.BackColor = System.Drawing.Color.Black;
            this.newPubDateTextBox.ForeColor = System.Drawing.Color.White;
            this.newPubDateTextBox.Location = new System.Drawing.Point(111, 74);
            this.newPubDateTextBox.Name = "newPubDateTextBox";
            this.newPubDateTextBox.Size = new System.Drawing.Size(125, 22);
            this.newPubDateTextBox.TabIndex = 22;
            //
            // addNewBookButton
            //
            this.addNewBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewBookButton.Location = new System.Drawing.Point(245, 157);
            this.addNewBookButton.Name = "addNewBookButton";
            this.addNewBookButton.Size = new System.Drawing.Size(70, 24);
            this.addNewBookButton.TabIndex = 17;
            this.addNewBookButton.Text = "Add";
            this.addNewBookButton.UseVisualStyleBackColor = true;
            this.addNewBookButton.Click += new System.EventHandler(this.addNewBookButton_Click);
            //
            // newGenreTextBox
            //
            this.newGenreTextBox.BackColor = System.Drawing.Color.Black;
            this.newGenreTextBox.ForeColor = System.Drawing.Color.White;
            this.newGenreTextBox.Location = new System.Drawing.Point(111, 128);
            this.newGenreTextBox.Name = "newGenreTextBox";
            this.newGenreTextBox.Size = new System.Drawing.Size(125, 22);
            this.newGenreTextBox.TabIndex = 23;
            //
            // editTab
            //
            this.editTab.BackColor = System.Drawing.Color.Black;
            this.editTab.Controls.Add(this.EditElementGroupBox);
            this.editTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTab.ForeColor = System.Drawing.Color.White;
            this.editTab.Location = new System.Drawing.Point(4, 25);
            this.editTab.Name = "editTab";
            this.editTab.Padding = new System.Windows.Forms.Padding(3);
            this.editTab.Size = new System.Drawing.Size(346, 218);
            this.editTab.TabIndex = 2;
            this.editTab.Text = "Edit Books";
            //
            // EditElementGroupBox
            //
            this.EditElementGroupBox.Controls.Add(this.deleteButton);
            this.EditElementGroupBox.Controls.Add(this.editTitleTextBox);
            this.EditElementGroupBox.Controls.Add(this.editTitleLabel);
            this.EditElementGroupBox.Controls.Add(this.editISBNLabel);
            this.EditElementGroupBox.Controls.Add(this.editPriceLabel);
            this.EditElementGroupBox.Controls.Add(this.editISBNTextBox);
            this.EditElementGroupBox.Controls.Add(this.editPriceTextBox);
            this.EditElementGroupBox.Controls.Add(this.editPubDateLabel);
            this.EditElementGroupBox.Controls.Add(this.editGenreLabel);
            this.EditElementGroupBox.Controls.Add(this.editPubDateTextBox);
            this.EditElementGroupBox.Controls.Add(this.submitButton);
            this.EditElementGroupBox.Controls.Add(this.editGenreTextBox);
            this.EditElementGroupBox.Location = new System.Drawing.Point(6, 6);
            this.EditElementGroupBox.Name = "EditElementGroupBox";
            this.EditElementGroupBox.Size = new System.Drawing.Size(334, 201);
            this.EditElementGroupBox.TabIndex = 1;
            this.EditElementGroupBox.TabStop = false;
            //
            // deleteButton
            //
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(21, 163);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(119, 25);
            this.deleteButton.TabIndex = 27;
            this.deleteButton.Text = "Delete Book";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            //
            // editTitleTextBox
            //
            this.editTitleTextBox.BackColor = System.Drawing.Color.Black;
            this.editTitleTextBox.ForeColor = System.Drawing.Color.White;
            this.editTitleTextBox.Location = new System.Drawing.Point(111, 21);
            this.editTitleTextBox.Name = "editTitleTextBox";
            this.editTitleTextBox.Size = new System.Drawing.Size(192, 22);
            this.editTitleTextBox.TabIndex = 16;
            //
            // editTitleLabel
            //
            this.editTitleLabel.AutoSize = true;
            this.editTitleLabel.Location = new System.Drawing.Point(18, 21);
            this.editTitleLabel.Name = "editTitleLabel";
            this.editTitleLabel.Size = new System.Drawing.Size(37, 16);
            this.editTitleLabel.TabIndex = 18;
            this.editTitleLabel.Text = "Title:";
            //
            // editISBNLabel
            //
            this.editISBNLabel.AutoSize = true;
            this.editISBNLabel.Location = new System.Drawing.Point(18, 48);
            this.editISBNLabel.Name = "editISBNLabel";
            this.editISBNLabel.Size = new System.Drawing.Size(42, 16);
            this.editISBNLabel.TabIndex = 19;
            this.editISBNLabel.Text = "ISBN:";
            //
            // editPriceLabel
            //
            this.editPriceLabel.AutoSize = true;
            this.editPriceLabel.Location = new System.Drawing.Point(18, 107);
            this.editPriceLabel.Name = "editPriceLabel";
            this.editPriceLabel.Size = new System.Drawing.Size(42, 16);
            this.editPriceLabel.TabIndex = 26;
            this.editPriceLabel.Text = "Price:";
            //
            // editISBNTextBox
            //
            this.editISBNTextBox.BackColor = System.Drawing.Color.Black;
            this.editISBNTextBox.ForeColor = System.Drawing.Color.White;
            this.editISBNTextBox.Location = new System.Drawing.Point(111, 48);
            this.editISBNTextBox.Name = "editISBNTextBox";
            this.editISBNTextBox.Size = new System.Drawing.Size(192, 22);
            this.editISBNTextBox.TabIndex = 20;
            //
            // editPriceTextBox
            //
            this.editPriceTextBox.BackColor = System.Drawing.Color.Black;
            this.editPriceTextBox.ForeColor = System.Drawing.Color.White;
            this.editPriceTextBox.Location = new System.Drawing.Point(111, 100);
            this.editPriceTextBox.Name = "editPriceTextBox";
            this.editPriceTextBox.Size = new System.Drawing.Size(75, 22);
            this.editPriceTextBox.TabIndex = 25;
            //
            // editPubDateLabel
            //
            this.editPubDateLabel.AutoSize = true;
            this.editPubDateLabel.Location = new System.Drawing.Point(18, 74);
            this.editPubDateLabel.Name = "editPubDateLabel";
            this.editPubDateLabel.Size = new System.Drawing.Size(87, 16);
            this.editPubDateLabel.TabIndex = 21;
            this.editPubDateLabel.Text = "Publish Date:";
            //
            // editGenreLabel
            //
            this.editGenreLabel.AutoSize = true;
            this.editGenreLabel.Location = new System.Drawing.Point(18, 135);
            this.editGenreLabel.Name = "editGenreLabel";
            this.editGenreLabel.Size = new System.Drawing.Size(48, 16);
            this.editGenreLabel.TabIndex = 24;
            this.editGenreLabel.Text = "Genre:";
            //
            // editPubDateTextBox
            //
            this.editPubDateTextBox.BackColor = System.Drawing.Color.Black;
            this.editPubDateTextBox.ForeColor = System.Drawing.Color.White;
            this.editPubDateTextBox.Location = new System.Drawing.Point(111, 74);
            this.editPubDateTextBox.Name = "editPubDateTextBox";
            this.editPubDateTextBox.Size = new System.Drawing.Size(125, 22);
            this.editPubDateTextBox.TabIndex = 22;
            //
            // submitButton
            //
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Location = new System.Drawing.Point(184, 163);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(119, 25);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit Updates";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            //
            // editGenreTextBox
            //
            this.editGenreTextBox.BackColor = System.Drawing.Color.Black;
            this.editGenreTextBox.ForeColor = System.Drawing.Color.White;
            this.editGenreTextBox.Location = new System.Drawing.Point(111, 128);
            this.editGenreTextBox.Name = "editGenreTextBox";
            this.editGenreTextBox.Size = new System.Drawing.Size(125, 22);
            this.editGenreTextBox.TabIndex = 23;
            //
            // filterTab
            //
            this.filterTab.BackColor = System.Drawing.Color.Black;
            this.filterTab.Controls.Add(this.groupBox1);
            this.filterTab.ForeColor = System.Drawing.Color.White;
            this.filterTab.Location = new System.Drawing.Point(4, 25);
            this.filterTab.Name = "filterTab";
            this.filterTab.Size = new System.Drawing.Size(346, 218);
            this.filterTab.TabIndex = 3;
            this.filterTab.Text = "Filter";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.matchesComboBox);
            this.groupBox1.Controls.Add(this.matchesLabel);
            this.groupBox1.Controls.Add(this.applyLabel);
            this.groupBox1.Controls.Add(this.condition4Panel);
            this.groupBox1.Controls.Add(this.condition3Panel);
            this.groupBox1.Controls.Add(this.condition2Panel);
            this.groupBox1.Controls.Add(this.condition1Panel);
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.addFilterButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 201);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            //
            // matchesComboBox
            //
            this.matchesComboBox.BackColor = System.Drawing.Color.Black;
            this.matchesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.matchesComboBox.ForeColor = System.Drawing.Color.White;
            this.matchesComboBox.FormattingEnabled = true;
            this.matchesComboBox.Items.AddRange(new object[] {
            "Any",
            "All"});
            this.matchesComboBox.Location = new System.Drawing.Point(255, 28);
            this.matchesComboBox.Name = "matchesComboBox";
            this.matchesComboBox.Size = new System.Drawing.Size(67, 24);
            this.matchesComboBox.TabIndex = 59;
            this.matchesComboBox.Text = "Any";
            this.matchesComboBox.Visible = false;
            this.matchesComboBox.SelectedValueChanged += new System.EventHandler(this.matchesComboBox_SelectedValueChanged);
            //
            // matchesLabel
            //
            this.matchesLabel.AutoSize = true;
            this.matchesLabel.Location = new System.Drawing.Point(187, 33);
            this.matchesLabel.Name = "matchesLabel";
            this.matchesLabel.Size = new System.Drawing.Size(62, 16);
            this.matchesLabel.TabIndex = 58;
            this.matchesLabel.Text = "Matches:";
            this.matchesLabel.Visible = false;
            //
            // applyLabel
            //
            this.applyLabel.AutoSize = true;
            this.applyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyLabel.Location = new System.Drawing.Point(7, 53);
            this.applyLabel.Name = "applyLabel";
            this.applyLabel.Size = new System.Drawing.Size(33, 13);
            this.applyLabel.TabIndex = 57;
            this.applyLabel.Text = "Apply";
            this.applyLabel.Visible = false;
            //
            // condition4Panel
            //
            this.condition4Panel.Controls.Add(this.condition4CheckBox);
            this.condition4Panel.Controls.Add(this.operator4ComboBox);
            this.condition4Panel.Controls.Add(this.condition4ComboBox);
            this.condition4Panel.Controls.Add(this.condition4TextBox);
            this.condition4Panel.Location = new System.Drawing.Point(5, 163);
            this.condition4Panel.Name = "condition4Panel";
            this.condition4Panel.Size = new System.Drawing.Size(324, 36);
            this.condition4Panel.TabIndex = 56;
            this.condition4Panel.Visible = false;
            //
            // condition4CheckBox
            //
            this.condition4CheckBox.AutoSize = true;
            this.condition4CheckBox.Location = new System.Drawing.Point(7, 11);
            this.condition4CheckBox.Name = "condition4CheckBox";
            this.condition4CheckBox.Size = new System.Drawing.Size(15, 14);
            this.condition4CheckBox.TabIndex = 54;
            this.condition4CheckBox.UseVisualStyleBackColor = true;
            this.condition4CheckBox.CheckedChanged += new System.EventHandler(this.condition4CheckBox_CheckedChanged);
            //
            // operator4ComboBox
            //
            this.operator4ComboBox.BackColor = System.Drawing.Color.Black;
            this.operator4ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operator4ComboBox.ForeColor = System.Drawing.Color.White;
            this.operator4ComboBox.FormattingEnabled = true;
            this.operator4ComboBox.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<>"});
            this.operator4ComboBox.Location = new System.Drawing.Point(131, 6);
            this.operator4ComboBox.Name = "operator4ComboBox";
            this.operator4ComboBox.Size = new System.Drawing.Size(78, 24);
            this.operator4ComboBox.TabIndex = 53;
            this.operator4ComboBox.Text = "=";
            //
            // condition4ComboBox
            //
            this.condition4ComboBox.BackColor = System.Drawing.Color.Black;
            this.condition4ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.condition4ComboBox.ForeColor = System.Drawing.Color.White;
            this.condition4ComboBox.FormattingEnabled = true;
            this.condition4ComboBox.Items.AddRange(new object[] {
            "Title",
            "ISBN",
            "Publish Year",
            "Price",
            "Genre"});
            this.condition4ComboBox.Location = new System.Drawing.Point(29, 6);
            this.condition4ComboBox.Name = "condition4ComboBox";
            this.condition4ComboBox.Size = new System.Drawing.Size(96, 24);
            this.condition4ComboBox.TabIndex = 52;
            this.condition4ComboBox.Text = "Condition";
            this.condition4ComboBox.SelectedIndexChanged += new System.EventHandler(this.condition4ComboBox_SelectedIndexChanged);
            //
            // condition4TextBox
            //
            this.condition4TextBox.BackColor = System.Drawing.Color.Black;
            this.condition4TextBox.ForeColor = System.Drawing.Color.White;
            this.condition4TextBox.Location = new System.Drawing.Point(215, 6);
            this.condition4TextBox.Name = "condition4TextBox";
            this.condition4TextBox.Size = new System.Drawing.Size(102, 22);
            this.condition4TextBox.TabIndex = 51;
            //
            // condition3Panel
            //
            this.condition3Panel.Controls.Add(this.condition3CheckBox);
            this.condition3Panel.Controls.Add(this.operator3ComboBox);
            this.condition3Panel.Controls.Add(this.condition3ComboBox);
            this.condition3Panel.Controls.Add(this.condition3TextBox);
            this.condition3Panel.Location = new System.Drawing.Point(5, 130);
            this.condition3Panel.Name = "condition3Panel";
            this.condition3Panel.Size = new System.Drawing.Size(324, 36);
            this.condition3Panel.TabIndex = 55;
            this.condition3Panel.Visible = false;
            //
            // condition3CheckBox
            //
            this.condition3CheckBox.AutoSize = true;
            this.condition3CheckBox.Location = new System.Drawing.Point(7, 11);
            this.condition3CheckBox.Name = "condition3CheckBox";
            this.condition3CheckBox.Size = new System.Drawing.Size(15, 14);
            this.condition3CheckBox.TabIndex = 54;
            this.condition3CheckBox.UseVisualStyleBackColor = true;
            this.condition3CheckBox.CheckedChanged += new System.EventHandler(this.condition3CheckBox_CheckedChanged);
            //
            // operator3ComboBox
            //
            this.operator3ComboBox.BackColor = System.Drawing.Color.Black;
            this.operator3ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operator3ComboBox.ForeColor = System.Drawing.Color.White;
            this.operator3ComboBox.FormattingEnabled = true;
            this.operator3ComboBox.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<>"});
            this.operator3ComboBox.Location = new System.Drawing.Point(131, 6);
            this.operator3ComboBox.Name = "operator3ComboBox";
            this.operator3ComboBox.Size = new System.Drawing.Size(78, 24);
            this.operator3ComboBox.TabIndex = 53;
            this.operator3ComboBox.Text = "=";
            //
            // condition3ComboBox
            //
            this.condition3ComboBox.BackColor = System.Drawing.Color.Black;
            this.condition3ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.condition3ComboBox.ForeColor = System.Drawing.Color.White;
            this.condition3ComboBox.FormattingEnabled = true;
            this.condition3ComboBox.Items.AddRange(new object[] {
            "Title",
            "ISBN",
            "Publish Year",
            "Price",
            "Genre"});
            this.condition3ComboBox.Location = new System.Drawing.Point(29, 6);
            this.condition3ComboBox.Name = "condition3ComboBox";
            this.condition3ComboBox.Size = new System.Drawing.Size(96, 24);
            this.condition3ComboBox.TabIndex = 52;
            this.condition3ComboBox.Text = "Condition";
            this.condition3ComboBox.SelectedIndexChanged += new System.EventHandler(this.condition3ComboBox_SelectedIndexChanged);
            //
            // condition3TextBox
            //
            this.condition3TextBox.BackColor = System.Drawing.Color.Black;
            this.condition3TextBox.ForeColor = System.Drawing.Color.White;
            this.condition3TextBox.Location = new System.Drawing.Point(215, 6);
            this.condition3TextBox.Name = "condition3TextBox";
            this.condition3TextBox.Size = new System.Drawing.Size(102, 22);
            this.condition3TextBox.TabIndex = 51;
            //
            // condition2Panel
            //
            this.condition2Panel.Controls.Add(this.condition2CheckBox);
            this.condition2Panel.Controls.Add(this.operator2ComboBox);
            this.condition2Panel.Controls.Add(this.condition2ComboBox);
            this.condition2Panel.Controls.Add(this.condition2TextBox);
            this.condition2Panel.Location = new System.Drawing.Point(5, 97);
            this.condition2Panel.Name = "condition2Panel";
            this.condition2Panel.Size = new System.Drawing.Size(324, 36);
            this.condition2Panel.TabIndex = 50;
            this.condition2Panel.Visible = false;
            //
            // condition2CheckBox
            //
            this.condition2CheckBox.AutoSize = true;
            this.condition2CheckBox.Location = new System.Drawing.Point(7, 11);
            this.condition2CheckBox.Name = "condition2CheckBox";
            this.condition2CheckBox.Size = new System.Drawing.Size(15, 14);
            this.condition2CheckBox.TabIndex = 54;
            this.condition2CheckBox.UseVisualStyleBackColor = true;
            this.condition2CheckBox.CheckedChanged += new System.EventHandler(this.condition2CheckBox_CheckedChanged);
            //
            // operator2ComboBox
            //
            this.operator2ComboBox.BackColor = System.Drawing.Color.Black;
            this.operator2ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operator2ComboBox.ForeColor = System.Drawing.Color.White;
            this.operator2ComboBox.FormattingEnabled = true;
            this.operator2ComboBox.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<>"});
            this.operator2ComboBox.Location = new System.Drawing.Point(131, 6);
            this.operator2ComboBox.Name = "operator2ComboBox";
            this.operator2ComboBox.Size = new System.Drawing.Size(78, 24);
            this.operator2ComboBox.TabIndex = 53;
            this.operator2ComboBox.Text = "=";
            //
            // condition2ComboBox
            //
            this.condition2ComboBox.BackColor = System.Drawing.Color.Black;
            this.condition2ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.condition2ComboBox.ForeColor = System.Drawing.Color.White;
            this.condition2ComboBox.FormattingEnabled = true;
            this.condition2ComboBox.Items.AddRange(new object[] {
            "Title",
            "ISBN",
            "Publish Year",
            "Price",
            "Genre"});
            this.condition2ComboBox.Location = new System.Drawing.Point(29, 6);
            this.condition2ComboBox.Name = "condition2ComboBox";
            this.condition2ComboBox.Size = new System.Drawing.Size(96, 24);
            this.condition2ComboBox.TabIndex = 52;
            this.condition2ComboBox.Text = "Condition";
            this.condition2ComboBox.SelectedIndexChanged += new System.EventHandler(this.condition2ComboBox_SelectedIndexChanged);
            //
            // condition2TextBox
            //
            this.condition2TextBox.BackColor = System.Drawing.Color.Black;
            this.condition2TextBox.ForeColor = System.Drawing.Color.White;
            this.condition2TextBox.Location = new System.Drawing.Point(215, 6);
            this.condition2TextBox.Name = "condition2TextBox";
            this.condition2TextBox.Size = new System.Drawing.Size(102, 22);
            this.condition2TextBox.TabIndex = 51;
            //
            // condition1Panel
            //
            this.condition1Panel.Controls.Add(this.condition1CheckBox);
            this.condition1Panel.Controls.Add(this.operator1ComboBox);
            this.condition1Panel.Controls.Add(this.condition1ComboBox);
            this.condition1Panel.Controls.Add(this.condition1TextBox);
            this.condition1Panel.Location = new System.Drawing.Point(5, 65);
            this.condition1Panel.Name = "condition1Panel";
            this.condition1Panel.Size = new System.Drawing.Size(324, 36);
            this.condition1Panel.TabIndex = 49;
            this.condition1Panel.Visible = false;
            //
            // condition1CheckBox
            //
            this.condition1CheckBox.AutoSize = true;
            this.condition1CheckBox.Location = new System.Drawing.Point(7, 11);
            this.condition1CheckBox.Name = "condition1CheckBox";
            this.condition1CheckBox.Size = new System.Drawing.Size(15, 14);
            this.condition1CheckBox.TabIndex = 54;
            this.condition1CheckBox.UseVisualStyleBackColor = true;
            this.condition1CheckBox.CheckedChanged += new System.EventHandler(this.condition1CheckBox_CheckedChanged);
            //
            // operator1ComboBox
            //
            this.operator1ComboBox.BackColor = System.Drawing.Color.Black;
            this.operator1ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operator1ComboBox.ForeColor = System.Drawing.Color.White;
            this.operator1ComboBox.FormattingEnabled = true;
            this.operator1ComboBox.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<>"});
            this.operator1ComboBox.Location = new System.Drawing.Point(131, 6);
            this.operator1ComboBox.Name = "operator1ComboBox";
            this.operator1ComboBox.Size = new System.Drawing.Size(78, 24);
            this.operator1ComboBox.TabIndex = 53;
            this.operator1ComboBox.Text = "=";
            //
            // condition1ComboBox
            //
            this.condition1ComboBox.BackColor = System.Drawing.Color.Black;
            this.condition1ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.condition1ComboBox.ForeColor = System.Drawing.Color.White;
            this.condition1ComboBox.FormattingEnabled = true;
            this.condition1ComboBox.Items.AddRange(new object[] {
            "Title",
            "ISBN",
            "Publish Year",
            "Price",
            "Genre"});
            this.condition1ComboBox.Location = new System.Drawing.Point(29, 6);
            this.condition1ComboBox.Name = "condition1ComboBox";
            this.condition1ComboBox.Size = new System.Drawing.Size(96, 24);
            this.condition1ComboBox.TabIndex = 52;
            this.condition1ComboBox.Text = "Condition";
            this.condition1ComboBox.SelectedIndexChanged += new System.EventHandler(this.condition1ComboBox_SelectedIndexChanged);
            //
            // condition1TextBox
            //
            this.condition1TextBox.BackColor = System.Drawing.Color.Black;
            this.condition1TextBox.ForeColor = System.Drawing.Color.White;
            this.condition1TextBox.Location = new System.Drawing.Point(215, 6);
            this.condition1TextBox.Name = "condition1TextBox";
            this.condition1TextBox.Size = new System.Drawing.Size(102, 22);
            this.condition1TextBox.TabIndex = 51;
            //
            // clearButton
            //
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(94, 19);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 25);
            this.clearButton.TabIndex = 27;
            this.clearButton.Text = "Clear last";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            //
            // addFilterButton
            //
            this.addFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFilterButton.Location = new System.Drawing.Point(11, 19);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(77, 25);
            this.addFilterButton.TabIndex = 17;
            this.addFilterButton.Text = "Add Filter";
            this.addFilterButton.UseVisualStyleBackColor = true;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            //
            // filterBox
            //
            this.filterBox.Controls.Add(this.filterTreeView);
            this.filterBox.ForeColor = System.Drawing.Color.White;
            this.filterBox.Location = new System.Drawing.Point(34, 278);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(284, 391);
            this.filterBox.TabIndex = 8;
            this.filterBox.TabStop = false;
            this.filterBox.Text = "Filtered Book List";
            this.filterBox.Visible = false;
            //
            // filterTreeView
            //
            this.filterTreeView.BackColor = System.Drawing.Color.Black;
            this.filterTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTreeView.ForeColor = System.Drawing.Color.White;
            this.filterTreeView.Location = new System.Drawing.Point(10, 19);
            this.filterTreeView.Name = "filterTreeView";
            this.filterTreeView.Size = new System.Drawing.Size(258, 366);
            this.filterTreeView.TabIndex = 3;
            this.filterTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.filterTreeView_AfterSelect);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1203, 727);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TextGroupBox);
            this.Controls.Add(this.TreeViewGroupBox);
            this.Name = "Form1";
            this.Text = "In Memory XML Processing App";
            this.TreeViewGroupBox.ResumeLayout(false);
            this.TextGroupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.loadTab.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.addTab.ResumeLayout(false);
            this.addElementGroupBox.ResumeLayout(false);
            this.addElementGroupBox.PerformLayout();
            this.editTab.ResumeLayout(false);
            this.EditElementGroupBox.ResumeLayout(false);
            this.EditElementGroupBox.PerformLayout();
            this.filterTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.condition4Panel.ResumeLayout(false);
            this.condition4Panel.PerformLayout();
            this.condition3Panel.ResumeLayout(false);
            this.condition3Panel.PerformLayout();
            this.condition2Panel.ResumeLayout(false);
            this.condition2Panel.PerformLayout();
            this.condition1Panel.ResumeLayout(false);
            this.condition1Panel.PerformLayout();
            this.filterBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TreeViewGroupBox;
        private System.Windows.Forms.TreeView xmlTreeView;
        private System.Windows.Forms.GroupBox TextGroupBox;
        private System.Windows.Forms.RichTextBox XmlTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage addTab;
        private System.Windows.Forms.TabPage loadTab;
        private System.Windows.Forms.TabPage editTab;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox generateCheckBox;
        private System.Windows.Forms.CheckBox validateCheckBox;
        private System.Windows.Forms.GroupBox addElementGroupBox;
        private System.Windows.Forms.Label newPositionLabel;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.TextBox newTitleTextBox;
        private System.Windows.Forms.Label newTitleLabel;
        private System.Windows.Forms.Label newISBNLabel;
        private System.Windows.Forms.Label newPriceLabel;
        private System.Windows.Forms.TextBox newISBNTextBox;
        private System.Windows.Forms.TextBox newPriceTextBox;
        private System.Windows.Forms.Label newPubDateLabel;
        private System.Windows.Forms.Label newGenreLabel;
        private System.Windows.Forms.TextBox newPubDateTextBox;
        private System.Windows.Forms.Button addNewBookButton;
        private System.Windows.Forms.TextBox newGenreTextBox;
        private System.Windows.Forms.CheckBox generateSchemaCheckBox;
        private System.Windows.Forms.GroupBox EditElementGroupBox;
        private System.Windows.Forms.TextBox editTitleTextBox;
        private System.Windows.Forms.Label editTitleLabel;
        private System.Windows.Forms.Label editISBNLabel;
        private System.Windows.Forms.Label editPriceLabel;
        private System.Windows.Forms.TextBox editISBNTextBox;
        private System.Windows.Forms.TextBox editPriceTextBox;
        private System.Windows.Forms.Label editPubDateLabel;
        private System.Windows.Forms.Label editGenreLabel;
        private System.Windows.Forms.TextBox editPubDateTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox editGenreTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button positionDownButton;
        private System.Windows.Forms.Button positionUpButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button refreshTreeButton;
        private System.Windows.Forms.TabPage filterTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Panel condition1Panel;
        private System.Windows.Forms.Button addFilterButton;
        private System.Windows.Forms.Panel condition4Panel;
        private System.Windows.Forms.CheckBox condition4CheckBox;
        private System.Windows.Forms.ComboBox operator4ComboBox;
        private System.Windows.Forms.ComboBox condition4ComboBox;
        private System.Windows.Forms.TextBox condition4TextBox;
        private System.Windows.Forms.Panel condition3Panel;
        private System.Windows.Forms.CheckBox condition3CheckBox;
        private System.Windows.Forms.ComboBox operator3ComboBox;
        private System.Windows.Forms.ComboBox condition3ComboBox;
        private System.Windows.Forms.TextBox condition3TextBox;
        private System.Windows.Forms.Panel condition2Panel;
        private System.Windows.Forms.CheckBox condition2CheckBox;
        private System.Windows.Forms.ComboBox operator2ComboBox;
        private System.Windows.Forms.ComboBox condition2ComboBox;
        private System.Windows.Forms.TextBox condition2TextBox;
        private System.Windows.Forms.CheckBox condition1CheckBox;
        private System.Windows.Forms.ComboBox operator1ComboBox;
        private System.Windows.Forms.ComboBox condition1ComboBox;
        private System.Windows.Forms.TextBox condition1TextBox;
        private System.Windows.Forms.Label applyLabel;
        private System.Windows.Forms.GroupBox filterBox;
        private System.Windows.Forms.TreeView filterTreeView;
        private System.Windows.Forms.ComboBox matchesComboBox;
        private System.Windows.Forms.Label matchesLabel;
    }
}

