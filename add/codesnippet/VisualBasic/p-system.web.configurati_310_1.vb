' Get the modules collection.
Dim httpModules As HttpModuleActionCollection = httpModulesSection.Modules

' Read the modules information.
Dim modulesInfo As New StringBuilder()
Dim i As Integer
For i = 0 To httpModules.Count
  modulesInfo.Append(String.Format("Name: {0}" + vbLf + "Type: {1}" + vbLf + vbLf, httpModules(i).Name, httpModules(i).Type))
Next i
