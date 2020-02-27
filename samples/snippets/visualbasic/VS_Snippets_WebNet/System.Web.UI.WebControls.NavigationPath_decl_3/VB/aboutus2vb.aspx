<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)
        ' Create the SiteMapPath control.
        Dim navpath As New SiteMapPath()

        ' Make the root node look unique.
        ' The Image that you can use in your Web page is an
        ' instance of the WebControls.Image class, not the
        ' Drawing.Image class.
        Dim rootNodeImage As New System.Web.UI.WebControls.Image()
        rootNodeImage.ImageUrl = "myimage.jpg"
        Dim rootNodeImageTemplate As New ImageTemplate()
        rootNodeImageTemplate.MyImage = rootNodeImage
        navpath.RootNodeTemplate = rootNodeImageTemplate

        ' Make the current node look unique.
        Dim currentNodeStyle As New Style()
        navpath.CurrentNodeStyle.ForeColor = System.Drawing.Color.AliceBlue
        navpath.CurrentNodeStyle.BackColor = System.Drawing.Color.Bisque

        ' Set the path separator to be something other
        ' than the default.
        navpath.PathSeparator = "::"

        PlaceHolder1.Controls.Add(navpath)
    End Sub ' Page_Load


    ' A simple Template class to wrap an image.
    Public Class ImageTemplate
      Implements ITemplate

        Private anImage As System.Web.UI.WebControls.Image
        Public Property MyImage As System.Web.UI.WebControls.Image
          Get
            return anImage
          End Get
          Set
            anImage = value
          End Set
        End Property ' MyImage

        Public Overridable Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
            container.Controls.Add(MyImage)
        End Sub ' InstantiateIn

    End Class ' ImageTemplate
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>About Our Company</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">

      <asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>

      <h1>About Our Company</h1>

      <p>Our company was founded in 1886.</p>

      <p>We use only the finest ingredients, organically grown fruits, and
      natural spices in our homemade pies. We use no artificial preservatives
      or coloring agents. We would not have it any other way!</p>

    </form>
  </body>
</html>
<!-- </Snippet1> -->