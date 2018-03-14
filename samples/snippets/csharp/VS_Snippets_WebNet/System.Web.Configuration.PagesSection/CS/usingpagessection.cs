// <Snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI;


namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingPagesSection
  {
    public static void Main()
    {
      try
      {
        // Get the Web application configuration.
        Configuration configuration =
          WebConfigurationManager.OpenWebConfiguration("");

        // Get the section.
        PagesSection pagesSection =
            (PagesSection)configuration.GetSection("system.web/pages");

        // <Snippet2>
        // <Snippet20>
        // Get the AutoImportVBNamespace property.
        Console.WriteLine("AutoImportVBNamespace: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace.ToString());

        // Set the AutoImportVBNamespace property.
        pagesSection.Namespaces.AutoImportVBNamespace = true;
        // </Snippet20>
 
        // <Snippet21>
        // Get all current Namespaces in the collection.
        for (int i = 0; i < pagesSection.Namespaces.Count; i++)
        {
          Console.WriteLine(
              "Namespaces {0}: '{1}'", i,
              pagesSection.Namespaces[i].Namespace);
        }
        // </Snippet21>

        // <Snippet22>
        // <Snippet28>
        // Create a new NamespaceInfo object.
        System.Web.Configuration.NamespaceInfo namespaceInfo =
            new System.Web.Configuration.NamespaceInfo("System");
        // </Snippet28>

        // <Snippet29>
        // Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections";
        // </Snippet29>

        // Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo);
        // </Snippet22>

        // <Snippet23>
        // Add a NamespaceInfo object using a constructor.
        pagesSection.Namespaces.Add(
            new System.Web.Configuration.NamespaceInfo(
            "System.Collections.Specialized"));
        // </Snippet23>

        // <Snippet25>
        // Execute the RemoveAt method.
        pagesSection.Namespaces.RemoveAt(0);
        // </Snippet25>

        // <Snippet24>
        // Execute the Clear method.
        pagesSection.Namespaces.Clear();
        // </Snippet24>

        // <Snippet26>
        // Execute the Remove method.
        pagesSection.Namespaces.Remove("System.Collections");
        // </Snippet26>

        // <Snippet27>
        // Get the current AutoImportVBNamespace property value.
        Console.WriteLine(
            "Current AutoImportVBNamespace value: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace);

        // Set the AutoImportVBNamespace property to false.
        pagesSection.Namespaces.AutoImportVBNamespace = false;
        // </Snippet27>
        // </Snippet2>

        // <Snippet3>
        // Get the current PageParserFilterType property value.
        Console.WriteLine(
            "Current PageParserFilterType value: '{0}'",
            pagesSection.PageParserFilterType);

        // Set the PageParserFilterType property to
        // "MyNameSpace.AllowOnlySafeControls".
        pagesSection.PageParserFilterType =
            "MyNameSpace.AllowOnlySafeControls";
        // </Snippet3>

        // <Snippet4>
        // Get the current Theme property value.
        Console.WriteLine(
            "Current Theme value: '{0}'",
            pagesSection.Theme);

        // Set the Theme property to "MyCustomTheme".
        pagesSection.Theme = "MyCustomTheme";
        // </Snippet4>

        // <Snippet5>
        // Get the current EnableViewState property value.
        Console.WriteLine(
            "Current EnableViewState value: '{0}'",
            pagesSection.EnableViewState);

        // Set the EnableViewState property to false.
        pagesSection.EnableViewState = false;
        // </Snippet5>

        // <Snippet6>
        // Get the current CompilationMode property value.
        Console.WriteLine(
            "Current CompilationMode value: '{0}'",
            pagesSection.CompilationMode);

        // Set the CompilationMode property to CompilationMode.Always.
        pagesSection.CompilationMode = CompilationMode.Always;
        // </Snippet6>

        // <Snippet7>
        // Get the current ValidateRequest property value.
        Console.WriteLine(
            "Current ValidateRequest value: '{0}'",
            pagesSection.ValidateRequest);

        // Set the ValidateRequest property to true.
        pagesSection.ValidateRequest = true;
        // </Snippet7>

        // <Snippet8>
        // Get the current EnableViewStateMac property value.
        Console.WriteLine(
            "Current EnableViewStateMac value: '{0}'",
            pagesSection.EnableViewStateMac);

        // Set the EnableViewStateMac property to true.
        pagesSection.EnableViewStateMac = true;
        // </Snippet8>

        // <Snippet9>
        // Get the current AutoEventWireup property value.
        Console.WriteLine(
            "Current AutoEventWireup value: '{0}'",
            pagesSection.AutoEventWireup);

        // Set the AutoEventWireup property to false.
        pagesSection.AutoEventWireup = false;
        // </Snippet9>

        // <Snippet10>
        // Get the current MaxPageStateFieldLength property value.
        Console.WriteLine(
            "Current MaxPageStateFieldLength value: '{0}'",
            pagesSection.MaxPageStateFieldLength);

        // Set the MaxPageStateFieldLength property to 4098.
        pagesSection.MaxPageStateFieldLength = 4098;
        // </Snippet10>

        // <Snippet11>
        // Get the current UserControlBaseType property value.
        Console.WriteLine(
            "Current UserControlBaseType value: '{0}'",
            pagesSection.UserControlBaseType);

        // Set the UserControlBaseType property to
        // "MyNameSpace.MyCustomControlBaseType".
        pagesSection.UserControlBaseType =
            "MyNameSpace.MyCustomControlBaseType";
        // </Snippet11>

        // <Snippet12>
        // <Snippet30>
        // Get all current Controls in the collection.
        for (int i = 0; i < pagesSection.Controls.Count; i++)
        {
          Console.WriteLine("Control {0}:", i);
          Console.WriteLine("  TagPrefix = '{0}' ",
              pagesSection.Controls[i].TagPrefix);
          Console.WriteLine("  TagName = '{0}' ",
              pagesSection.Controls[i].TagName);
          Console.WriteLine("  Source = '{0}' ",
              pagesSection.Controls[i].Source);
          Console.WriteLine("  Namespace = '{0}' ",
              pagesSection.Controls[i].Namespace);
          Console.WriteLine("  Assembly = '{0}' ",
              pagesSection.Controls[i].Assembly);
        }
        // </Snippet30>

        // <Snippet31>
        // <Snippet33>
        // Create a new TagPrefixInfo object.
        System.Web.Configuration.TagPrefixInfo tagPrefixInfo =
            new System.Web.Configuration.TagPrefixInfo("MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", "MyControl.ascx");
        // </Snippet33>

        // <Snippet39>
        // Execute the Add Method.
        pagesSection.Controls.Add(tagPrefixInfo);
        // </Snippet39>
        // </Snippet31>

        // <Snippet32>
        // Add a TagPrefixInfo object using a constructor.
        pagesSection.Controls.Add(
            new System.Web.Configuration.TagPrefixInfo(
            "MyCtrl", "MyNameSpace", "MyAssembly", "MyControl",
            "MyControl.ascx"));
        // </Snippet32>
        // </Snippet12>

        // <Snippet13>
        // Get the current StyleSheetTheme property value.
        Console.WriteLine(
            "Current StyleSheetTheme value: '{0}'",
            pagesSection.StyleSheetTheme);

        // Set the StyleSheetTheme property.
        pagesSection.StyleSheetTheme =
            "MyCustomStyleSheetTheme";
        // </Snippet13>

        // <Snippet14>
        // Get the current EnableSessionState property value.
        Console.WriteLine(
            "Current EnableSessionState value: '{0}'",
            pagesSection.EnableSessionState);

        // Set the EnableSessionState property to
        // PagesEnableSessionState.ReadOnly.
        pagesSection.EnableSessionState =
            PagesEnableSessionState.ReadOnly;
        // </Snippet14>
 
        // <Snippet15>
        // Get the current MasterPageFile property value.
        Console.WriteLine(
            "Current MasterPageFile value: '{0}'",
            pagesSection.MasterPageFile);

        // Set the MasterPageFile property to "MyMasterPage.ascx".
        pagesSection.MasterPageFile = "MyMasterPage.ascx";
        // </Snippet15>

        // <Snippet16>
        // Get the current Buffer property value.
        Console.WriteLine(
            "Current Buffer value: '{0}'", pagesSection.Buffer);

        // Set the Buffer property to true.
        pagesSection.Buffer = true;
        // </Snippet16>

        // <Snippet17>
        // <Snippet40>
        // Get all current TagMappings in the collection.
        for (int i = 0; i < pagesSection.TagMapping.Count; i++)
        {
          Console.WriteLine("TagMapping {0}:", i);
          Console.WriteLine("  TagTypeName = '{0}'",
              pagesSection.TagMapping[i].TagType);
          Console.WriteLine("  MappedTagTypeName = '{0}'",
              pagesSection.TagMapping[i].MappedTagType);
        }
        // </Snippet40>

        // <Snippet42>
        // Add a TagMapInfo object using a constructor.
        pagesSection.TagMapping.Add(
            new System.Web.Configuration.TagMapInfo(
            "MyNameSpace.MyControl", "MyNameSpace.MyOtherControl"));
        // </Snippet42>
        // </Snippet17>

        // <Snippet18>
        // Get the current PageBaseType property value.
        Console.WriteLine(
            "Current PageBaseType value: '{0}'",
            pagesSection.PageBaseType);

        // Set the PageBaseType property to
        // "MyNameSpace.MyCustomPagelBaseType".
        pagesSection.PageBaseType =
            "MyNameSpace.MyCustomPagelBaseType";
        // </Snippet18>

        // <Snippet19>
        // Get the current SmartNavigation property value.
        Console.WriteLine(
            "Current SmartNavigation value: '{0}'",
            pagesSection.SmartNavigation);

        // Set the SmartNavigation property to true.
        pagesSection.SmartNavigation = true;
        // </Snippet19>

        // Update if not locked.
        if (!pagesSection.SectionInformation.IsLocked)
        {
          configuration.Save();
          Console.WriteLine("** Configuration updated.");
        }
        else
          Console.WriteLine("** Could not update, section is locked.");
      }
      catch (System.Exception e)
      {
        // Unknown error.
        Console.WriteLine("A unknown exception detected in" +
          "UsingPagesSection Main.");
        Console.WriteLine(e);
      }
      Console.ReadLine();
    }
  } // UsingPagesSection class end.
} // Samples.Aspnet.SystemWebConfiguration namespace end.
// </Snippet1>
