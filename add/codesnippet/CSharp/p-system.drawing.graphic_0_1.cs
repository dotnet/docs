    private void PopulateListBoxWithGraphicsResolution()
    {
        Graphics boxGraphics = listBox1.CreateGraphics();
        Graphics formGraphics = this.CreateGraphics();

        listBox1.Items.Add("ListBox horizontal resolution: " 
            + boxGraphics.DpiX);
        listBox1.Items.Add("ListBox vertical resolution: " 
            + boxGraphics.DpiY);

        boxGraphics.Dispose();
    }