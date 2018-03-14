
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text


' Exercises the HttpModuleActionCollection members. 

Class UsingHttpModuleActionCollection
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim httpModulesSection As HttpModulesSection = _
        CType(configuration.GetSection( _
        "system.web/httpModules"), HttpModulesSection)
      
      ' Get the collection.
        Dim modulesCollection _
        As HttpModuleActionCollection = httpModulesSection.Modules
      
      ' </Snippet1>
      ' <Snippet2>
      ' Create a new HttpModuleActionCollection object.
        Dim newModuleActionCollection _
        As New HttpModuleActionCollection()
      
      ' </Snippet2>
      '<Snippet3>
      ' Create a new module object.
        Dim ModuleAction As New HttpModuleAction( _
        "MyModuleName", "MyModuleType")
        ' Add the module to the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Add(ModuleAction)
            configuration.Save()
        End If

        '</Snippet3>
        '<Snippet4>

        ' Set the module object.
        Dim ModuleAction1 _
        As New HttpModuleAction( _
        "MyModule1Name", "MyModule1Type")
        ' Get the module collection index.
        Dim moduleIndex As Integer = _
        modulesCollection.IndexOf(ModuleAction1)

        '</Snippet4>

        '<Snippet5>
        ' Set the module object.
        Dim ModuleAction2 As New HttpModuleAction( _
        "MyModule2Name", "MyModule2Type")
        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Remove(ModuleAction2)
            configuration.Save()
        End If

        '</Snippet5>

        '<Snippet6>
        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Remove("MyModule2Name")
            configuration.Save()
        End If

        '</Snippet6>
        '<Snippet7>
        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.RemoveAt(0)
            configuration.Save()
        End If

        '</Snippet7>
        '<Snippet8>
        ' Clear the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Clear()
            configuration.Save()
        End If
        '</Snippet8>

   End Sub 'Main 
End Class 'UsingHttpModuleActionCollection 

