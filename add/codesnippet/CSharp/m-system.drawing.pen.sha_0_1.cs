    private void Button3_Click(System.Object sender, System.EventArgs e)
    {

        Graphics buttonGraphics = Button3.CreateGraphics();
        Pen myPen = new Pen(Color.ForestGreen, 4.0F);
        myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

        Rectangle theRectangle = Button3.ClientRectangle;
        theRectangle.Inflate(-2, -2);
        buttonGraphics.DrawRectangle(myPen, theRectangle);
        buttonGraphics.Dispose();
        myPen.Dispose();
    }