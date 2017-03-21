            // This code example demonstrates the syntax for setting
            // various ToolStripTextBox properties.
            // 
            toolStripTextBox1.AcceptsReturn = true;
            toolStripTextBox1.AcceptsTab = true;
            toolStripTextBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "This is line one.",
            "Second line.",
            "Another line."});
            toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            toolStripTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            toolStripTextBox1.HideSelection = false;
            toolStripTextBox1.MaxLength = 32000;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.ShortcutsEnabled = false;
            toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            toolStripTextBox1.Text = "STRING1\r\nSTRING2\r\nSTRING3\r\nSTRING4";
            toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;