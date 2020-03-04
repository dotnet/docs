<!--<snippet1>-->
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ import NameSpace="System.Web" %>
<%@ Import Namespace="System.Xml.XPath" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<html>
   <script language="C#" runat="server">
      void Page_Load(Object sender, EventArgs e) 
      {
         // Load the XML document to transform.
         XPathDocument doc = new XPathDocument(Server.MapPath("books.xml"));

         // Load the stylesheet and perform the transform.
         XslTransform xslt = new XslTransform();
         xslt.Load(Server.MapPath("output.xsl"));
         xslt.Transform(doc, null, Response.OutputStream, null);
        
      }
   </script>
</html>
<!--</snippet1>-->