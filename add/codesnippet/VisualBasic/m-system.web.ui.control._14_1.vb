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