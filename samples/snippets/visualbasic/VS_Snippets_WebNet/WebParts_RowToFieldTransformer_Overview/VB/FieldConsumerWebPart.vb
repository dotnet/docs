'<Snippet2>
Imports System
Imports System.ComponentModel
Imports System.Reflection
Imports System.Collections
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls
    ' This sample code creates a Web Parts control that acts as 
    ' a consumer of an IField interface.

    Public Class FieldConsumerWebPart
        Inherits WebPart

        Private _provider As IWebPartField
        Private _fieldValue As Object

        Private Sub GetFieldValue(ByVal fieldValue As Object)
            _fieldValue = fieldValue

        End Sub 'GetFieldValue

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not (_provider Is Nothing) Then
                _provider.GetFieldValue((New FieldCallback(AddressOf GetFieldValue)))
            End If
            MyBase.OnPreRender(e)

        End Sub 'OnPreRender

        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

            If Not (_provider Is Nothing) Then
                Dim prop As PropertyDescriptor = _provider.Schema

                If Not (prop Is Nothing) AndAlso Not (_fieldValue Is Nothing) Then
                    writer.Write(prop.DisplayName & ": " & _fieldValue)
                Else
                    writer.Write("No data")
                End If
            Else
                writer.Write("Not connected")
            End If

        End Sub 'RenderContents

        <ConnectionConsumer("Field")> _
        Public Sub SetConnectionInterface(ByVal provider As IWebPartField)
            _provider = provider

        End Sub 'SetConnectionInterface

        Private Class FieldConsumerConnectionPoint
            Inherits ConsumerConnectionPoint

            Public Sub New(ByVal callbackMethod As MethodInfo, _
              ByVal interfaceType As Type, ByVal controlType As Type, _
              ByVal name As String, ByVal id As String, _
              ByVal allowsMultipleConnections As Boolean)
                MyBase.New(callbackMethod, interfaceType, controlType, _
                  name, id, allowsMultipleConnections)

            End Sub 'New
        End Class 'FieldConsumerConnectionPoint 
    End Class 'FieldConsumerWebPart
    '</Snippet2>
End Namespace