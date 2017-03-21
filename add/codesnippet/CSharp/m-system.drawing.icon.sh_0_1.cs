    private void ConstructAnIconFromAType(PaintEventArgs e)
    {

        Icon icon1 = new Icon(typeof(Control), "Error.ico");
        e.Graphics.DrawIcon(icon1, new Rectangle(10, 10, 50, 50));

    }