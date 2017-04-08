Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI

Namespace TemplateControlSamplesVB

    <ParseChildren(true)> Public Class Repeater1VB : Inherits Control : Implements INamingContainer

        Private _itemTemplate As ITemplate = Nothing
        Private _dataSource As ICollection = Nothing

        Public Property DataSource As ICollection
            Get
               Return _dataSource
            End Get
            Set
               _dataSource = Value
            End Set
        End Property

        <TemplateContainer(GetType(RepeaterItemVB))> public Property ItemTemplate As ITemplate
            Get
               return _itemTemplate
            End Get
            Set
               _itemTemplate = value
            End Set
        End Property

        ' <snippet1>
        ' Override to prevent LiteralControls from being added as children.
        Protected Overrides Sub AddParsedSubObject(O As Object)
        End Sub
        ' </snippet1>

        ' <snippet2>
        ' Override to create repeated items.
        Protected Overrides Sub CreateChildControls()
            Dim O As Object = ViewState("NumItems")
            If Not (O Is Nothing)
               ' Clear any existing child controls.
               Controls.Clear()

               Dim I As Integer
               Dim NumItems As Integer = CInt(O)
               For I = 0 To NumItems - 1
                  ' Create an item.
                  Dim Item As RepeaterItemVB = New RepeaterItemVB(I, Nothing)
                  ' Initialize the item from the template.
                  ItemTemplate.InstantiateIn(Item)
                  ' Add the item to the ControlCollection.
                  Controls.Add(Item)
               Next
            End If
        End Sub
        ' </snippet2>

        ' <snippet3>
        ' Override to create the repeated items from the DataSource.
        Protected Overrides Sub OnDataBinding(E As EventArgs)
            MyBase.OnDataBinding(e)

            If Not DataSource Is Nothing
                ' Clear any existing child controls.
                Controls.Clear()
                ' Clear any previous view state for the existing child controls.
                ClearChildViewState()

                ' Iterate over the DataSource, creating a new item for each data item.
                Dim DataEnum As IEnumerator = DataSource.GetEnumerator()
                Dim I As Integer = 0
                Do While (DataEnum.MoveNext())

                    ' Create an item.
                    Dim Item As RepeaterItemVB = New RepeaterItemVB(I, DataEnum.Current)
                    ' Initialize the item from the template.
                    ItemTemplate.InstantiateIn(Item)
                    ' Add the item to the ControlCollection.
                    Controls.Add(Item)

                    I = I + 1
                Loop

                ' Prevent child controls from being created again.
                ChildControlsCreated = true
                ' Store the number of items created in view state for postback scenarios.
                ViewState("NumItems") = I
            End If
        End Sub
        ' </snippet3>
    End Class

End Namespace