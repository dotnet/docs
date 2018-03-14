// <Snippet1>
using System;
using System.IO;
using System.Xml;


public class Sample
{
  public static void Main()
  {
    Sample test = new Sample();
  }
  public Sample()
  {
    // Create the XmlNamespaceManager.
    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);

    // Add prefix/namespace pairs to the XmlNamespaceManager.
    nsmgr.AddNamespace("", "www.wideworldimporters.com"); //Adds a default namespace.
    nsmgr.AddNamespace("europe", "www.wideworldimporters.com/europe");
    nsmgr.PushScope();  //Pushes a namespace scope on the stack.
    nsmgr.AddNamespace("", "www.lucernepublishing.com"); //Adds another default namespace.
    nsmgr.AddNamespace("partners", "www.lucernepublishing.com/partners");

    Console.WriteLine("Show all the prefix/namespace pairs in the XmlNamespaceManager...");
    ShowAllNamespaces(nsmgr);
  }

  private void ShowAllNamespaces(XmlNamespaceManager nsmgr)
  {
    do{
       foreach (String prefix in nsmgr)
       {
        Console.WriteLine("Prefix={0}, Namespace={1}", prefix,nsmgr.LookupNamespace(prefix));
       } 
    }
    while (nsmgr.PopScope());
  }
}
   // </Snippet1>

