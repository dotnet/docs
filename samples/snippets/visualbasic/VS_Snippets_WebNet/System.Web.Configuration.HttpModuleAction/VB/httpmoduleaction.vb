Imports System
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.HttpModuleAction 
' members selected by the user.

Class UsingHttpModuleAction
   
   
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
      
      ' </Snippet1>
      
      ' <Snippet2>
      ' Create a new section object.
        Dim newModuleAction _
        As New HttpModuleAction("MyModule", _
        "MyModuleType")
      
      ' </Snippet2>
      
      ' <Snippet3>
      ' Initialize the module name and type properties.
      newModuleAction.Name = "ModuleName"
      newModuleAction.Type = "ModuleType"
      
      ' </Snippet3>
      ' <Snippet4>
      ' Get the modules collection.
        Dim httpModules _
        As HttpModuleActionCollection = httpModulesSection.Modules
        Dim moduleFound As String = _
        "moduleName not found."
      
      ' Find the module with the specified name.
      Dim currentModule As HttpModuleAction
      For Each currentModule In  httpModules
         If currentModule.Name = "moduleName" Then
            moduleFound = "moduleName found."
         End If 
      Next currentModule
      ' </Snippet4>
      
      
      ' <Snippet5>
      ' Get the modules collection.
        Dim httpModules2 _
        As HttpModuleActionCollection = httpModulesSection.Modules
        Dim typeFound As String = _
        "typeName not found."
      
      ' Find the module with the specified type.
        Dim currentModule1 As HttpModuleAction
        For Each currentModule1 In httpModules2
            If currentModule1.Type = "typeName" Then
                typeFound = "typeName found."
            End If
        Next currentModule1
        ' </Snippet5>
    End Sub 'Main 
End Class 'UsingHttpModuleAction


