 ' <Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.Controls.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
        AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class SimpleDataBoundColumn
        ' <Snippet2>
        Inherits DataBoundControl

        Public Property DataTextField() As String
            Get
                Dim o As Object = ViewState("DataTextField")
                If o Is Nothing Then
                    Return String.Empty
                Else
                    Return CStr(o)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("DataTextField") = value
                If (Initialized) Then
                    OnDataPropertyChanged()
                End If
            End Set
        End Property
        ' </Snippet2>

        ' <Snippet3>
        Protected Overrides Sub PerformSelect()
            ' Call OnDataBinding here if bound to a data source using the
            ' DataSource property (instead of a DataSourceID), because the
            ' databinding statement is evaluated before the call to GetData.       
            If Not IsBoundUsingDataSourceID Then
                OnDataBinding(EventArgs.Empty)
            End If

            ' The GetData method retrieves the DataSourceView object from  
            ' the IDataSource associated with the data-bound control.            
            GetData().Select(CreateDataSourceSelectArguments(), _
                AddressOf OnDataSourceViewSelectCallback)

            ' The PerformDataBinding method has completed.
            RequiresDataBinding = False
            MarkAsDataBound()

            ' Raise the DataBound event.
            OnDataBound(EventArgs.Empty)

        End Sub
        ' </Snippet3>

        ' <Snippet4>
        Private Sub OnDataSourceViewSelectCallback(ByVal retrievedData As IEnumerable)
            ' Call OnDataBinding only if it has not already been 
            ' called in the PerformSelect method.
            If IsBoundUsingDataSourceID Then
                OnDataBinding(EventArgs.Empty)
            End If
            ' The PerformDataBinding method binds the data in the  
            ' retrievedData collection to elements of the data-bound control.
            PerformDataBinding(retrievedData)

        End Sub
        ' </Snippet4>

        ' <Snippet5>
        Protected Overrides Sub PerformDataBinding(ByVal retrievedData As IEnumerable)
            MyBase.PerformDataBinding(retrievedData)

            ' Verify data exists.
            If Not (retrievedData Is Nothing) Then
                Dim tbl As New Table()
                Dim row As TableRow
                Dim cell As TableCell
                Dim dataStr As String = String.Empty

                Dim dataItem As Object
                For Each dataItem In retrievedData
                    ' If the DataTextField was specified get the data
                    ' from that field, otherwise get the data from the first field. 
                    If DataTextField.Length > 0 Then
                        dataStr = DataBinder.GetPropertyValue(dataItem, DataTextField, Nothing)
                    Else
                        Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(dataItem)
                        If props.Count >= 1 Then
                            If Nothing <> props(0).GetValue(dataItem) Then
                                dataStr = props(0).GetValue(dataItem).ToString()
                            End If
                        End If
                    End If

                    row = New TableRow()
                    tbl.Rows.Add(row)
                    cell = New TableCell()
                    cell.Text = dataStr
                    row.Cells.Add(cell)
                Next dataItem

                Controls.Add(tbl)
            End If

        End Sub
    End Class
End Namespace
' </Snippet5>
' </Snippet1>