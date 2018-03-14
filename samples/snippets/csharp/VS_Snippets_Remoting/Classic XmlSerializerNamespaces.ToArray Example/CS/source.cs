using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
private void PrintNamespacePairs(XmlSerializerNamespaces namespaces)
{
   XmlQualifiedName[] qualifiedNames = namespaces.ToArray();
   for(int i = 0; i < qualifiedNames.Length; i++)
   {
      Console.WriteLine
      (
      qualifiedNames[i].Name + "\t" +
      qualifiedNames[i].Namespace
      );
   }
}

// </Snippet1>
}
