using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace Microsoft.WCF.Documentation
{
  public class CustomPolicyImporter : IPolicyImportExtension
  {
    // <snippet1>
    #region IPolicyImporter Members
    public const string name1 = "acme";
    public const string ns1 = "http://Microsoft/WCF/Documentation/CustomPolicyAssertions";

    /*
     * Importing policy assertions usually means modifying the bindingelement stack in some way
     * to support the policy assertion. The procedure is:
     * 1. Find the custom assertion to import.
     * 2. Insert a supporting custom bindingelement or modify the current binding element collection
     *     to support the assertion.
     * 3. Remove the assertion from the collection. Once the ImportPolicy method has returned,
     *     any remaining assertions for the binding cause the binding to fail import and not be
     *     constructed.
     */
    public void ImportPolicy(MetadataImporter importer, PolicyConversionContext context)
    {
      Console.WriteLine("The custom policy importer has been called.");
      //<snippet9>
      // Locate the custom assertion and remove it.
      //<snippet8>
      XmlElement customAssertion = context.GetBindingAssertions().Remove(name1, ns1);
      //</snippet8>
      if (customAssertion != null)
      {
        Console.WriteLine(
          "Removed our custom assertion from the imported "
          + "assertions collection and inserting our custom binding element."
        );
        // Here we would add the binding modification that implemented the policy.
        // This sample does not do this.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(customAssertion.NamespaceURI + " : " + customAssertion.Name);
        Console.WriteLine(customAssertion.OuterXml);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      //</snippet9>
   }
  #endregion
// </snippet1>
 }
}
