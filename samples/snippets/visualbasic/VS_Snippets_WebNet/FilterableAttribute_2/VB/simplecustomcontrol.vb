' <Snippet1>

Imports System.ComponentModel
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls

    Public Class SimpleCustomControl
        Inherits System.Web.UI.WebControls.WebControl

        Dim _productID As String

        ' Set Filterable attribute to specify that this
        ' property does not support device filtering.
        <Bindable(True), Filterable(False)> Property ProductID() As String
            Get
                Return _productID
            End Get

            Set(ByVal Value As String)
                _productID = Value
            End Set
        End Property
    End Class

End Namespace

' </Snippet1>