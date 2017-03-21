        Private Sub RecurseDataBindInternal(ByVal node As TreeNode, _
            ByVal enumerable As IHierarchicalEnumerable, _
            ByVal depth As Integer)

            Dim item As Object
            For Each item In enumerable

                Dim data As IHierarchyData = enumerable.GetHierarchyData(item)

                If Not data Is Nothing Then

                    ' Create an object that represents the bound data
                    ' to the control.
                    Dim newNode As New TreeNode()
                    Dim rvnode As New RootViewNode()

                    rvnode.Node = newNode
                    rvnode.Depth = depth

                    ' The dataItem is not just a string, but potentially
                    ' an XML node or some other container. 
                    ' If DataTextField is set, use it to determine which 
                    ' field to render. Otherwise, use the first field.                    
                    If DataTextField.Length > 0 Then
                        newNode.Text = DataBinder.GetPropertyValue _
                        (data, DataTextField, Nothing)
                    Else
                        Dim props As PropertyDescriptorCollection = _
                        TypeDescriptor.GetProperties(data)

                        ' Set the "default" value of the node.
                        newNode.Text = String.Empty

                        ' Set the true data-bound value of the TextBox,
                        ' if possible.
                        If props.Count >= 1 Then
                            If Not props(0).GetValue(data) Is Nothing Then
                                newNode.Text = props(0).GetValue(data).ToString()
                            End If
                        End If
                    End If

                    Nodes.Add(rvnode)

                    If data.HasChildren Then
                        Dim newEnumerable As IHierarchicalEnumerable = _
                            data.GetChildren()
                        If Not (newEnumerable Is Nothing) Then
                            RecurseDataBindInternal(newNode, _
                            newEnumerable, depth + 1)
                        End If
                    End If

                    If MaxDepth < depth Then
                        MaxDepth = depth
                    End If
                End If
            Next item

        End Sub 'RecurseDataBindInternal
