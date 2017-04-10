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

    Public Class TableConsumerWebPart
        Inherits WebPart

        Private _provider As IWebPartTable
        Private _tableData As ICollection

        Private Sub GetTableData(ByVal tableData As ICollection)
            _tableData = CType(tableData, ICollection)

        End Sub 'GetTableValue

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not (_provider Is Nothing) Then
                _provider.GetTableData((New TableCallback(AddressOf GetTableData)))
            End If
            'MyBase.OnPreRender(e)

        End Sub 'OnPreRender

        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

            If Not (_provider Is Nothing) Then
                Dim props As PropertyDescriptorCollection = _provider.Schema
                Dim count As Integer = 0

                If Not (props Is Nothing) AndAlso props.Count > 0 _
                  AndAlso Not (_tableData Is Nothing) Then
                    For Each prop As PropertyDescriptor In props
                        For Each o As DataRow In _tableData
                            writer.Write(prop.DisplayName & ": " & o(count).ToString())
                        Next
                        writer.WriteBreak()
                        writer.WriteLine()
                        count = count + 1
                    Next
                Else
                    writer.Write("No data")
                End If
            Else
                writer.Write("Not connected")
            End If

        End Sub 'RenderContents

        <ConnectionConsumer("Table")> _
        Public Sub SetConnectionInterface(ByVal provider As IWebPartTable)
            _provider = provider

        End Sub 'SetConnectionInterface

        Private Class TableConsumerConnectionPoint
            Inherits ConsumerConnectionPoint

            Public Sub New(ByVal callbackMethod As MethodInfo, _
              ByVal interfaceType As Type, ByVal controlType As Type, _
              ByVal name As String, ByVal id As String, _
              ByVal allowsMultipleConnections As Boolean)
                MyBase.New(callbackMethod, interfaceType, controlType, _
                  name, id, allowsMultipleConnections)

            End Sub 'New
        End Class 'TableConsumerConnectionPoint 
    End Class 'TableConsumerWebPart

End Namespace
'</Snippet2>