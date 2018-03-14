 '<SNIPPET2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Reflection
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

' This sample code creates a Web Parts control that acts as a consumer of row data.
Namespace MyCustomWebPart

    Public NotInheritable Class RowConsumerWebPart
        Inherits WebPart
        Private _provider As IWebPartRow
        Private _tableData As ICollection


        Private Sub GetRowData(ByVal rowData As Object)
            _tableData = CType(rowData, ICollection)

        End Sub 'GetRowData


        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not (_provider Is Nothing) Then
                '        _provider.GetRowData(AddressOf (New RowCallback(GetRowData)))
                _provider.GetRowData(AddressOf GetRowData)
                '    _provider.GetRowData(New RowCallback(AddressOf GetRowData))
            End If

        End Sub 'OnPreRender



        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            If Not (_provider Is Nothing) Then
                Dim props As PropertyDescriptorCollection = _provider.Schema
                Dim count As Integer = 0
                If Not (props Is Nothing) AndAlso props.Count > 0 AndAlso Not (_tableData Is Nothing) Then
                    Dim prop As PropertyDescriptor
                    For Each prop In props
                        Dim o As DataRow
                        For Each o In _tableData
                            writer.Write(prop.DisplayName & ": " & o(count))
                            writer.WriteBreak()
                            writer.WriteLine()
                            count = count + 1
                        Next o
                    Next prop
                Else
                    writer.Write("No data")
                End If
            Else
                writer.Write("Not connected")
            End If

        End Sub 'RenderContents

        '<SNIPPET5>
        <ConnectionConsumer("Row")> _
        Public Sub SetConnectionInterface(ByVal provider As IWebPartRow)
            _provider = provider

        End Sub 'SetConnectionInterface
    End Class 'RowConsumerWebPart 
    '</SNIPPET5>

    '</SNIPPET2>

End Namespace
