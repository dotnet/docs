Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.IO
Imports System.Reflection
Imports Microsoft.LightSwitch.Model

<Export(GetType(IApplicationDefinitionLoaderService))> _
Public Class ApplicationDefinitionLoader
    Implements IApplicationDefinitionLoaderService

    Public Function LoadModelFragments() As IEnumerable(Of Stream) _
            Implements IApplicationDefinitionLoaderService.LoadModelFragments
        Dim executingAssembly = Assembly.GetExecutingAssembly()
        Dim definitionStreams As New List(Of Stream)()
        For Each resourceName In executingAssembly.GetManifestResourceNames()
            If resourceName.EndsWith(".lsml") Then
                definitionStreams.Add(executingAssembly.GetManifestResourceStream(resourceName))
            End If
        Next
        Return definitionStreams
    End Function
End Class

