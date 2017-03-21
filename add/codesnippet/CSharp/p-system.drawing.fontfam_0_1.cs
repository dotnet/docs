    private void PopulateListBoxWithFonts()
    {
        listBox1.Width = 200;
        listBox1.Location = new Point(40, 120);
        foreach ( FontFamily oneFontFamily in FontFamily.Families )
        {
            listBox1.Items.Add(oneFontFamily.Name);
        }
    }