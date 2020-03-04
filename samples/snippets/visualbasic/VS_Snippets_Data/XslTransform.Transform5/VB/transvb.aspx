<!--<snippet1>-->
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ import NameSpace="System.Web" %>
<%@ Import Namespace="System.Xml.XPath" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<html>
   <script language="VB" runat="server">
      sub Page_Load(sender as Object, e as EventArgs) 

         ' Load the XML document to transform.
         dim doc as XPathDocument = new XPathDocument(Server.MapPath("books.xml"))

         ' Load the stylesheet and perform the transform.
         dim xslt as XslTransform = new XslTransform()
         xslt.Load(Server.MapPath("output.xsl"))
         xslt.Transform(doc, nothing, Response.OutputStream, nothing)
        
      end sub
   </script>
</html>
<!--</snippet1>-->