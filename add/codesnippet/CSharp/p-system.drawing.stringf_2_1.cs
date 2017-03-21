    private void ShowStringTrimming(PaintEventArgs e)
    {

        StringFormat format1 = new StringFormat();
        string quote = "Not everything that can be counted counts," +
            " and not everything that counts can be counted.";
        format1.Trimming = StringTrimming.EllipsisWord;
        e.Graphics.DrawString(quote, this.Font, Brushes.Black, 
            new RectangleF(10.0F, 10.0F, 90.0F, 50.0F), format1);
    }