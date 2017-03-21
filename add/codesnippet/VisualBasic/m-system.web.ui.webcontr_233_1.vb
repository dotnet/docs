        Protected Overrides Sub PerformDataBinding()
            MyBase.PerformDataBinding()

            ' Do not attempt to bind data if there is no
            ' data source set.
            If Not IsBoundUsingDataSourceID AndAlso DataSource Is Nothing Then
                Return
            End If

            Dim view As HierarchicalDataSourceView = GetData(RootNode.DataPath)

            If view Is Nothing Then
                Throw New InvalidOperationException _
                ("No view returned by data source control.")
            End If

            Dim enumerable As IHierarchicalEnumerable = view.Select()
            If Not (enumerable Is Nothing) Then

                Nodes.Clear()

                Try
                    RecurseDataBindInternal(RootNode, enumerable, 1)
                Finally
                End Try
            End If

        End Sub ' PerformDataBinding

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
