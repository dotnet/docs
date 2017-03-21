private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   Console.WriteLine
   ("UnknownNode LocalName: " + e.LocalName);
}
