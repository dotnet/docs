'<Snippet1>
Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace TemplateControlSamplesVB

    <ParseChildren(True)> _
    Public Class CustomRepeaterVB : Inherits Repeater

        ' Override to prevent LiteralControls from being added as children.
        Protected Overrides Sub AddParsedSubObject(ByVal O As Object)
        End Sub

        ' Override to create repeated items.
        Protected Overrides Sub CreateChildControls()
            Dim O As Object = ViewState("NumItems")
            If Not (O Is Nothing) Then
                ' Clear any existing child controls.
                Controls.Clear()

                Dim i As Integer
                Dim NumItems As Integer = CInt(O)
                For i = 0 To NumItems - 1
                    ' Create an item.
                    Dim Item As RepeaterItem = New RepeaterItem(i, ListItemType.Item)
                    ' Initialize the item from the template.
                    ItemTemplate.InstantiateIn(Item)
                    ' Add the item to the ControlCollection.
                    Controls.Add(Item)
                Next
            End If
        End Sub

        ' Override to create the repeated items from the DataSource.
        Protected Overrides Sub OnDataBinding(ByVal E As EventArgs)
            MyBase.OnDataBinding(E)

            If Not DataSource Is Nothing Then

                ' Iterate over the DataSource, creating a new item for each data item.
                Dim DataEnum As IEnumerator = DataSource.GetEnumerator()
                Dim i As Integer = 0
                Do While (DataEnum.MoveNext())

                    ' Create an item.
                    Dim Item As RepeaterItem = New RepeaterItem(i, ListItemType.Item)
                    ' Initialize the item from the template.
                    ItemTemplate.InstantiateIn(Item)
                    ' Add the item to the ControlCollection.
                    Controls.Add(Item)

                    i = i + 1
                Loop

                ' Prevent child controls from being created again.
                ChildControlsCreated = True
                ' Store the number of items created in view state for postback scenarios.
                ViewState("NumItems") = i
            End If
        End Sub
    End Class

End Namespace
'</Snippet1>