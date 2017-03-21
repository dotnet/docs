private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   object o = e.ObjectBeingDeserialized;
   Console.WriteLine("Object being deserialized: " 
   + o.ToString());
       
}
   