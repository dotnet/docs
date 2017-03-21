private XmlSerializerNamespaces CreateFromQNames()
{
   XmlQualifiedName q1 = 
   new XmlQualifiedName("money", "http://www.cohowinery.com");
        
   XmlQualifiedName q2 = 
   new XmlQualifiedName("books", "http://www.cpandl.com");
        
   XmlQualifiedName[] names = {q1, q2};

   return new XmlSerializerNamespaces(names);
}
