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

        // Get the AutoImportVBNamespace property.
        Console.WriteLine("AutoImportVBNamespace: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace.ToString());

        // Set the AutoImportVBNamespace property.
        pagesSection.Namespaces.AutoImportVBNamespace = true;
 
        // Get all current Namespaces in the collection.
        for (int i = 0; i < pagesSection.Namespaces.Count; i++)
        {
          Console.WriteLine(
              "Namespaces {0}: '{1}'", i,
              pagesSection.Namespaces[i].Namespace);
        }

        // Create a new NamespaceInfo object.
        System.Web.Configuration.NamespaceInfo namespaceInfo =
            new System.Web.Configuration.NamespaceInfo("System");

        // Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections";

        // Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo);

        // Add a NamespaceInfo object using a constructor.
        pagesSection.Namespaces.Add(
            new System.Web.Configuration.NamespaceInfo(
            "System.Collections.Specialized"));

        // Execute the RemoveAt method.
        pagesSection.Namespaces.RemoveAt(0);

        // Execute the Clear method.
        pagesSection.Namespaces.Clear();

        // Execute the Remove method.
        pagesSection.Namespaces.Remove("System.Collections");

        // Get the current AutoImportVBNamespace property value.
        Console.WriteLine(
            "Current AutoImportVBNamespace value: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace);

        // Set the AutoImportVBNamespace property to false.
        pagesSection.Namespaces.AutoImportVBNamespace = false;

        // Get the current PageParserFilterType property value.
        Console.WriteLine(
            "Current PageParserFilterType value: '{0}'",
            pagesSection.PageParserFilterType);

        // Set the PageParserFilterType property to
        // "MyNameSpace.AllowOnlySafeControls".
        pagesSection.PageParserFilterType =
            "MyNameSpace.AllowOnlySafeControls";

        // Get the current Theme property value.
        Console.WriteLine(
            "Current Theme value: '{0}'",
            pagesSection.Theme);

        // Set the Theme property to "MyCustomTheme".
        pagesSection.Theme = "MyCustomTheme";

        // Get the current EnableViewState property value.
        Console.WriteLine(
            "Current EnableViewState value: '{0}'",
            pagesSection.EnableViewState);

        // Set the EnableViewState property to false.
        pagesSection.EnableViewState = false;

        // Get the current CompilationMode property value.
        Console.WriteLine(
            "Current CompilationMode value: '{0}'",
            pagesSection.CompilationMode);

        // Set the CompilationMode property to CompilationMode.Always.
        pagesSection.CompilationMode = CompilationMode.Always;

        // Get the current ValidateRequest property value.
        Console.WriteLine(
            "Current ValidateRequest value: '{0}'",
            pagesSection.ValidateRequest);

        // Set the ValidateRequest property to true.
        pagesSection.ValidateRequest = true;

        // Get the current EnableViewStateMac property value.
        Console.WriteLine(
            "Current EnableViewStateMac value: '{0}'",
            pagesSection.EnableViewStateMac);

        // Set the EnableViewStateMac property to true.
        pagesSection.EnableViewStateMac = true;

        // Get the current AutoEventWireup property value.
        Console.WriteLine(
            "Current AutoEventWireup value: '{0}'",
            pagesSection.AutoEventWireup);

        // Set the AutoEventWireup property to false.
        pagesSection.AutoEventWireup = false;

        // Get the current MaxPageStateFieldLength property value.
        Console.WriteLine(
            "Current MaxPageStateFieldLength value: '{0}'",
            pagesSection.MaxPageStateFieldLength);

        // Set the MaxPageStateFieldLength property to 4098.
        pagesSection.MaxPageStateFieldLength = 4098;

        // Get the current UserControlBaseType property value.
        Console.WriteLine(
            "Current UserControlBaseType value: '{0}'",
            pagesSection.UserControlBaseType);

        // Set the UserControlBaseType property to
        // "MyNameSpace.MyCustomControlBaseType".
        pagesSection.UserControlBaseType =
            "MyNameSpace.MyCustomControlBaseType";

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

        // Create a new TagPrefixInfo object.
        System.Web.Configuration.TagPrefixInfo tagPrefixInfo =
            new System.Web.Configuration.TagPrefixInfo("MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", "MyControl.ascx");

        // Execute the Add Method.
        pagesSection.Controls.Add(tagPrefixInfo);

        // Add a TagPrefixInfo object using a constructor.
        pagesSection.Controls.Add(
            new System.Web.Configuration.TagPrefixInfo(
            "MyCtrl", "MyNameSpace", "MyAssembly", "MyControl",
            "MyControl.ascx"));

        // Get the current StyleSheetTheme property value.
        Console.WriteLine(
            "Current StyleSheetTheme value: '{0}'",
            pagesSection.StyleSheetTheme);

        // Set the StyleSheetTheme property.
        pagesSection.StyleSheetTheme =
            "MyCustomStyleSheetTheme";

        // Get the current EnableSessionState property value.
        Console.WriteLine(
            "Current EnableSessionState value: '{0}'",
            pagesSection.EnableSessionState);

        // Set the EnableSessionState property to
        // PagesEnableSessionState.ReadOnly.
        pagesSection.EnableSessionState =
            PagesEnableSessionState.ReadOnly;
 
        // Get the current MasterPageFile property value.
        Console.WriteLine(
            "Current MasterPageFile value: '{0}'",
            pagesSection.MasterPageFile);

        // Set the MasterPageFile property to "MyMasterPage.ascx".
        pagesSection.MasterPageFile = "MyMasterPage.ascx";

        // Get the current Buffer property value.
        Console.WriteLine(
            "Current Buffer value: '{0}'", pagesSection.Buffer);

        // Set the Buffer property to true.
        pagesSection.Buffer = true;

        // Get all current TagMappings in the collection.
        for (int i = 0; i < pagesSection.TagMapping.Count; i++)
        {
          Console.WriteLine("TagMapping {0}:", i);
          Console.WriteLine("  TagTypeName = '{0}'",
              pagesSection.TagMapping[i].TagType);
          Console.WriteLine("  MappedTagTypeName = '{0}'",
              pagesSection.TagMapping[i].MappedTagType);
        }

        // Add a TagMapInfo object using a constructor.
        pagesSection.TagMapping.Add(
            new System.Web.Configuration.TagMapInfo(
            "MyNameSpace.MyControl", "MyNameSpace.MyOtherControl"));

        // Get the current PageBaseType property value.
        Console.WriteLine(
            "Current PageBaseType value: '{0}'",
            pagesSection.PageBaseType);

        // Set the PageBaseType property to
        // "MyNameSpace.MyCustomPagelBaseType".
        pagesSection.PageBaseType =
            "MyNameSpace.MyCustomPagelBaseType";

        // Get the current SmartNavigation property value.
        Console.WriteLine(
            "Current SmartNavigation value: '{0}'",
            pagesSection.SmartNavigation);

        // Set the SmartNavigation property to true.
        pagesSection.SmartNavigation = true;

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