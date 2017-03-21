            // The following code example demonstrates the syntax for setting
            // various ToolStripComboBox properties.
            // 
            toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "aaa",
            "bbb",
            "ccc"});
            toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            toolStripComboBox1.DropDownHeight = 110;
            toolStripComboBox1.DropDownWidth = 122;
            toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            toolStripComboBox1.IntegralHeight = false;
            toolStripComboBox1.Items.AddRange(new object[] {
            "xxx",
            "yyy",
            "zzz"});
            toolStripComboBox1.MaxDropDownItems = 9;
            toolStripComboBox1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            toolStripComboBox1.Sorted = true;