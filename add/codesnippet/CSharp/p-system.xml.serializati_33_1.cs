private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   XmlNodeType myNodeType = e.NodeType;
   Console.WriteLine(myNodeType);
}
   