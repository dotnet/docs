<%@ Page Language="VB" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)
    
      ' <snippet1>
      ' <snippet2>
      ' Clear headers to ensure none
      ' are sent to the requesting browser
      ' and set the content type.
      Response.ClearHeaders()
      Response.ContentType = "image/jpeg"
      ' </snippet2>
      
      Dim height As Integer = 150
      Dim width As Integer = 250
      
      ' Create a Font and a PointF object to
      ' be used to draw text.
      Dim fntText As New Font("Arial", 8, FontStyle.Bold)
      Dim pntText As New PointF(5, 10)
      
      ' Create a Bitmap object, then use it to
      ' create a Graphics object.
      Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)
      Dim g As Graphics = Graphics.FromImage(bmp)
      
      ' Specify that the image will be smoothed,
      ' then draw the rectangle and a String
      ' inside the rectangle.
      g.SmoothingMode = SmoothingMode.AntiAlias
      g.DrawRectangle(Pens.Blue, 0, 0, width, height)
      g.DrawString("Response.ClearHeaders Test", fntText, SystemBrushes.WindowText, pntText)
      g.FillRectangle(New SolidBrush(Color.Aqua), 0, 0, 250, 150)
      
      ' Save the Bitmap to the OutputStream property.
      bmp.Save(Response.OutputStream, ImageFormat.Jpeg)
      
      ' Release the Graphics and Bitmap object
      ' and terminate the response.
      g.Dispose()
      bmp.Dispose()
      Response.End()
 ' </snippet1>    
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Insert content here -->
    </form>
</body>
</html>
