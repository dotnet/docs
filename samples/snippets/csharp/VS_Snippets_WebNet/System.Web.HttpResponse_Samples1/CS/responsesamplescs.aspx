<%--<snippet1>--%>
<%@ Page Language="C#" %>
<%@ import Namespace="System.Drawing" %>
<%@ import Namespace="System.Drawing.Imaging" %>
<%@ import Namespace="System.Drawing.Drawing2D" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, EventArgs e)
    {
// <snippet2>
        // Set the page's content type to JPEG files
        // and clears all content output from the buffer stream.
        Response.ContentType = "image/jpeg";
        Response.Clear();
    
        // Buffer response so that page is sent
        // after processing is complete.
        Response.BufferOutput = true;
// </snippet2>
    
        // Create a font style.
        Font rectangleFont = new Font(
            "Arial", 10, FontStyle.Bold);
    
        // Create integer variables.
        int height = 100;
        int width = 200;
    
        // Create a random number generator and create
        // variable values based on it.
        Random r = new Random();
        int x = r.Next(75);
        int a = r.Next(155);
        int x1 = r.Next(100);
    
        // Create a bitmap and use it to create a
        // Graphics object.
        Bitmap bmp = new Bitmap(
            width, height, PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(bmp);
    
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.LightGray);
    
        // Use the Graphics object to draw three rectangles.
        g.DrawRectangle(Pens.White, 1, 1, width-3, height-3);
        g.DrawRectangle(Pens.Aquamarine, 2, 2, width-3, height-3);
        g.DrawRectangle(Pens.Black, 0, 0, width, height);
    
        // Use the Graphics object to write a string
        // on the rectangles.
        g.DrawString(
            "ASP.NET Samples", rectangleFont,
            SystemBrushes.WindowText, new PointF(10, 40));
    
        // Apply color to two of the rectangles.
        g.FillRectangle(
            new SolidBrush(
                Color.FromArgb(a, 255, 128, 255)),
            x, 20, 100, 50);
    
        g.FillRectangle(
            new LinearGradientBrush(
                new Point(x, 10),
                new Point(x1 + 75, 50 + 30),
                Color.FromArgb(128, 0, 0, 128),
                Color.FromArgb(255, 255, 255, 240)),
            x1, 50, 75, 30);

// <snippet3>    
        // Save the bitmap to the response stream and
        // convert it to JPEG format.
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
    
        // Release memory used by the Graphics object
        // and the bitmap.
        g.Dispose();
        bmp.Dispose();
    
        // Send the output to the client.
        Response.Flush();
// </snippet3>
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
<%--</snippet1>--%>
