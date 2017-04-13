Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.IO
Imports System.Reflection
Imports System.Xml.Linq
Imports Microsoft.LightSwitch.Model

<Export(GetType(IApplicationDefinitionLoaderService))> _
Public Class ApplicationDefinitionLoader
    Implements IApplicationDefinitionLoaderService
    Private Const AppDefinition as String = "ApplicationDefinition.lsml"
    Public Function LoadModelFragments() As IEnumerable(Of Stream) _
            Implements IApplicationDefinitionLoaderService.LoadModelFragments
        Dim definitionStreams As New List(Of Stream)()

        Dim xdoc As XDocument = XDocument.Load(AppDefinition)
        Dim ms As New MemoryStream()
        xdoc.Save(ms)
        ms.Seek(0, SeekOrigin.Begin)
        definitionStreams.Add(ms)

        Return definitionStreams
    End Function
End Class