'<snippet2>
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
  Public Class TextBoxSet
    Inherits DataBoundControl

    Private alBoxSet As IList

    Public ReadOnly Property BoxSet() As IList
        Get
            If alBoxSet Is Nothing Then
                alBoxSet = New ArrayList()
            End If
            Return alBoxSet
        End Get
    End Property

    '<snippet7>    
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
    '</snippet7>    

    '<snippet3>        
    Protected Overrides Sub PerformSelect()

        ' Call OnDataBinding here if bound to a data source using the 
        ' DataSource property (instead of a DataSourceID) because the 
        ' data-binding statement is evaluated before the call to GetData.
        If Not IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If

        ' The GetData method retrieves the DataSourceView object from the 
        ' IDataSource associated with the data-bound control.            
        GetData().Select(CreateDataSourceSelectArguments(), _
            AddressOf OnDataSourceViewSelectCallback)

        ' The PerformDataBinding method has completed.
        RequiresDataBinding = False
        MarkAsDataBound()

        ' Raise the DataBound event.
            OnDataBound(EventArgs.Empty)

    End Sub 'PerformSelect

    '</snippet3>
    '<snippet4>
    Private Sub OnDataSourceViewSelectCallback(ByVal retrievedData As IEnumerable)

        ' Call OnDataBinding only if it has not already
        ' been called in the PerformSelect method.
        If IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If
        ' The PerformDataBinding method binds the data in the retrievedData 
        ' collection to elements of the data-bound control.
        PerformDataBinding(retrievedData)

    End Sub 'OnDataSourceViewSelectCallback

    '</snippet4>        
    '<snippet5>
    Protected Overrides Sub PerformDataBinding(ByVal retrievedData As IEnumerable)
        MyBase.PerformDataBinding(retrievedData)

        ' If the data is retrieved from an IDataSource as an IEnumerable 
        ' collection, attempt to bind its values to a set of TextBox controls.
        If Not (retrievedData Is Nothing) Then

            Dim dataItem As Object
            For Each dataItem In retrievedData

                Dim box As New TextBox()

                ' The dataItem is not just a string, but potentially
                ' a System.Data.DataRowView or some other container. 
                ' If DataTextField is set, use it to determine which 
                ' field to render. Otherwise, use the first field.                    
                If DataTextField.Length > 0 Then
                    box.Text = DataBinder.GetPropertyValue( _
                    dataItem, DataTextField, Nothing)
                Else
                    Dim props As PropertyDescriptorCollection = _
                        TypeDescriptor.GetProperties(dataItem)

                    ' Set the "default" value of the TextBox.
                    box.Text = String.Empty

                    ' Set the true data-bound value of the TextBox,
                    ' if possible.
                    If props.Count >= 1 Then
                        If props(0).GetValue(dataItem) IsNot Nothing Then
                            box.Text = props(0).GetValue(dataItem).ToString()
                        End If
                    End If
                End If

                BoxSet.Add(box)
            Next dataItem
        End If

    End Sub 'PerformDataBinding

    '</snippet5>                
    '<snippet6>
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

        ' Render nothing if the control is empty.            
        If BoxSet.Count <= 0 Then
            Return
        End If

        ' Make sure the control is declared in a form tag with runat=server.
        If Not (Page Is Nothing) Then
            Page.VerifyRenderingInServerForm(Me)
        End If

        ' For this example, render the BoxSet as 
        ' an unordered list of TextBox controls.            
        writer.RenderBeginTag(HtmlTextWriterTag.Ul)

        Dim item As Object
        For Each item In BoxSet

            Dim box As TextBox = CType(item, TextBox)

            ' Write each element as 
            ' <li><input type="text" value="string"><input/></li>
            writer.WriteBeginTag("li")
            writer.Write(">")
            writer.WriteBeginTag("input")
            writer.WriteAttribute("type", "text")
            writer.WriteAttribute("value", box.Text)
            writer.Write(">")
            writer.WriteEndTag("input")
            writer.WriteEndTag("li")
        Next item

        writer.RenderEndTag()

    End Sub 'Render
    End Class 'TextBoxSet 
    '</snippet6>       
End Namespace
'</snippet2>