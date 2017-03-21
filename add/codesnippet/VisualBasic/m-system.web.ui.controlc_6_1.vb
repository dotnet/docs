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