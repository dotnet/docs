<!-- <Snippet1> -->
<%@ Page Language="C#" %>

    <!DOCTYPE html
        PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script runat="server">
  protected void Page_Load(object sender, EventArgs e)
        {
            <!-- <Snippet2> -->
    StringBuilder sb = new StringBuilder();
    String pathstring = Context.Request.FilePath.ToString();
            sb.Append("Current file path = " + pathstring + "<br />");
            sb.Append("File name = " + VirtualPathUtility.GetFileName(pathstring).ToString() + "<br />");
            sb.Append("File extension = " + VirtualPathUtility.GetExtension(pathstring).ToString() + "<br />");
            sb.Append("Directory = " + VirtualPathUtility.GetDirectory(pathstring).ToString() + "<br />");
            Response.Write(sb.ToString());
        <!-- </Snippet2> -->

            <!-- <Snippet3> -->
    StringBuilder sb2 = new StringBuilder();
            <!-- </Snippet3> -->
        }
    </script>

    </html>
    <!-- </Snippet1> -->
