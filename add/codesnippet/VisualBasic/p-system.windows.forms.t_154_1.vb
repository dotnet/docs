      ' This code example demonstrates the syntax for setting
      ' various ToolStripTextBox properties.
      ' 
      toolStripTextBox1.AcceptsReturn = True
      toolStripTextBox1.AcceptsTab = True
      toolStripTextBox1.AutoCompleteCustomSource.AddRange(New String() {"This is line one.", "Second line.", "Another line."})
      toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
      toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      toolStripTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      toolStripTextBox1.HideSelection = False
      toolStripTextBox1.MaxLength = 32000
      toolStripTextBox1.Name = "toolStripTextBox1"
      toolStripTextBox1.ShortcutsEnabled = False
      toolStripTextBox1.Size = New System.Drawing.Size(100, 25)
      toolStripTextBox1.Text = "STRING1" + ControlChars.Cr + ControlChars.Lf + "STRING2" + ControlChars.Cr + ControlChars.Lf + "STRING3" + ControlChars.Cr + ControlChars.Lf + "STRING4"
      toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center