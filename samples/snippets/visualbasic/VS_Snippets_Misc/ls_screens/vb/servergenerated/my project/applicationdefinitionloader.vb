Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.IO
Imports System.Reflection
Imports Microsoft.LightSwitch.Model

<Export(GetType(IApplicationDefinitionLoaderService))> _
Public Class ApplicationDefinitionLoader
    Implements IApplicationDefinitionLoaderService
    Private Const AppDefinition as String = "bin\ApplicationDefinition.lsml"
    Public Function LoadModelFragments() As IEnumerable(Of Stream) _
            Implements IApplicationDefinitionLoaderService.LoadModelFragments
        Dim definitionStreams As New List(Of Stream)()
        definitionStreams.Add(File.OpenRead(AppDefinition))
        Return definitionStreams
    End Function
End Class