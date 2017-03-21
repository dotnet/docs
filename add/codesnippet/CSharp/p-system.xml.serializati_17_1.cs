private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   Console.WriteLine
   ("UnknownNode Text: " + e.Text);
}
   