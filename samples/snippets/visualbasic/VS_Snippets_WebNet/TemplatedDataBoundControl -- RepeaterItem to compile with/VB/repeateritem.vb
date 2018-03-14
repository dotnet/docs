'<snippet1>
Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Namespace TemplateControlSamplesVB

    Public Class RepeaterItemVB : Inherits Control : Implements INamingContainer

        Private _ItemIndex As Integer
        Private _DataItem As Object

        Public Sub New(ItemIndex As Integer, DataItem As Object)
            MyBase.New()
            _ItemIndex = ItemIndex
            _DataItem = DataItem
        End Sub

        Public ReadOnly Property DataItem As Object
            Get
                return _DataItem
            End Get
        End Property

        Public ReadOnly Property ItemIndex As Integer
            Get
                return _ItemIndex
            End Get
        End Property

    End Class

End Namespace
'</snippet1>
