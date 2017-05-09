<!-- <Snippet1> -->
<%@ Page language="c#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Create the SiteMapPath control.
        SiteMapPath navpath = new SiteMapPath();

        // Make the root node look unique.
        // The Image that you can use in your Web page is an
        // instance of the WebControls.Image class, not the
        // Drawing.Image class.
        System.Web.UI.WebControls.Image rootNodeImage =
            new System.Web.UI.WebControls.Image();
        rootNodeImage.ImageUrl = "myimage.jpg";
        ImageTemplate rootNodeImageTemplate = new ImageTemplate();
        rootNodeImageTemplate.MyImage = rootNodeImage;
        navpath.RootNodeTemplate = rootNodeImageTemplate;

        // Make the current node look unique.
        Style currentNodeStyle = new Style();
        navpath.CurrentNodeStyle.ForeColor = System.Drawing.Color.AliceBlue;
        navpath.CurrentNodeStyle.BackColor = System.Drawing.Color.Bisque;

        // Set the path separator to be something other
        // than the default.
        navpath.PathSeparator = "::";

        PlaceHolder1.Controls.Add(navpath);
    }


    // A simple Template class to wrap an image.
    public class ImageTemplate : ITemplate
    {
        private System.Web.UI.WebControls.Image myImage;
        public System.Web.UI.WebControls.Image MyImage
        {
            get
            {
                return myImage;
            }
            set
            {
                myImage = value;
            }
        }
        public void InstantiateIn(Control container)
        {
            container.Controls.Add(MyImage);
        }
    }
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