' <Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web.UI

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingPagesSection
    Public Shared Sub Main()
      Try
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("")

        ' Get the section.
        Dim pagesSection As System.Web.Configuration.PagesSection = _
            CType(configuration.GetSection("system.web/pages"), _
            System.Web.Configuration.PagesSection)

        ' <Snippet2>
        ' <Snippet20>
        ' Get the AutoImportVBNamespace property.
        Console.WriteLine( _
         "AutoImportVBNamespace: '{0}'", _
         pagesSection.Namespaces.AutoImportVBNamespace)

        ' Set the AutoImportVBNamespace property.
        pagesSection.Namespaces.AutoImportVBNamespace = True
        ' </Snippet20>

        ' <Snippet21>
        ' Get all current Namespaces in the collection.
        Dim i As Int16
        For i = 0 To pagesSection.Namespaces.Count - 1
          Console.WriteLine( _
           "Namespaces {0}: '{1}'", i, _
           pagesSection.Namespaces(i).Namespace)
        Next
        ' </Snippet21>

        ' <Snippet22>
        ' <Snippet28>
        ' Create a new NamespaceInfo object.
        Dim namespaceInfo As System.Web.Configuration.NamespaceInfo = _
         New System.Web.Configuration.NamespaceInfo("System")
        ' </Snippet28>

        ' <Snippet29>
        ' Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections"
        ' </Snippet29>

        ' Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo)
        ' </Snippet22>

        ' <Snippet23>
        ' Add a NamespaceInfo object using a constructor.
        pagesSection.Namespaces.Add( _
         New System.Web.Configuration.NamespaceInfo( _
         "System.Collections.Specialized"))
        ' </Snippet23>

        ' <Snippet25>
        ' Execute the RemoveAt method.
        pagesSection.Namespaces.RemoveAt(0)
        ' </Snippet25>

        ' <Snippet24>
        ' Execute the Clear method.
        pagesSection.Namespaces.Clear()
        ' </Snippet24>

        ' <Snippet26>
        ' Execute the Remove method.
        pagesSection.Namespaces.Remove("System.Collections")
        ' </Snippet26>

        ' <Snippet27>
        ' Get the current AutoImportVBNamespace property value.
        Console.WriteLine( _
         "Current AutoImportVBNamespace value: '{0}'", _
         pagesSection.Namespaces.AutoImportVBNamespace)

        ' Set the AutoImportVBNamespace property to false.
        pagesSection.Namespaces.AutoImportVBNamespace = False
        ' </Snippet27>
        ' </Snippet2>

        ' <Snippet3>
        ' Get the current PageParserFilterType property value.
        Console.WriteLine( _
            "Current PageParserFilterType value: '{0}'", _
            pagesSection.PageParserFilterType)

        ' Set the PageParserFilterType property to
        ' "MyNameSpace.AllowOnlySafeControls".
        pagesSection.PageParserFilterType = _
            "MyNameSpace.AllowOnlySafeControls"
        ' </Snippet3>

        ' <Snippet4>
        ' Get the current Theme property value.
        Console.WriteLine( _
            "Current Theme value: '{0}'", pagesSection.Theme)

        ' Set the Theme property to "MyCustomTheme".
        pagesSection.Theme = "MyCustomTheme"
        ' </Snippet4>

        ' <Snippet5>
        ' Get the current EnableViewState property value.
        Console.WriteLine( _
            "Current EnableViewState value: '{0}'", _
            pagesSection.EnableViewState)

        ' Set the EnableViewState property to false.
        pagesSection.EnableViewState = False
        ' </Snippet5>

        ' <Snippet6>
        ' Get the current CompilationMode property value.
        Console.WriteLine( _
            "Current CompilationMode value: '{0}'", _
            pagesSection.CompilationMode)

        ' Set the CompilationMode property to CompilationMode.Always.
        pagesSection.CompilationMode = CompilationMode.Always
        ' </Snippet6>

        ' <Snippet7>
        ' Get the current ValidateRequest property value.
        Console.WriteLine( _
            "Current ValidateRequest value: '{0}'", _
            pagesSection.ValidateRequest)

        ' Set the ValidateRequest property to true.
        pagesSection.ValidateRequest = True
        ' </Snippet7>

        ' <Snippet8>
        ' Get the current EnableViewStateMac property value.
        Console.WriteLine( _
            "Current EnableViewStateMac value: '{0}'", _
            pagesSection.EnableViewStateMac)

        ' Set the EnableViewStateMac property to true.
        pagesSection.EnableViewStateMac = True
        ' </Snippet8>

        ' <Snippet9>
        ' Get the current AutoEventWireup property value.
        Console.WriteLine( _
            "Current AutoEventWireup value: '{0}'", _
            pagesSection.AutoEventWireup)

        ' Set the AutoEventWireup property to false.
        pagesSection.AutoEventWireup = False
        ' </Snippet9>

        ' <Snippet10>
        ' Get the current MaxPageStateFieldLength property value.
        Console.WriteLine( _
            "Current MaxPageStateFieldLength value: '{0}'", _
            pagesSection.MaxPageStateFieldLength)

        ' Set the MaxPageStateFieldLength property to 4098.
        pagesSection.MaxPageStateFieldLength = 4098
        ' </Snippet10>

        ' <Snippet11>
        ' Get the current UserControlBaseType property value.
        Console.WriteLine( _
            "Current UserControlBaseType value: '{0}'", _
            pagesSection.UserControlBaseType)

        ' Set the UserControlBaseType property to
        ' "MyNameSpace.MyCustomControlBaseType".
        pagesSection.UserControlBaseType = _
            "MyNameSpace.MyCustomControlBaseType"
        ' </Snippet11>

        ' <Snippet12>
        ' <Snippet30>
        ' Get all current Controls in the collection.
        Dim j As Int32
        For j = 0 To pagesSection.Controls.Count - 1
          Console.WriteLine("Control {0}:", j)
          Console.WriteLine("  TagPrefix = '{0}' ", _
           pagesSection.Controls(j).TagPrefix)
          Console.WriteLine("  TagName = '{0}' ", _
           pagesSection.Controls(j).TagName)
          Console.WriteLine("  Source = '{0}' ", _
           pagesSection.Controls(j).Source)
          Console.WriteLine("  Namespace = '{0}' ", _
           pagesSection.Controls(j).Namespace)
          Console.WriteLine("  Assembly = '{0}' ", _
           pagesSection.Controls(j).Assembly)
        Next
        ' </Snippet30>

        ' <Snippet31>
        ' <Snippet33>
        ' Create a new TagPrefixInfo object.
        Dim tagPrefixInfo As System.Web.Configuration.TagPrefixInfo = _
         New System.Web.Configuration.TagPrefixInfo("MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", "MyControl.ascx")
        ' </Snippet33>

        ' <Snippet39>
        ' Execute the Add Method.
        pagesSection.Controls.Add(tagPrefixInfo)
        ' </Snippet39>
        ' </Snippet31>

        ' <Snippet32>
        ' Add a TagPrefixInfo object using a constructor.
        pagesSection.Controls.Add( _
         New System.Web.Configuration.TagPrefixInfo( _
         "MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", _
         "MyControl.ascx"))
        ' </Snippet32>
        ' </Snippet12>

        ' <Snippet13>
        ' Get the current StyleSheetTheme property value.
        Console.WriteLine( _
            "Current StyleSheetTheme value: '{0}'", _
            pagesSection.StyleSheetTheme)

        ' Set the StyleSheetTheme property to
        ' "MyCustomStyleSheetTheme".
        pagesSection.StyleSheetTheme = "MyCustomStyleSheetTheme"
        ' </Snippet13>

        ' <Snippet14>
        ' Get the current EnableSessionState property value.
        Console.WriteLine( _
            "Current EnableSessionState value: '{0}'", pagesSection.EnableSessionState)

        ' Set the EnableSessionState property to
        ' PagesEnableSessionState.ReadOnly.
        pagesSection.EnableSessionState = PagesEnableSessionState.ReadOnly
        ' </Snippet14>

        ' <Snippet15>
        ' Get the current MasterPageFile property value.
        Console.WriteLine( _
            "Current MasterPageFile value: '{0}'", _
            pagesSection.MasterPageFile)

        ' Set the MasterPageFile property to "MyMasterPage.ascx".
        pagesSection.MasterPageFile = "MyMasterPage.ascx"
        ' </Snippet15>

        ' <Snippet16>
        ' Get the current Buffer property value.
        Console.WriteLine( _
            "Current Buffer value: '{0}'", pagesSection.Buffer)

        ' Set the Buffer property to true.
        pagesSection.Buffer = True
        ' </Snippet16>

        ' <Snippet17>
        ' <Snippet40>
        ' Get all current TagMappings in the collection.
        Dim k As Int32
        For k = 1 To pagesSection.TagMapping.Count
          Console.WriteLine("TagMapping {0}:", i)
          Console.WriteLine("  TagTypeName = '{0}'", _
           pagesSection.TagMapping(k).TagType)
          Console.WriteLine("  MappedTagTypeName = '{0}'", _
           pagesSection.TagMapping(k).MappedTagType)
        Next
        ' </Snippet40>

        ' <Snippet42>
        ' Add a TagMapInfo object using a constructor.
        pagesSection.TagMapping.Add( _
         New System.Web.Configuration.TagMapInfo( _
         "MyNameSpace.MyControl", "MyNameSpace.MyOtherControl"))
        ' </Snippet42>
        ' </Snippet17>

        ' <Snippet18>
        ' Get the current PageBaseType property value.
        Console.WriteLine( _
            "Current PageBaseType value: '{0}'", pagesSection.PageBaseType)

        ' Set the PageBaseType property to
        ' "MyNameSpace.MyCustomPagelBaseType".
        pagesSection.PageBaseType = "MyNameSpace.MyCustomPagelBaseType"
        ' </Snippet18>

        ' <Snippet19>
        ' Get the current SmartNavigation property value.
        Console.WriteLine( _
            "Current SmartNavigation value: '{0}'", pagesSection.SmartNavigation)

        ' Set the SmartNavigation property to true.
        pagesSection.SmartNavigation = True
        ' </Snippet19>

        ' Update if not locked.
        If Not pagesSection.SectionInformation.IsLocked Then
          configuration.Save()
          Console.WriteLine("** Configuration updated.")
        Else
          Console.WriteLine("** Could not update, section is locked.")
        End If
      Catch e As System.Exception
        ' Unknown error.
        Console.WriteLine("A unknown exception detected in " & _
        "UsingPagesSection Main.")
        Console.WriteLine(e)
      End Try
      Console.ReadLine()
    End Sub
  End Class ' UsingPagesSection.
End Namespace ' Samples.Aspnet.SystemWebConfiguration
' </Snippet1>
