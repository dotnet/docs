private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   Console.WriteLine
   ("UnknownNode Namespace URI: " + e.NamespaceURI);
}
   